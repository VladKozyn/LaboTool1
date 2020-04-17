using System.Collections.Generic;

namespace Tool1
{
    class Graaf
    {
        public int graafID { get; set; }
        public Dictionary<Knoop, List<Segment>> map { get; set; }


        public static Graaf buildGraaf(int graafID, Dictionary<Knoop, List<Segment>> map)
        {
            
        }
        public List<Knoop> getKnopen()
        {

        }
        public Graaf(int graafID)
        {
            this.graafID = graafID;
        }
        public void showGraaf()
        {

        }
    }
}
