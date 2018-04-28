using Newtonsoft.Json.Linq;
using Plugin.Geolocator;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace ApplicationProjetX
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Parcours : ContentPage
	{
        Parcour currentParcour;
        Etape currentEtape;

        public Parcours ()
		{
            try
            {
                InitializeComponent();
            }
            catch(Exception e)
            {
                
            }

            DisplayAlert("Bienvenue", "Le but du jeu est de se rendre au pin indiqué puis de se prendre en photo devant cet endroit", "Jouer !");

            MyMap.IsShowingUser = true;
            btnCameraClicked.Clicked += async (sender, args) =>
            {
                await CrossMedia.Current.Initialize();

                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera available.", "OK");
                    return;
                }

                var file = await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    Directory = "Sample",
                    Name = "test.jpg"
                });

                if (file == null)
                    return;

                await DisplayAlert("Chargement", "Veuillez attendre la prochaine popup, ne quittez pas", "OK");
                VerifyPicture(ReconnaissanceImage.MakeAnalysisRequest(file.Path).Result);
            };
        }

        public void VerifyPicture(JObject json)
        {
            bool corresponding = true;

            List<string> tags = new List<string>();

            foreach(string tag in json["description"]["tags"])
            {
                tags.Add(tag);
            }

            foreach(string tag in currentEtape.Arriver.Tags)
            {
                if (!tags.Contains(tag))
                {
                    corresponding = false;
                }
            }

            if (corresponding)
            {
                if(currentParcour.Index == currentParcour.Etapes.Count - 1)
                {
                    // page de fin
                    DisplayAlert("Bravo !", "Vous avez terminé !", "OK");
                }
                else
                {
                    DisplayAlert("Bravo !", "Vous passez à l'étape suivante, rejoignez le prochain pin", "OK");
                    currentParcour.NextStep();
                    currentEtape = currentParcour.Current;
                    nbEtape.Text = "Etape " + currentParcour.Index+1;

                    setMapPin();
                }
            }
            else
            {
                DisplayAlert("Attention", "L'image n'est pas valide ou une erreur s'est produite, veuillez réesayer", "OK");
            }
        }

        public void setParcour(Parcour parcour)
        {
            currentParcour = parcour;
            currentParcour.Init();
            currentEtape = currentParcour.Current;
            nbEtape.Text = "Etape " + currentParcour.Index+1;

            setMapPin();
        }

        public async Task setMapPin()
        {
            if (currentEtape.Arriver.X != 0 && currentEtape.Arriver.Y != 0)
            {
                Position pos = new Position(currentEtape.Arriver.X, currentEtape.Arriver.Y);
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Position(pos.Latitude, pos.Longitude),
                    Distance.FromKilometers(1)
                    ));

                var position = new Position(currentEtape.Arriver.X, currentEtape.Arriver.Y); // Latitude, Longitude
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = position,
                    Label = currentEtape.Arriver.Name
                };
                MyMap.Pins.Add(pin);
                
            }
            else
            {
                var locator = CrossGeolocator.Current;

                var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(3));

                
                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                    new Position(position.Latitude, position.Longitude),
                    Distance.FromKilometers(1)
                    ));

                Position pos = new Position(position.Latitude, position.Longitude);
                var pin = new Pin
                {
                    Type = PinType.Place,
                    Position = pos,
                    Label = currentEtape.Arriver.Name
                };
                MyMap.Pins.Add(pin);
            }
        }
    }
}