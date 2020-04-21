using System.Collections.Generic;
using System;
namespace Tool1
{
   public class Gemeente
    {

        int gemeenteId { get; set; }
        String taalCode { get; set; }
        String GemeenteNaam { get; set; }
        List<Straat> straten { get; set; }


        public Gemeente(int gemeenteId, String taalCode,String GemeenteNaam,List<Straat> straten)
        {
            this.gemeenteId = gemeenteId;
            this.taalCode = taalCode;
            this.GemeenteNaam = GemeenteNaam;
            this.straten = straten;
        }

    }
}
