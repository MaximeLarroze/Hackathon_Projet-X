using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace ApplicationProjetX
{
	public partial class MainPage : ContentPage
	{
        List<Parcour> parcours = new List<Parcour>();
		public MainPage()
		{
			InitializeComponent();
            Lieu lieu1 = new Lieu()
            {
                Name = "ICI",
                Tags = new List<string>() { "person"},
                X = 0,
                Y = 0
            };

            Lieu lieu2 = new Lieu()
            {
                Name = "Parc Darcy",
                Tags = new List<string>() { "person", "park" },
                X = 47.3244582,
                Y = 5.0323696
            };

            Lieu lieu3 = new Lieu()
            {
                Name = "Gare de Dijon",
                Tags = new List<string>() { "person", "train", "station" },
                X = 47.3235004,
                Y = 5.0249542
            };

            Etape etape1 = new Etape()
            {
                Id = 0,
                Depart = lieu1,
                Arriver = lieu1
            };

            Etape etape2 = new Etape()
            {
                Id = 1,
                Depart = lieu2,
                Arriver = lieu2
            };

            Etape etape3 = new Etape()
            {
                Id = 1,
                Depart = lieu3,
                Arriver = lieu3
            };

            Parcour parcour1 = new Parcour()
            {
                Etapes = new List<Etape>() { etape1},
                Name = "ICI"
            };

            Parcour parcour2 = new Parcour()
            {
                Etapes = new List<Etape>() { etape2, etape3 },
                Name = "d'un parc à la gare"
            };

            parcours.Add(parcour1);
            parcours.Add(parcour2);

            listParcours.ItemsSource = parcours;
        }


        public void parcoursFocused(object sender, EventArgs e)
        {
            ((StackLayout)sender).BackgroundColor = Color.Blue;
        }

        public void btnValiderClicked(object sender, EventArgs e)
        {
            Parcour selected = (Parcour)listParcours.SelectedItem;
            Parcours page = new Parcours();
            page.setParcour(selected);
            Navigation.PushAsync(page);
        }

    }
}
