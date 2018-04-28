using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationProjetX
{
    public class Etape
    {
        public int Id { get; set; }
        public Lieu Depart { get; set; }
        public Lieu Arriver { get; set; }
        public Etape()
        {

        }
        public string getWay()
        {
            return "https://www.google.com/maps/embed/v1/directions?key=AIzaSyBRwkQtd8fV-UohPFI2MVKD_6UgRQ6xlz0&origin=" + this.Depart + "&destination=" + this.Arriver + "&avoid=tolls|highways";
        }
    }
}
