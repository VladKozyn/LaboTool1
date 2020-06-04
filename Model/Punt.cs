using System;

namespace Tool1
{
   public class Punt
    {


        public double x { get; set; }
        public double y { get; set; }



        public Punt(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public override bool Equals(object obj)
        {
            return obj is Punt punt &&
                   x == punt.x &&
                   y == punt.y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }
    }
}
