using System;
using System.Collections.Generic;
using System.IO;

namespace Tool1
{
    class Rapport
    {
        static void Main(string[] args)
        {
            LeesCsvBestand leesCsv = new LeesCsvBestand();
            List<Provincie> listVanProvincies = leesCsv.maakListVanProvincies(leesCsv.ProvincieInfoData(), leesCsv.listVanGebruikteProvincieIds()); //list van gebruikte prov

            List<Gemeente> listVanGemeentes = leesCsv.maakListVanGemeentes(leesCsv.GemeentenaamData()); //list van alle gemeentes
            List<Straat> listVanStraten = leesCsv.maakListVanStraten(leesCsv.straatNamenData()); //list van alle straten
            List<Segment> listVanSegmenten = leesCsv.maakListVanSegmenten(leesCsv.wegsegmentenData()); //list van segmenten
            List<List<int>> checklist = leesCsv.GemeenteIdData(); //check list om gemeenteIDData te verkorteren

            List<Straat> gebruikteListVanStraten = new List<Straat>(); //list om op te vullen van gebruikte straten
            List<Graaf> listVanGraven = new List<Graaf>(); //list van graven om op te vullen met gebruikte graven




            int alleStraten = 0;

            //provincies hun gemeentes opvullen
            for (int a = 0; a < listVanGemeentes.Count; a++)
            {
                for (int b = 0; b < listVanProvincies.Count; b++)
                {
                    if (listVanProvincies[b].gemeenteIds.Contains(listVanGemeentes[a].gemeenteId))
                    {
                        listVanProvincies[b].voegGemeentetoe(listVanGemeentes[a]);

                    }
                }
            }

            // alle gemeentes hun straten opvullen + de totale lijst verkorteren
            for (int i = 0; i < listVanProvincies.Count; i++)
            {
                for (int b = 0; b < listVanProvincies[i].gemeentes.Count; b++)
                {
                    checklist = listVanProvincies[i].gemeentes[b].addStratenIds(checklist);
                    listVanStraten = listVanProvincies[i].gemeentes[b].AlleStratenCheckenEnToevoegen(listVanStraten);
                }
            }

            //gebruikte straten opvullen
            for (int i = 0; i < listVanProvincies.Count; i++)
            {
                for (int b = 0; b < listVanProvincies[i].gemeentes.Count; b++)
                {
                    for (int c = 0; c < listVanProvincies[i].gemeentes[b].straten.Count; c++)
                    {
                        gebruikteListVanStraten.Add(listVanProvincies[i].gemeentes[b].straten[c]);
                    }


                }
            }

            //maak lijst graven
            for (int i = 0; i < gebruikteListVanStraten.Count; i++)
            {
                listVanGraven.Add(new Graaf(gebruikteListVanStraten[i].straatID));
            }

            //koppel segmenten met graven en vul graven lijst
            for (int i = 0; i < listVanSegmenten.Count; i++)
            {
                for (int a = 0; a < listVanGraven.Count; a++)
                {

                    if (listVanSegmenten[i].linksStraatnaamID == listVanGraven[a].graafID)
                    {
                        listVanGraven[a].voegSegmentToe(listVanSegmenten[i]);
                    }
                    /*
                    if (listVanSegmenten[i].linksStraatnaamID == listVanGraven[a].graafID)
                    {
                        if (listVanSegmenten[i].linksStraatnaamID == listVanSegmenten[i].rechtsStraatnaamID && listVanSegmenten[i].linksStraatnaamID != -9)
                        {
                            listVanGraven[a].voegSegmentToe(listVanSegmenten[i]);
                        }
                    }
                    else if (listVanSegmenten[i].linksStraatnaamID == listVanGraven[a].graafID)
                    {
                        if (listVanSegmenten[i].linksStraatnaamID != -9)
                        {
                            listVanGraven[a].voegSegmentToe(listVanSegmenten[i]);
                        }
                    }
                    */
                }
            }

            // add graaf in straat + laat de straten hun lengte berekenen
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
                                listVanProvincies[a].gemeentes[b].straten[c].berekenStraatLengte();

                            }
                        }

                    }
                }
            }

            //remove ongebruikte gemeentes/straten + maak dictionary
            for (int a = 0; a < listVanProvincies.Count; a++)
            {
                for (int b = 0; b < listVanProvincies[a].gemeentes.Count; b++)
                {
                    if (listVanProvincies[a].gemeentes[b].totaalLengteStraten() == 0)
                    {
                        listVanProvincies[a].removeGemeente(b);
                        b--;
                    }
                    else
                    {
                        for (int c = 0; c < listVanProvincies[a].gemeentes[b].straten.Count; c++)
                        {
                            if (listVanProvincies[a].gemeentes[b].straten[c].straatlengte == 0)
                            {
                                listVanProvincies[a].gemeentes[b].removeStraat(c);
                                c--;
                            }
                            else
                            {
                                listVanProvincies[a].gemeentes[b].straten[c].graaf.maakDictionary();
                            }
                        }
                    }
                }
            }


            //totale straten van alle provincies optellen
            for (int i = 0; i < listVanProvincies.Count; i++)
            {

                alleStraten += listVanProvincies[i].totaalStratenProvincie();

            }


            //uitschrijven naar een txt bestand aka rapport
            //staat in commentaar? = true
            #region
            
         /*   using (StreamWriter sw = new StreamWriter(@"C:\Users\lieke\OneDrive\scool\prog 3\Labo\1\repository\MyFiles\rapport4.txt"))
            {
                sw.Write("Totaal: {0}\n\nAantal straten per provincie :\n", alleStraten);

                for (int i = 0; i < listVanProvincies.Count; i++)
                {
                    String provincieNaam = "";
                    int aantalStratenPerProvincie = 0;
                    provincieNaam = listVanProvincies[i].naam;
                    aantalStratenPerProvincie += listVanProvincies[i].totaalStratenProvincie();
                    sw.Write("\n° procincienaam: {0}: aantalstraten: {1}", provincieNaam, aantalStratenPerProvincie);
                }
                for (int a = 0; a < listVanProvincies.Count; a++)
                {
                    sw.WriteLine("\nStraatInfo:  {0}:\n\n", listVanProvincies[a].naam);
                    for (int b = 0; b < listVanProvincies[a].gemeentes.Count; b++)
                    {
                        sw.Write("    °  Gemeentenaam: {0} , totaalaantalstraten: {1} , totaallengtestraten: {2}\n",
                            listVanProvincies[a].gemeentes[b].GemeenteNaam,
                            listVanProvincies[a].gemeentes[b].straten.Count,
                            listVanProvincies[a].gemeentes[b].totaalLengteStraten());

                        sw.Write("      °  kortste straat: id: {0}, straatNaam: {1}, lengte: {2}\n",
                            listVanProvincies[a].gemeentes[b].kortsteStraat().straatID,
                            listVanProvincies[a].gemeentes[b].kortsteStraat().straatnaam.Trim(),
                            listVanProvincies[a].gemeentes[b].kortsteStraat().straatlengte);

                        sw.Write("      °  langste straat: id: {0}, straatNaam: {1}, lengte: {2}\n",
                            listVanProvincies[a].gemeentes[b].LangsteStraat().straatID,
                            listVanProvincies[a].gemeentes[b].LangsteStraat().straatnaam.Trim(),
                            listVanProvincies[a].gemeentes[b].LangsteStraat().straatlengte);
                    }
                }


            }
            */
            
            #endregion

            //uitschrijven naar meerdere txt bestanden voor databank
            //staat in commentaar? = false
            #region
        /*    using (StreamWriter sw = new StreamWriter(@"C:\Users\lieke\OneDrive\scool\prog 3\Labo\1\repository\MyFiles\Provincies.txt"))
            {
                sw.Write("provincieID;provincieNaam\n");
                for (int a = 0; a < listVanProvincies.Count; a++)
                {
                    sw.Write("{0};{1}\n",
                           listVanProvincies[a].provincieId,
                           listVanProvincies[a].naam);

                }
            }
           using (StreamWriter sw = new StreamWriter(@"C:\Users\lieke\OneDrive\scool\prog 3\Labo\1\repository\MyFiles\Gemeente.txt"))
            {
                sw.Write("gemeenteId;gemeenteNaam;totaalAantalStraten;provincieId\n");
                for (int a = 0; a < listVanProvincies.Count; a++)
                {
                    for (int b = 0; b < listVanProvincies[a].gemeentes.Count; b++)
                    {
                        sw.Write("{0};{1};{2};{3}\n",
                          listVanProvincies[a].gemeentes[b].gemeenteId,
                         listVanProvincies[a].gemeentes[b].GemeenteNaam,
                         listVanProvincies[a].gemeentes[b].totaalStratenGemeente(),
                         listVanProvincies[a].provincieId);
                        //    string.Join(";", listVanProvincies[a].gemeentes[b].StratenIds));
                    }

                }
            }
            using (StreamWriter sw = new StreamWriter(@"C:\Users\lieke\OneDrive\scool\prog 3\Labo\1\repository\MyFiles\Straat.txt"))
            {
                sw.Write("straatId;straatNaam;lengteStraat;gemeenteId\n");
                for (int a = 0; a < listVanProvincies.Count; a++)
                {
                    for (int b = 0; b < listVanProvincies[a].gemeentes.Count; b++)
                    {
                        for (int c = 0; c < listVanProvincies[a].gemeentes[b].straten.Count; c++)
                        {
                            sw.Write("{0};{1};{2};{3}\n",
                            listVanProvincies[a].gemeentes[b].straten[c].straatID,
                            listVanProvincies[a].gemeentes[b].straten[c].straatnaam.Trim(),
                            listVanProvincies[a].gemeentes[b].straten[c].straatlengte,
                            listVanProvincies[a].gemeentes[b].gemeenteId);
                        }
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter(@"C:\Users\lieke\OneDrive\scool\prog 3\Labo\1\repository\MyFiles\Graaf.txt"))
            {
                sw.Write("GraafId;straatId\n");
                for (int a = 0; a < listVanProvincies.Count; a++)
                {
                    for (int b = 0; b < listVanProvincies[a].gemeentes.Count; b++)
                    {
                        for (int c = 0; c < listVanProvincies[a].gemeentes[b].straten.Count; c++)
                        {


                            //        foreach (var kvp in listVanProvincies[a].gemeentes[b].straten[c].graaf.dictionarySegmenten)
                            //        {
                            //           stringInts += ((kvp.Key.knoopID).ToString()) + ";";
                            //       }
                            sw.Write("{0};{1}\n",
                    listVanProvincies[a].gemeentes[b].straten[c].graaf.graafID,
                    listVanProvincies[a].gemeentes[b].straten[c].straatID);
                        }
                    }
                }
            }*/
            using (StreamWriter sw = new StreamWriter(@"C:\Users\lieke\OneDrive\scool\prog 3\Labo\1\repository\MyFiles\Knopen.txt"))
            {
                sw.Write("knoopId;puntX;puntY;graafId\n");
                for (int a = 0; a < listVanProvincies.Count; a++)
                {
                    for (int b = 0; b < listVanProvincies[a].gemeentes.Count; b++)
                    {
                        for (int c = 0; c < listVanProvincies[a].gemeentes[b].straten.Count; c++)
                        {

                            foreach (KeyValuePair<Knoop,List<Segment>> kvp in listVanProvincies[a].gemeentes[b].straten[c].graaf.dictionarySegmenten)
                            {
                                sw.Write("{0};{1};{2};{3}\n",
                                    kvp.Key.knoopID,
                                     kvp.Key.punt.x,
                                     kvp.Key.punt.y,
                                    listVanProvincies[a].gemeentes[b].straten[c].graaf.graafID);



                            }
                        }
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter(@"C:\Users\lieke\OneDrive\scool\prog 3\Labo\1\repository\MyFiles\Segmenten.txt"))
            {
                sw.Write("segmentId;beginKnoop;eindKnoop;knoopId\n");
                for (int a = 0; a < listVanProvincies.Count; a++)
                {
                    for (int b = 0; b < listVanProvincies[a].gemeentes.Count; b++)
                    {
                        for (int c = 0; c < listVanProvincies[a].gemeentes[b].straten.Count; c++)
                        {

                            foreach (KeyValuePair<Knoop, List<Segment>> kvp in listVanProvincies[a].gemeentes[b].straten[c].graaf.dictionarySegmenten)
                            {
                                foreach (var listSegmenten in kvp.Value)
                                {

                                    //     foreach (var geopunten in listSegmenten.geoPunten)
                                    //     {
                                    //          printGeopunten.Add(geopunten.x);
                                    //         printGeopunten.Add(geopunten.y);
                                    //      }
                                    sw.Write("{0};{1};{2};{3}\n",
                                    listSegmenten.segmentID,
                                    listSegmenten.beginknoop.knoopID,
                                    listSegmenten.eindknoop.knoopID,
                                    kvp.Key.knoopID);
                                }



                            }
                        }
                    }
                }
            }
            using (StreamWriter sw = new StreamWriter(@"C:\Users\lieke\OneDrive\scool\prog 3\Labo\1\repository\MyFiles\Punten.txt"))
            {
                sw.Write("puntX;puntY;segmentId\n");
                for (int a = 0; a < listVanProvincies.Count; a++)
                {
                    for (int b = 0; b < listVanProvincies[a].gemeentes.Count; b++)
                    {
                        for (int c = 0; c < listVanProvincies[a].gemeentes[b].straten.Count; c++)
                        {

                            foreach (KeyValuePair<Knoop, List<Segment>> kvp in listVanProvincies[a].gemeentes[b].straten[c].graaf.dictionarySegmenten)
                            {
                                foreach (var listSegmenten in kvp.Value)
                                {

                                    foreach (var geopunten in listSegmenten.geoPunten)
                                    {
                                        sw.Write("{0};{1};{2}\n",
                             geopunten.x,
                              geopunten.y,
                             listSegmenten.segmentID);
                                    }

                                }
                            }
                        }
                    }
                }
            }
            #endregion
        }
    }
}

