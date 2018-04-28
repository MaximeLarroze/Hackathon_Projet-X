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
        public void Parc1_clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Parcours());
        }
        public void Parc2_clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FinParcour());
        }
    }
}
