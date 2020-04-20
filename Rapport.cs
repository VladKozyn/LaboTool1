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
            List<Segment> listVanSegmenten = leesCsv.maakListVanSegmenten(leesCsv.leesWegsegmenten());
            List<Segment> listVanSegmentenVoorGraaf = listVanSegmenten;
            List<Graaf> listVanGrafen = new List<Graaf>();



            for (int i = 0; i < listVanSegmenten.Count; i++)
            {
               /* if (listVanSegmentenVoorGraaf[i].beginknoop.knoopID != listVanSegmentenVoorGraaf[i].eindknoop.knoopID) {
                    if(listVanGrafen[listVanSegmentenVoorGraaf[i].beginknoop.knoopID] == null)
                    {
                        listVanGrafen.Insert(listVanSegmenten[i].beginknoop.knoopID, new Graaf(listVanSegmentenVoorGraaf[i].beginknoop.knoopID));
                        listVanGrafen[listVanSegmentenVoorGraaf[i].beginknoop.knoopID].voegSegmentToe(listVanSegmentenVoorGraaf[i]);

                    }
                    else { listVanGrafen[listVanSegmentenVoorGraaf[i].beginknoop.knoopID].voegSegmentToe(listVanSegmentenVoorGraaf[i]); }
                    if(listVanGrafen[listVanSegmentenVoorGraaf[i].eindknoop.knoopID] == null)
                    {
                        listVanGrafen.Insert(listVanSegmenten[i].eindknoop.knoopID, new Graaf(listVanSegmentenVoorGraaf[i].beginknoop.knoopID));
                        listVanGrafen[listVanSegmentenVoorGraaf[i].eindknoop.knoopID].voegSegmentToe(listVanSegmentenVoorGraaf[i]);
                    }else
                    { listVanGrafen[listVanSegmentenVoorGraaf[i].eindknoop.knoopID].voegSegmentToe(listVanSegmentenVoorGraaf[i]); }
                }
                else{
                    if (listVanGrafen[listVanSegmentenVoorGraaf[i].beginknoop.knoopID] == null)
                    {
                        listVanGrafen.Insert(listVanSegmenten[i].beginknoop.knoopID, new Graaf(listVanSegmentenVoorGraaf[i].beginknoop.knoopID));
                        listVanGrafen[listVanSegmentenVoorGraaf[i].beginknoop.knoopID].voegSegmentToe(listVanSegmentenVoorGraaf[i]);
                    }
                    else
                    {
                        listVanGrafen[listVanSegmentenVoorGraaf[i].beginknoop.knoopID].voegSegmentToe(listVanSegmentenVoorGraaf[i]);
                    }
                }
                */
            /*  if(listVanSegmentenVoorGraaf[i].beginknoop.knoopID== i  || listVanSegmentenVoorGraaf[i].eindknoop.knoopID == i )
              {
                  l

                  if (listVanSegmentenVoorGraaf[i].beginknoop.knoopID == listVanSegmentenVoorGraaf[i].eindknoop.knoopID){ 

                  }
              }
              listVanGrafen.Add(new Graaf(i));
              */


        }

            //doe eerste provincie dan gemeente enz


            List<Straat>
            List<Gemeente>
            List<Provincie>
                //todo^


            }
            //todo graven maken en de list van segmenten verwijderen
            Console.WriteLine("\n");
        }
    }
}
