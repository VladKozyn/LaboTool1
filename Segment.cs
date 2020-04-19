using System.Collections.Generic;
using System;

namespace Tool1
{
    class Segment
    {
        public Knoop beginknoop { get; set; }
        public Knoop eindknoop { get; set; }
        public int segmentID { get; set; }
        public List<Punt> geoPunten { get; set; }


        public Segment(int segmentID, Knoop beginknoop, Knoop eindknoop, List<Punt> geoPunten)
        {
            this.segmentID = segmentID;
            this.beginknoop = beginknoop;
            this.eindknoop = eindknoop;
            this.geoPunten = geoPunten;
        }

    }
}
