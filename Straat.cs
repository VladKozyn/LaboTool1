using System.Collections.Generic;
using System;

namespace Tool1
{
    public class Straat
    {
        public Graaf graaf { get; set; }
        public int straatID { get; set; }
        public String straatnaam { get; set; }

        public List<Knoop> getKnopen(Graaf graaf)
        {
            return graaf.getKnopen();
        }
        public void showStraat()
        {

        }
        public Straat(int straatID, String straatnaam)
        {
            this.straatID = straatID;
            this.straatnaam = straatnaam;
        }

    }
}
