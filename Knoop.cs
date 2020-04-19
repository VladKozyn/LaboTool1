using System;

namespace Tool1
{
    class Knoop
    {
        public int knoopID { get; set; }
        public Punt punt { get; set; }


        public Knoop(int knoopID, Punt punt)
        {
            this.knoopID = knoopID;
            this.punt = punt;
            knoopID++;
        }
    }
}
