using System.Collections.Generic;
using System;

namespace Tool1
{
    class Graaf
    {

        public int graafID { get; set; }
        public Dictionary<Knoop, List<Segment>> map { get; set; }
        public List<Segment> segmentenVanGraaf { get; set; }



        public void voegSegmentToe(Segment segment){
            segmentenVanGraaf.Add(segment);
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
           
        }
        public void showGraaf()
        {

        }
    }
}
