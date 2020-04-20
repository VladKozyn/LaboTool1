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
            List<Graaf>
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
