using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationProjetX
{
    class Parcour
    {
        public List<Etape> etapes { get; set; }
        public Etape current { get; set; }
        public int index { get; set; }
        public Parcour()
        {

        }
        public string GetParcour()
        {
            string url1 = "https://www.google.com/maps/embed/v1/directions?key=AIzaSyBRwkQtd8fV-UohPFI2MVKD_6UgRQ6xlz0&origin=&destination=&avoid=tolls|highways&waypoints=" + etapes[0].depart.name + "|" + etapes[etapes.Count - 1].depart.name + "|" + etapes[etapes.Count - 1].arriver.name + "|";
            string url2 = "";
            for (int i = 1; i < etapes.Count-1; i++)
            {
                if (i % 2 != 0)
                {
                    url2 += etapes[i].arriver.name;
                }
                else
                {
                    url2 += etapes[i].depart.name;
                }
                if (i < etapes.Count - 2)
                {
                    url2 += "|";
                }
            }
            return url1 + url2;
        }
    }
}
