using System.Collections.Generic;
using System;
namespace Tool1
{
   public class Provincie
    {
        int gemeenteId { get; set; }
        int provincieId { get; set; }
        String taal { get; set; }
        String naam { get; set; }
        List<Gemeente> gemeentes { get; set; }

        public void showGemeente()
        {

        }
        public Provincie(int gemeenteId,int provincieId, string taal, string naam,List<Gemeente> gemeentes)
        {
            this.gemeenteId = gemeenteId;
            this.provincieId = provincieId;
            this.taal = taal;
            this.naam = naam;
            this.gemeentes = gemeentes;
        }

    }
}
