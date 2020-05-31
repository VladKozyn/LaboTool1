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
        public List<int> StratenIds { get; set; }


        public Gemeente(int gemeenteId, String taalCode,String GemeenteNaam)
        {
            this.gemeenteId = gemeenteId;
            this.taalCode = taalCode;
            this.GemeenteNaam = GemeenteNaam;
            List<Straat> straten = new List<Straat>();
            List<int> StratenIds = new List<int>();
            this.straten = straten;
            this.StratenIds = StratenIds;
          
        }

        public List<List<int>> addStratenIds(List<List<int>> checklist)
        {
          
            for (int i = 0; i < checklist.Count; i++)
            {
                if (checklist[i][1] == gemeenteId)
                {
                    StratenIds.Add(checklist[i][0]);
                    checklist.RemoveAt(i);
                    i--;
                }
            }
        //    checklist.RemoveAll(i => i[1] == gemeenteId); //<-trager?

            return checklist;
        }
        public void voegStraatToe(Straat straat)
        {
            straten.Add(straat);
        }

        public List<Straat> AlleStratenCheckenEnToevoegen(List<Straat> listVanStraten)
        {

            for (int i = 0; i < listVanStraten.Count; i++)
            {
                for (int f = 0; f < StratenIds.Count; f++)
                {
                    if(StratenIds[f] == listVanStraten[i].straatID)
                    {
                        voegStraatToe(new Straat(listVanStraten[i].straatID,listVanStraten[i].straatnaam)); 
                    }
                }
            }
            
            for (int b = 0; b < StratenIds.Count; b++)
            {
                listVanStraten.RemoveAll(i => i.straatID == StratenIds[b]);

            }
            
            return listVanStraten;
        }
        public int totaalStratenGemeente()
        {
            int stratenAantal = 0;
            for (int i = 0; i < this.straten.Count; i++)
            {
                stratenAantal++;
            }
            return stratenAantal;
        }
        public double totaalLengteStraten()
        {
            double lengte = 0;
            for (int i = 0; i < this.straten.Count; i++)
            {
                lengte += this.straten[i].straatlengte;
            }
            return lengte;
        }
        public Straat kortsteStraat()
        {
            double lengte = this.straten[0].straatlengte;
            Straat straattest = new Straat(this.straten[0].straatID,this.straten[0].straatnaam);
            for (int i = 1; i < this.straten.Count; i++)
            {
                
                if (lengte > this.straten[i].straatlengte && this.straten[i].straatlengte!=0)
                {
                    straattest = this.straten[i];
                    lengte = this.straten[i].straatlengte;
                }
            }
            return straattest;
        }
        public Straat LangsteStraat()
        {
            double lengte = this.straten[0].straatlengte;
            Straat straattest = new Straat(this.straten[0].straatID, this.straten[0].straatnaam);
            for (int i = 1; i < this.straten.Count; i++)
            {

                if (lengte < this.straten[i].straatlengte)
                {
                    straattest = this.straten[i];
                    lengte = this.straten[i].straatlengte;
                }
            }
            return straattest;
        }
        public void removeStraat(int index)
        {
            straten.RemoveAt(index);
        }

    }
}
