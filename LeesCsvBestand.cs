using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
namespace Tool1
{
   public class LeesCsvBestand
    {
        
        public List<List<String>> leesWegsegmenten()
        {
            List<List<String>> ListGesorteerdData = new List<List<string>>();
            using (StreamReader sr = new StreamReader("C:/Users/lieke/OneDrive/scool/prog 3/Labo/1/repository/WRdata.csv"))
            {
                string[] currentLineChopped;
                int LineTeller = 0;
                string currentLine;
                sr.ReadLine();
                // currentLine moet null zijn als het einde bereikt
                while ((currentLine = sr.ReadLine()) != null)
                {
                    if (!currentLine.Contains(";-9;-9"))
                    {
                        ListGesorteerdData.Add(new List<String>());
                        currentLineChopped = currentLine.Split(';');
                        for (int i = 0; i < currentLineChopped.Length; i++)
                        {

                           ListGesorteerdData[LineTeller].Add(currentLineChopped[i]);

                        }
                        LineTeller++;
                    }

                }
            }
            return ListGesorteerdData;
        }




        public List<Segment> maakListVanSegmenten(List<List<String>> wegSegmentenListText)
        {
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
                    if (!(k % 2 == 0))
                    {
                        listVanPuntenMetDoubleValue.Add(new Punt(doubleListVanPunten[k - 1], doubleListVanPunten[k]));
                    }
                }

                int wegsegmentID = int.Parse(wegSegmentenListText[i][0]);
                Knoop beginKnoop = new Knoop(int.Parse(wegSegmentenListText[i][4]), listVanPuntenMetDoubleValue[0]);
                Knoop eindKnoop = new Knoop(int.Parse(wegSegmentenListText[i][5]), listVanPuntenMetDoubleValue[listVanPuntenMetDoubleValue.Count - 1]);

                listMetWegsegmenten.Add(new Segment(wegsegmentID, beginKnoop, eindKnoop, listVanPuntenMetDoubleValue));
            }
            return listMetWegsegmenten;
        }
        /*wegsegmentID [0];
          geo [1];
          morfologie [2];
          status [3];
          beginWegknoopID [4];
          eindWegknoopID [5];
          linksStraatnaamID [6];
          rechtsStraatnaamID [7]*/

        public List<List<String>> StraatNamenData()
        {
            List<List<String>> ListGesorteerdStraten = new List<List<string>>();
            using (StreamReader sr = new StreamReader("C:/Users/lieke/OneDrive/scool/prog 3/Labo/1/repository/WRstraatnamen.csv"))
            {
               
                string[] currentLineChopped;
                int LineTeller = 0;
                string currentLine;
                sr.ReadLine();
                // currentLine moet null zijn als het einde bereikt
                while ((currentLine = sr.ReadLine()) != null)
                {
                    if (!currentLine.Contains("-9"))
                    {
                        ListGesorteerdStraten.Add(new List<String>());
                        currentLineChopped = currentLine.Split(';');
                        for (int i = 0; i < currentLineChopped.Length; i++)
                        {

                            ListGesorteerdStraten[LineTeller].Add(currentLineChopped[i]);

                        }
                        LineTeller++;
                        }
                }
            }
            return ListGesorteerdStraten;
        }


        //[0] ID
        //[1] Naam
        public List<List<String>> GemeentenaamData()
        {
            List<List<String>> ListGesorteerdGemeenteNamen = new List<List<string>>();
            using (StreamReader sr = new StreamReader("C:/Users/lieke/OneDrive/scool/prog 3/Labo/1/repository/WRGemeentenaam.csv"))
            {
               
                string[] currentLineChopped;
                int LineTeller = 0;
                string currentLine;
                sr.ReadLine();
                // currentLine moet null zijn als het einde bereikt
                while ((currentLine = sr.ReadLine()) != null)
                {
               if (currentLine.Contains(";nl;"))
                    {
                        ListGesorteerdGemeenteNamen.Add(new List<String>());
                        currentLineChopped = currentLine.Split(';');
                        for (int i = 0; i < currentLineChopped.Length; i++)
                        {

                            ListGesorteerdGemeenteNamen[LineTeller].Add(currentLineChopped[i]);

                        }
                        LineTeller++;
                        }
                }
            }
            return ListGesorteerdGemeenteNamen;
        }
        /*
         [0] gemeentenaamID
         [1] gemeenteID
         [2] taalCodeGemeenteNaam
         [3] gemeenteNaam
        */
        public List<List<String>> GemeenteIdData()
        {
            List<List<String>> ListGesorteerdGemeenteId = new List<List<string>>();
            using (StreamReader sr = new StreamReader("C:/Users/lieke/OneDrive/scool/prog 3/Labo/1/repository/WRGemeenteID.csv"))
            {
               
                string[] currentLineChopped;
                int LineTeller = 0;
                string currentLine;
                sr.ReadLine();
                // currentLine moet null zijn als het einde bereikt
                while ((currentLine = sr.ReadLine()) != null)
                {

                        ListGesorteerdGemeenteId.Add(new List<String>());
                        currentLineChopped = currentLine.Split(';');
                        for (int i = 0; i < currentLineChopped.Length; i++)
                        {

                            ListGesorteerdGemeenteId[LineTeller].Add(currentLineChopped[i]);

                        }
                        LineTeller++;
                        
                }
            }
            return ListGesorteerdGemeenteId;
        }
        // [0] straatNaamId
        // [1] gemeenteID

        public List<List<String>> ProvincieInfoData()
        {
            List<List<String>> ListGesorteerdProvincieInfo = new List<List<string>>();
              StreamReader provincieIdLeesCheck = new StreamReader("C:/Users/lieke/OneDrive/scool/prog 3/Labo/1/repository/ProvincieIDsVlaanderen.csv");
               String provincieIdCheckMetComma = provincieIdLeesCheck.ReadLine();
               String[] provincieIdCheck = provincieIdCheckMetComma.Split(',');
            using (StreamReader sr = new StreamReader("C:/Users/lieke/OneDrive/scool/prog 3/Labo/1/repository/ProvincieInfo.csv"))
            {
               
                string[] currentLineChopped;
                int LineTeller = 0;
                string currentLine;
                sr.ReadLine();

                // currentLine moet null zijn als het einde bereikt
                while ((currentLine = sr.ReadLine()) != null)
                {
                  for (int f = 0; f < provincieIdCheck.Length; f++) {
                    if (currentLine.Contains(";"+f+";")&&currentLine.Contains(";nl;"))
                    {
                        ListGesorteerdProvincieInfo.Add(new List<String>());
                        currentLineChopped = currentLine.Split(';');
                        for (int i = 0; i < currentLineChopped.Length; i++)
                        {

                      ListGesorteerdProvincieInfo[LineTeller].Add(currentLineChopped[i]);

                        }
                        LineTeller++;
                        }
                    }
                }
            }
            return ListGesorteerdProvincieInfo;
        }
        /*
         [0] gemeenteId
         [1] ProvincieID
         [2] taalCodeProcincieNaam
         [3] ProvincieNaam
        */
    }
}
