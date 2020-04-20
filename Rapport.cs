using System;
using System.Collections.Generic;

namespace Tool1
{
    class Rapport
    {
        static void Main(string[] args)
        {
            LeesCsvBestand f = new LeesCsvBestand();
            List<List<String>> wegSegmentenListText = f.WegSegmentenList();
            List<Segment> listMetWegsegmenten = null;
            for (int i = 0; i < wegSegmentenListText.Count; i++)
            {
                List<Punt> f = new List<Punt>();
                ListGesorteerdData[LineTeller].Add(f);
                int wegsegmentID = int.Parse(wegSegmentenListText[i][0]);
                Knoop BeginKnoop = new Knoop(int.Parse(wegSegmentenListText[i][4]), new Punt(wegSegmentenListText[i][1]),new Punt);
                Knoop eindKnoop = new Knoop(int.Parse(wegSegmentenListText[i][4]), new Punt

                listMetWegsegmenten.Add(new Segment(wegsegmentID, ), wegSegmentenListText[5], wegSegmentenListText[1])); ;

                        //                if(int.Parse(wegsegmentenList[i][4]) == i|| int.Parse(wegsegmentenList[i][5]) == i)
                        //als wegsegment gebruikt voor links en rechts voor dezelfde graaf het verwijderen
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
