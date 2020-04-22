using System.Collections.Generic;
using System;
namespace Tool1
{
   public class Provincie
    {
       public List<int> gemeenteIds { get; set; }
        public int provincieId { get; set; }
        public String taal { get; set; }
        public String naam { get; set; }
        public List<Gemeente> gemeentes { get; set; }


        public Provincie(List<int> gemeenteIds,int provincieId, String taal, String naam)
        {
            this.gemeenteIds = gemeenteIds;
            this.provincieId = provincieId;
            this.taal = taal;
            this.naam = naam;
            List<Gemeente> gemeentes = new List<Gemeente>();
            this.gemeentes = gemeentes;
        }
        public void voegGemeentetoe(Gemeente gemeente)
        {
            gemeentes.Add(gemeente);
        }
        public int totaalStratenProvincie()
        {
            int totaalStraten = 0;
            for (int i = 0; i < this.gemeentes.Count; i++)
            {
                totaalStraten =+ this.gemeentes[i].totaalStratenGemeente();
            }
            return totaalStraten;
        }

    }
}
