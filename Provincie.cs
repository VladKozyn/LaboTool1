using System.Collections.Generic;
using System;
namespace Tool1
{
   public class Provincie
    {
       public int gemeenteId { get; set; }
        public int provincieId { get; set; }
        public String taal { get; set; }
        public String naam { get; set; }
        public List<Gemeente> gemeentes { get; set; }

        public void showGemeente()
        {

        }
        public Provincie(int gemeenteId,int provincieId, String taal, String naam)
        {
            this.gemeenteId = gemeenteId;
            this.provincieId = provincieId;
            this.taal = taal;
            this.naam = naam;
        }
        public void voegGemeentetoe(Gemeente gemeente)
        {
            gemeentes.Add(gemeente);
        }
    }
}
