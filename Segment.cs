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
    }
}
