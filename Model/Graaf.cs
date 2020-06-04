using System.Collections.Generic;
using System;
using System.Linq;

namespace Tool1
{
    public class Graaf
    {

        public int graafID { get; set; }
        public List<Segment> segmentenVanGraaf { get; set; }
        public Dictionary<Knoop, List<Segment>> dictionarySegmenten { get; set; }


        public void voegSegmentToe(Segment segment)
        {
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
            List<Segment> segmentenVanGraaf = new List<Segment>();
            this.segmentenVanGraaf = segmentenVanGraaf;
            Dictionary<Knoop, List<Segment>> dictionarySegmenten = new Dictionary<Knoop, List<Segment>>();
            this.dictionarySegmenten = dictionarySegmenten;
        }

        public void maakDictionary()
        {
            for (int i = 0; i < segmentenVanGraaf.Count; i++)
            {
                if (dictionarySegmenten.ContainsKey(segmentenVanGraaf[i].beginknoop))
                {
                    dictionarySegmenten[segmentenVanGraaf[i].beginknoop].Add(segmentenVanGraaf[i]);
                }
                else if(!dictionarySegmenten.ContainsKey(segmentenVanGraaf[i].beginknoop))
                {
                    dictionarySegmenten.Add(segmentenVanGraaf[i].beginknoop, new List<Segment>());
                    dictionarySegmenten[segmentenVanGraaf[i].beginknoop].Add(segmentenVanGraaf[i]);
                }
                if (dictionarySegmenten.ContainsKey(segmentenVanGraaf[i].eindknoop))
                {
                    dictionarySegmenten[segmentenVanGraaf[i].eindknoop].Add(segmentenVanGraaf[i]);
                }
                else if (!dictionarySegmenten.ContainsKey(segmentenVanGraaf[i].eindknoop))
                {
                    dictionarySegmenten.Add(segmentenVanGraaf[i].eindknoop, new List<Segment>());
                    dictionarySegmenten[segmentenVanGraaf[i].eindknoop].Add(segmentenVanGraaf[i]);
                }

            }



        }

    }
}
