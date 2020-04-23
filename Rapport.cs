using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace Tool1
{
    class Rapport
    {
        static void Main(string[] args)
        {
            LeesCsvBestand leesCsv = new LeesCsvBestand();
            List<Provincie> listVanProvincies = leesCsv.maakListVanProvincies(leesCsv.ProvincieInfoData(), leesCsv.listVanGebruikteProvincieIds());
            List<Gemeente> listVanGemeentes = leesCsv.maakListVanGemeentes(leesCsv.GemeentenaamData());
            List<Straat> listVanStraten = leesCsv.maakListVanStraten(leesCsv.StraatNamenData());
            List<Straat> gebruikteListVanStraten = new List<Straat>();
            List<Graaf> listVanGraven = new List<Graaf>();
            List<Segment> listVanSegmenten = leesCsv.maakListVanSegmenten(leesCsv.leesWegsegmenten());
            List<List<int>> checklist = leesCsv.GemeenteIdData();
            int alleStraten = 0;

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

            for (int i = 0; i < listVanProvincies.Count; i++)
            {
                for (int b = 0; b < listVanProvincies[i].gemeentes.Count; b++)
                {
                    checklist = listVanProvincies[i].gemeentes[b].addStratenIds(checklist);
                    listVanStraten = listVanProvincies[i].gemeentes[b].AlleStratenCheckenEnToevoegen(listVanStraten);
                }
            }


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


            for (int i = 0; i < gebruikteListVanStraten.Count; i++)
            {
                listVanGraven.Add(new Graaf(gebruikteListVanStraten[i].straatID));
            }


            //maak lijst graven
            for (int i = 0; i < listVanSegmenten.Count; i++)
            {
                for (int a = 0; a < listVanGraven.Count; a++)
                {
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
                }


                //else if (listVanSegmenten[i].rechtsStraatnaamID != -9)
                //  {
                //      listVanGraven[listVanSegmenten[i].rechtsStraatnaamID].voegSegmentToe(listVanSegmenten[i]);
                //     }


            }

            //koppel segmenten met graven en vul graven lijst

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
                            }
                        }
                    }

                }
            }
            // add graaf in straat

            for (int i = 0; i < listVanProvincies.Count; i++)
            {

                alleStraten += listVanProvincies[i].totaalStratenProvincie();

            }
            using (StreamWriter sw = new StreamWriter(@"C:\Users\lieke\OneDrive\scool\prog 3\Labo\1\repository\MyFiles\rapport.txt"))
            {
                sw.Write("Totaal: {0}\n\nAantal straten per provincie :\n\n", alleStraten);
                for (int i = 0; i < listVanProvincies.Count; i++)
                {
                    String provincieNaam = "";
                    int aantalStratenPerProvincie = 0;
                    provincieNaam = listVanProvincies[i].naam;
                    aantalStratenPerProvincie += listVanProvincies[i].totaalStratenProvincie();
                    sw.Write("° procincienaam: {0}: aantalstraten: {1}", provincieNaam, aantalStratenPerProvincie);
                }
                for (int a = 0; a < listVanProvincies.Count; a++)
                {
                    Console.WriteLine("\nStraatInfo:  {0}:\n\n", listVanProvincies[a].naam);
                    for (int b = 0; b < listVanProvincies[a].gemeentes.Count; b++)
                    {
                        sw.Write("    °  Gemeentenaam: {0} , totaalaantalstraten: {1} , totaallengtestraten: {2}\n", listVanProvincies[a].gemeentes[b].GemeenteNaam, listVanProvincies[a].gemeentes[b].straten.Count, listVanProvincies[a].gemeentes[b].totaalLengteStraten());
                        sw.Write("      °  kortste straat: id: {0}, straatNaam: {1}, lengte: {2} \n", listVanProvincies[a].gemeentes[b].kortsteStraat().straatID, listVanProvincies[a].gemeentes[b].kortsteStraat().straatnaam, listVanProvincies[a].gemeentes[b].kortsteStraat().berekenStraatLengte());
                        sw.Write("      °  langste straat: id: {0}, straatNaam: {1}, lengte: {2} \n", listVanProvincies[a].gemeentes[b].LangsteStraat().straatID, listVanProvincies[a].gemeentes[b].LangsteStraat().straatnaam, listVanProvincies[a].gemeentes[b].LangsteStraat().berekenStraatLengte());
                    }
                }


            }

        }
    }
}

