using System;
using System.Collections.Generic;
using System.Globalization;

namespace Tool1
{
    class Rapport
    {
        static void Main(string[] args)
        {
            LeesCsvBestand leesCsv = new LeesCsvBestand();

            List<List<int>> listVanGemeenteIdData = leesCsv.GemeenteIdData();

            List<Provincie> listVanProvincies = leesCsv.maakListVanProvincies(leesCsv.ProvincieInfoData());

            List<Gemeente> listVanGemeentes = leesCsv.maakListVanGemeentes(leesCsv.GemeentenaamData());
            List<Gemeente> listVanGemeentesGebruikt = new List<Gemeente>();

            List<Straat> listVanStraten = leesCsv.maakListVanStraten(leesCsv.StraatNamenData());
            List<Straat> listVanStratenGebruikt = new List<Straat>();

            List<Graaf> listVanGraven = new List<Graaf>();

            List<Segment> listVanSegmenten = leesCsv.maakListVanSegmenten(leesCsv.leesWegsegmenten());



            for (int a = 0; a < listVanProvincies.Count; a++)
            {
                for (int b = 0; b < listVanGemeentes.Count; b++)
                {
                    if(listVanProvincies[a].gemeenteId == listVanGemeentes[b].gemeenteId)
                    {
                        listVanProvincies[a].voegGemeentetoe(listVanGemeentes[b]);
                        listVanGemeentesGebruikt.Add(listVanGemeentes[b]);
                        listVanGemeentes.RemoveAt(b);
                        
                    }

                }

            }
            //maak lijst van gebruikte gemeentes en koppel ze met provincie
            for (int a = 0; a < listVanGemeentesGebruikt.Count; a++)
            {
                for(int b = 0; b < listVanGemeenteIdData.Count; b++)
                {
                    if (listVanGemeentesGebruikt[a].gemeenteId == listVanGemeenteIdData[b][1])
                    {
                        for (int c = 0; b < listVanStraten.Count; c++)
                        {
                            if (listVanGemeenteIdData[a][0] == listVanStraten[c].straatID)
                            {
                                listVanGemeentesGebruikt[a].voegStraatToe(listVanStraten[c]);
                                listVanStratenGebruikt.Add(listVanStraten[c]);
                                listVanStraten.RemoveAt(c);
                            }

                        }
                    }
                }

                
            }
            //maak lijst van straten koppel ze met gemeente
            for (int i = 0; i < listVanSegmenten.Count; i++)
            {

                if (listVanGraven[listVanSegmenten[i].linksStraatnaamID].GetType() == null && listVanSegmenten[i].linksStraatnaamID !=-9)
                {
                    listVanGraven.Insert(listVanSegmenten[i].linksStraatnaamID, (new Graaf(listVanSegmenten[i].linksStraatnaamID)));

                }

                if (listVanGraven[listVanSegmenten[i].rechtsStraatnaamID].GetType() == null && listVanSegmenten[i].rechtsStraatnaamID != -9)
                {
                    listVanGraven.Insert(listVanSegmenten[i].rechtsStraatnaamID, (new Graaf(listVanSegmenten[i].rechtsStraatnaamID)));

                }

                if (listVanSegmenten[i].linksStraatnaamID == listVanSegmenten[i].rechtsStraatnaamID && listVanSegmenten[i].linksStraatnaamID != -9)
                {
                    

                        listVanGraven[listVanSegmenten[i].linksStraatnaamID].voegSegmentToe(listVanSegmenten[i]);

                }
                else if(listVanSegmenten[i].linksStraatnaamID != -9)
                {
                    listVanGraven[listVanSegmenten[i].linksStraatnaamID].voegSegmentToe(listVanSegmenten[i]);
                    
                }else if (listVanSegmenten[i].rechtsStraatnaamID != -9)
                {
                    listVanGraven[listVanSegmenten[i].rechtsStraatnaamID].voegSegmentToe(listVanSegmenten[i]);
                }
            }
            //koppel segmenten met graven en vul graven lijst

            for (int i = 0; i < listVanStratenGebruikt.Count; i++)
            {
                listVanStratenGebruikt[i].graaf = listVanGraven[i];
            }

            // add graaf in straat
            

            Console.WriteLine("\n");
        }
            
            
    }
}

