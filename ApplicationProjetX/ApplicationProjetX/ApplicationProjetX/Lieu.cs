using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationProjetX
{
    public class Lieu
    {
        public string Name { get; set; }
        public double X { get; set; }
        public double Y { get; set; }

        public List<string> Tags { get; set; }
        public Lieu()
        {

        }
    }
}
