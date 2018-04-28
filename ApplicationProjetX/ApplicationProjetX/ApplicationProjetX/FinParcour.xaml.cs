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
	public partial class FinParcour : ContentPage
	{
		public FinParcour ()
		{
			InitializeComponent ();
		}

        public void setResult(TimeSpan total)
        {
            tps.Text = "Vous avez mis "+total.ToString();
        }

        public void btnRetourClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new MainPage());
        }
	}
}