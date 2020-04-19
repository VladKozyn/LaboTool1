using System.Collections.Generic;
using System;

namespace Tool1
{
    class Graaf
    {

        public int graafID { get; set; }
        public Dictionary<Knoop, List<Segment>> map { get; set; }
        public List<Segment> AllelistWegSegmenten { get; set; }

        public void buildGraaf(int graafID, Dictionary<Knoop, List<Segment>> map)
        {



            foreach (KeyValuePair<Knoop, List<Segment>> f in map)
            {

                if (f.Key.knoopID == f.Value[f.Key.knoopID].beginknoop.knoopID || f.Key.knoopID == f.Value[f.Key.knoopID].eindknoop.knoopID)
                {
                    listWegSegmenten.Add(f.Value[f.Key.knoopID]);


                }

            }

        }
        public List<Knoop> getKnopen()
        {

            List<Knoop> listknopen = null;
            foreach (KeyValuePair<Knoop, List<Segment>> f in map)
            {

                if (f.Key.knoopID == graafID)
                {
                    listknopen.Add(f.Key);
                }

            }
            return listknopen;
        }

        /*wegsegmentID [0];
  geo [1];
  morfologie [2];
  status [3];
  beginWegknoopID [4];
  eindWegknoopID [5];
  linksStraatnaamID [6];
  rechtsStraatnaamID [7]*/


        public Graaf(int graafID)
        {
            this.graafID = graafID;
            ++this.graafID;
        }
        public void showGraaf()
        {

        }
    }
}
