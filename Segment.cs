using System.Collections.Generic;

namespace Tool1
{
    class Segment
    {
        public Knoop beginknoop { get; set; }
        public Knoop eindknoop { get; set; }
        public int segmentID { get; set; }
        public List<Punt> vertices { get; set; }

        public bool Equals(object X)
        {

        }
        public int GetHashCode()
        {

        }
        public Segment(int segmentID, Knoop beginknoop, Knoop eindknoop, List<Punt> vertices)
        {
            this.segmentID = segmentID;
            this.beginknoop = beginknoop;
            this.eindknoop = eindknoop;
            this.vertices = vertices;
        }
        public string ToString()
        {
            //            string Something = string.Join(" ", teruggave);
        }
    }
}
