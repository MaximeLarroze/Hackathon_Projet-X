using Newtonsoft.Json.Linq;
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
			InitializeComponent ();

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

                VerifyPicture(ReconnaissanceImage.MakeAnalysisRequest(file.Path).Result);
            };

            var map = new Map(
                MapSpan.FromCenterAndRadius(
            new Position(37, -122), Distance.FromKilometers(0.3)))
            {
                IsShowingUser = true,
                HeightRequest = 100,
                WidthRequest = 960,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            var stack = new StackLayout { Spacing = 0 };
            stack.Children.Add(map);
            Content = stack;
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
                    DisplayAlert("Bravo !", "Vous passez a l'étape suivante", "OK");
                    currentParcour.NextStep();
                    currentEtape = currentParcour.Current;
                    nbEtape.Text = "Etape " + currentParcour.Index+1;
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
        }

	}
}