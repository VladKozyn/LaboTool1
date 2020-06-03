using System;

namespace Tool1
{
    public class Knoop
    {
        public int knoopID { get; set; }
        public Punt punt { get; set; }


        public Knoop(int knoopID, Punt punt)
        {
            this.knoopID = knoopID;
            this.punt = punt;

        }
    }
}
