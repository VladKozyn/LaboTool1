using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Tool1
{
    class Rapport
    {
        static void Main(string[] args)
        {
            LeesCsvBestand leesCsv = new LeesCsvBestand();

            List<List<int>> listVanGemeenteIdData = leesCsv.GemeenteIdData();
            List<Provincie> listVanProvincies = leesCsv.maakListVanProvincies(leesCsv.ProvincieInfoData(), leesCsv.listVanGebruikteProvincieIds());
            List<Gemeente> listVanGemeentes = leesCsv.maakListVanGemeentes(leesCsv.GemeentenaamData());

            List<Straat> listVanStraten = leesCsv.maakListVanStraten(leesCsv.StraatNamenData());
            List<Straat> listVanStratenGebruikt = new List<Straat>();

            List<Graaf> listVanGraven = new List<Graaf>();

            List<Segment> listVanSegmenten = leesCsv.maakListVanSegmenten(leesCsv.leesWegsegmenten());
            int alleStraten = 0;

           


            //maak lijst van provincie gebruikte gemeentes en koppel ze met provincie
            for (int a = 0; a < listVanProvincies.Count; a++)
            {
                for(int b = 0; b < listVanProvincies[a].gemeentes.Count; b++)
                {
                    if (listVanProvincies[a].gemeentes[b].gemeenteId == listVanGemeenteIdData[b][1])
                    {
                        for (int c = 0; c < listVanStraten.Count; c++)
                        {
                            if (listVanGemeenteIdData[c][0] == listVanStraten[c].straatID)
                            {
                                listVanProvincies[a].gemeentes[b].voegStraatToe(listVanStraten[c]);
                                listVanStratenGebruikt.Add(listVanStraten[c]);
                                listVanStraten.RemoveAt(c);
                            }
                            
                        }
                    }
                }

                
            }
            //maak lijst van straten koppel ze met gemeente
            for (int i = 0; i < listVanStratenGebruikt.Count; i++)
            {
                listVanGraven.Add(new Graaf(listVanStratenGebruikt[i].straatID));
            }


            //maak lijst graven
            for (int i = 0; i < listVanSegmenten.Count; i++)
            {
                if (listVanSegmenten[i].linksStraatnaamID == listVanSegmenten[i].rechtsStraatnaamID && listVanSegmenten[i].linksStraatnaamID != -9)
                {
                    if (listVanSegmenten[i].linksStraatnaamID < listVanGraven.Count)
                    {
                        listVanGraven[listVanSegmenten[i].linksStraatnaamID].voegSegmentToe(listVanSegmenten[i]);
                    }
                }
                else if(listVanSegmenten[i].linksStraatnaamID != -9)
                {
                    if (listVanSegmenten[i].linksStraatnaamID < listVanGraven.Count)
                    {
                        listVanGraven[listVanSegmenten[i].linksStraatnaamID].voegSegmentToe(listVanSegmenten[i]);
                    }
                }//else if (listVanSegmenten[i].rechtsStraatnaamID != -9)
              //  {
              //      listVanGraven[listVanSegmenten[i].rechtsStraatnaamID].voegSegmentToe(listVanSegmenten[i]);
           //     }

                
            }

            //koppel segmenten met graven en vul graven lijst

            for (int a = 0; a < listVanProvincies.Count; a++)
            {
                for (int b = 0; b < listVanProvincies[a].gemeentes.Count; b++)
                {
                    for (int c = 0; c < listVanProvincies[a].gemeentes[b].straten.Count; c++)
                    {
                        for (int d = 0; d < listVanGraven.Count; d++)
                        {

                            if (listVanProvincies[a].gemeentes[b].straten[c].straatID == listVanGraven[d].graafID)
                            {
                                listVanProvincies[a].gemeentes[b].straten[c].graaf = listVanGraven[d];
                            }
                        }
                    }

                }
            }
            // add graaf in straat

            for (int i = 0; i < listVanProvincies.Count; i++)
            {
                
                alleStraten += listVanProvincies[i].totaalStratenProvincie();

            }
            Console.WriteLine("{0}\n\nAantal straten per provincie :\n\n", alleStraten);
            for (int i = 0; i < listVanProvincies.Count; i++)
            {
                String provincieNaam ="";
                int aantalStratenPerProvincie = 0;
                provincieNaam = listVanProvincies[i].naam;
                aantalStratenPerProvincie += listVanProvincies[i].totaalStratenProvincie();
                Console.WriteLine("° {0}:{1}", provincieNaam, aantalStratenPerProvincie);
            }
        }
            
           
    }
}

