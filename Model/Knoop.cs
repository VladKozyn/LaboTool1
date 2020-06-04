using System;
using System.Collections.Generic;

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

        public override bool Equals(object obj)
        {
            return obj is Knoop knoop &&
                   knoopID == knoop.knoopID &&
                   EqualityComparer<Punt>.Default.Equals(punt, knoop.punt);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(knoopID, punt);
        }
    }
}
