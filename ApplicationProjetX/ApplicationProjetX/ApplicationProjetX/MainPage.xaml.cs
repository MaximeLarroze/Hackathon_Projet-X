using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ApplicationProjetX
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}
        public async void Parc1_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Parcours());
        }
        public async void Parc2_clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new FinParcour());
        }
    }
}
