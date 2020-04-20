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
                /*wegsegmentID [0];
      geo [1];
      morfologie [2];
      status [3];
      beginWegknoopID [4];
      eindWegknoopID [5];
      linksStraatnaamID [6];
      rechtsStraatnaamID [7]*/

            }
            //todo graven maken en de list van segmenten verwijderen
            Console.WriteLine("\n");
        }
    }
}
