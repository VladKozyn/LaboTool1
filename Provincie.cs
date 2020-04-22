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


        public Provincie(int gemeenteId,int provincieId, String taal, String naam)
        {
            this.gemeenteId = gemeenteId;
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
        public int totaalStratenProvincie(List<Gemeente> gemeentes)
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
