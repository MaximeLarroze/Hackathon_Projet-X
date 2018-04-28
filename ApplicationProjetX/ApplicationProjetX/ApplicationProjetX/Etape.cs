using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationProjetX
{
    class Etape
    {
        public int id { get; set; }
        public Lieu depart { get; set; }
        public Lieu arriver { get; set; }
        public Etape()
        {

        }
        public string getWay()
        {
            return "https://www.google.com/maps/embed/v1/directions?key=AIzaSyBRwkQtd8fV-UohPFI2MVKD_6UgRQ6xlz0&origin=" + this.depart + "&destination=" + this.arriver + "&avoid=tolls|highways";
        }
    }
}
