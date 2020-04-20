using System.Collections.Generic;
using System;

namespace Tool1
{
    class Straat
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
        public Straat(Graaf graaf, int straatID, string straatnaam)
        {
            this.graaf = graaf;
            this.straatID = straatID;
            this.straatnaam = straatnaam;
        }

    }
}
