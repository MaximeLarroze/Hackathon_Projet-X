using Newtonsoft.Json.Linq;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ApplicationProjetX
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Parcours : ContentPage
	{
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
        }

        public void VerifyPicture(JObject json)
        {
            List<string> tags = new List<string>();
            for(int i=0; i < json["description"]["tags"].Count(); i++)
            {
                etape.Text += " | " + json["description"]["tags"][i] + " |";
            }
        }
	}
}