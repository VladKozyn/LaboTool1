using System;
using System.Collections.Generic;
using System.Globalization;

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
                List<Double> doubleListVanPunten = new List<Double>();
                List<Punt> listVanPuntenMetDoubleValue = new List<Punt>();
                string puntenPlainText = wegSegmentenListText[i][1];
                puntenPlainText.Remove(0, 12);
                puntenPlainText.Trim(',');
               String[] puntenArrayStrings = puntenPlainText.Split(" ");
                for (int k = 0; k < puntenArrayStrings.Length; k++)
                {
                    doubleListVanPunten.Add(double.Parse(puntenArrayStrings[k], CultureInfo.InvariantCulture));
                    if(!(k % 2 == 0))
                    {
                        listVanPuntenMetDoubleValue.Add(new Punt(doubleListVanPunten[k - 1], doubleListVanPunten[k]));
                    }
                }

                int wegsegmentID = int.Parse(wegSegmentenListText[i][0]);
                Knoop beginKnoop = new Knoop(int.Parse(wegSegmentenListText[i][4]),listVanPuntenMetDoubleValue[0]);
                Knoop eindKnoop = new Knoop(int.Parse(wegSegmentenListText[i][5]), listVanPuntenMetDoubleValue[listVanPuntenMetDoubleValue.Count-1]);

                listMetWegsegmenten.Add(new Segment(wegsegmentID, beginKnoop, eindKnoop, listVanPuntenMetDoubleValue)); ;
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
