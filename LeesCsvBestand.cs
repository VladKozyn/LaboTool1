using System;
using System.Collections.Generic;
using System.IO;

namespace Tool1
{
    class LeesCsvBestand
    {
        List<String> ListOngesorteerdData = new List<string>();
        List<List<String>> ListGesorteerdData = new List<List<string>>();
        public void DataListsOpvullen()
        {

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
                        ListOngesorteerdData.Add(currentLine); //kan onnodig zijn
                        ListGesorteerdData.Add(new List<String>());
                        currentLineChopped = currentLine.Split(';');
                        for (int i = 0; i < 8; i++)
                        {

                            ListGesorteerdData[LineTeller].Add(currentLineChopped[i]);

                        }
                        LineTeller++;
                    }

                }
            }
        }
        /*wegsegmentID [0];
          geo [1];
          morfologie [2];
          status [3];
          beginWegknoopID [4];
          eindWegknoopID [5];
          linksStraatnaamID [6];
          rechtsStraatnaamID [7]*/

        public List<String> StraatNamenData()
        {
            List<String> teruggave = new List<string>();
            using (StreamReader sr = new StreamReader("C:/Users/lieke/OneDrive/scool/prog 3/Labo/1/repository/WRstraatnamen.csv"))
            {
                string currentLine;
                sr.ReadLine();
                // currentLine moet null zijn als het einde bereikt
                while ((currentLine = sr.ReadLine()) != null)
                {


                    teruggave.Add(currentLine);


                }
            }
            return teruggave;
        }
    }
}
