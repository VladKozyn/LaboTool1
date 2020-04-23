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
        public LeesCsvBestand idsLezen = new LeesCsvBestand();


        public Gemeente(int gemeenteId, String taalCode,String GemeenteNaam)
        {
            this.gemeenteId = gemeenteId;
            this.taalCode = taalCode;
            this.GemeenteNaam = GemeenteNaam;
            List<Straat> straten = new List<Straat>();
            List<int> StratenIds = new List<int>();
            this.straten = straten;
            this.StratenIds = StratenIds;
            addStratenIds(idsLezen);
        }

        public void addStratenIds(LeesCsvBestand leesCsvBestand)
        {
            List<List<int>> checklist = leesCsvBestand.GemeenteIdData();
            for (int i = 0; i < checklist.Count; i++)
            {
                if (checklist[i][1] == gemeenteId)
                {
                    StratenIds.Add(checklist[i][0]);
                }
            }
         
        }
        public void voegStraatToe(Straat straat)
        {
            straten.Add(straat);
        }

        public void AlleStratenCheckenEnToevoegen(LeesCsvBestand leesCsvBestand)
        {
            List<Straat> listVanStraten = leesCsvBestand.maakListVanStraten(leesCsvBestand.StraatNamenData());
            for (int i = 0; i < listVanStraten.Count; i++)
            {
                for (int f = 0; f < StratenIds.Count; f++)
                {
                    if(StratenIds[f] == listVanStraten[i].straatID)
                    {
                        straten.Add(listVanStraten[i]);
                    }
                }
            }
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
                lengte += this.straten[i].berekenStraatLengte();
            }
            return lengte;
        }


    }
}
