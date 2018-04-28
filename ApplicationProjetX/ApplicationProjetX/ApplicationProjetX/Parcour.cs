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
    }
}
