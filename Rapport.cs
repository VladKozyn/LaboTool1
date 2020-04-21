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
            List<Graaf> listVanGrafen = new List<Graaf>();
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

            //doe eerste provincie dan gemeente enz



            //todo^


        }
            //todo graven maken en de list van segmenten verwijderen
            Console.WriteLine("\n");
        }
    }
}
