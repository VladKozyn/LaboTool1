using System.Collections.Generic;
using System;

namespace Tool1
{
    public class Straat
    {
        public Graaf graaf { get; set; }
        public int straatID { get; set; }
        public string straatnaam { get; set; }

        public List<Knoop> getKnopen(Graaf graaf)
        {
             
        }
        public void showStraat()
        {

        }
        public Straat(int straatID, string straatnaam,Graaf graaf)
        {
            this.graaf = graaf;
            this.straatID = straatID;
            this.straatnaam = straatnaam;
        }

    }
}
