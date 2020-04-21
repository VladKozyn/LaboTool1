using System.Collections.Generic;
using System;
namespace Tool1
{
   public class Gemeente
    {

        public int gemeenteId { get; set; }
        public String taalCode { get; set; }
        public String GemeenteNaam { get; set; }
        public List<Straat> straten { get; set; }


        public Gemeente(int gemeenteId, String taalCode,String GemeenteNaam)
        {
            this.gemeenteId = gemeenteId;
            this.taalCode = taalCode;
            this.GemeenteNaam = GemeenteNaam;
        }
        public void voegStraatToe(Straat straat)
        {
            straten.Add(straat);
        }
    }
}
