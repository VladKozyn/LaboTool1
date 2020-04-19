using System.Collections.Generic;
using System;

namespace Tool1
{
    class Segment
    {
        public int beginknoop { get; set; }
        public int eindknoop { get; set; }
        public int segmentID { get; set; }
        public List<Punt> geoPunten { get; set; }


        public Segment(int segmentID, int beginknoop, int eindknoop, List<Punt> geoPunten)
        {
            this.segmentID = segmentID;
            this.beginknoop = beginknoop;
            this.eindknoop = eindknoop;
            this.geoPunten = geoPunten;
        }

    }
}
