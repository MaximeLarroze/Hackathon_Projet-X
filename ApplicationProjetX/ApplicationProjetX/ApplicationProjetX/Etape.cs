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
            return "https://www.google.com/maps/embed/v1/directions ? key = YOUR_API_KEY & origin =" + depart.name + "&" + arriver.name + "= Telemark + Norway";
        }
    }
}
