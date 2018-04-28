using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationProjetX
{
    public class Parcour
    {
        public List<Etape> Etapes { get; set; }
        public Etape Current { get; set; }
        public int Index { get; set; }

        public string Name { get; set; } 
        public Parcour()
        {

        }
        public string GetParcour()
        {
            string url1 = "https://www.google.com/maps/embed/v1/directions?key=AIzaSyBRwkQtd8fV-UohPFI2MVKD_6UgRQ6xlz0&origin=&destination=&avoid=tolls|highways&waypoints=" + Etapes[0].Depart.Name + "|" + Etapes[Etapes.Count - 1].Depart.Name + "|" + Etapes[Etapes.Count - 1].Arriver.Name + "|";
            string url2 = "";
            for (int i = 1; i < Etapes.Count-1; i++)
            {
                if (i % 2 != 0)
                {
                    url2 += Etapes[i].Arriver.Name;
                }
                else
                {
                    url2 += Etapes[i].Depart.Name;
                }
                if (i < Etapes.Count - 2)
                {
                    url2 += "|";
                }
            }
            return url1 + url2;
        }

        public void Init()
        {
            Index = 0;
            Current = Etapes[Index];
        }

        public void NextStep()
        {
            Index++;
            Current = Etapes[Index];
        }
    }
}
