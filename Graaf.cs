using System.Collections.Generic;
using System;

namespace Tool1
{
  public  class Graaf
    {

        public int graafID { get; set; }
        public Dictionary<Knoop, List<Segment>> map { get; set; }
        public List<Segment> segmentenVanGraaf { get; set; }



        public void voegSegmentToe(Segment segment){
            segmentenVanGraaf.Add(segment);
        }
        public List<Knoop> getKnopen()
        {
            List<Knoop> listKnopen = null;
            for (int i = 0; i < segmentenVanGraaf.Count; i++)
            {
                listKnopen.Add(segmentenVanGraaf[i].beginknoop);
                listKnopen.Add(segmentenVanGraaf[i].eindknoop);
            }
            return listKnopen;
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
