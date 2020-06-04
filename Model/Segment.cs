using System.Collections.Generic;
using System;

namespace Tool1
{
    public class Segment
    {
        public Knoop beginknoop { get; set; }
        public Knoop eindknoop { get; set; }
        public int segmentID { get; set; }
        public List<Punt> geoPunten { get; set; }
        public int linksStraatnaamID { get; set; }
        public int rechtsStraatnaamID { get; set; }

        public Segment(int segmentID, Knoop beginknoop, Knoop eindknoop, List<Punt> geoPunten, int linksStraatnaamID, int rechtsStraatnaamID)
        {
            this.segmentID = segmentID;
            this.beginknoop = beginknoop;
            this.eindknoop = eindknoop;
            this.geoPunten = geoPunten;
            this.linksStraatnaamID = linksStraatnaamID;
            this.rechtsStraatnaamID = rechtsStraatnaamID;
        }
        public double berekenlengte()
        {
            double berekening = 0.0;

            for (int i = 1; i <this.geoPunten.Count; i++)
            {
                berekening += Math.Sqrt(Math.Pow(this.geoPunten[i].x - this.geoPunten[i - 1].x, 2) + Math.Pow(this.geoPunten[i].y - this.geoPunten[i - 1].y, 2));
            }
            return berekening;
        }

        public override bool Equals(object obj)
        {
            return obj is Segment segment &&
                   EqualityComparer<Knoop>.Default.Equals(beginknoop, segment.beginknoop) &&
                   EqualityComparer<Knoop>.Default.Equals(eindknoop, segment.eindknoop) &&
                   segmentID == segment.segmentID &&
                   EqualityComparer<List<Punt>>.Default.Equals(geoPunten, segment.geoPunten) &&
                   linksStraatnaamID == segment.linksStraatnaamID &&
                   rechtsStraatnaamID == segment.rechtsStraatnaamID;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(beginknoop, eindknoop, segmentID, geoPunten, linksStraatnaamID, rechtsStraatnaamID);
        }

    }
}
