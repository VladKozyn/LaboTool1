namespace Tool1
{
    class Knoop
    {
        public int knoopID { get; set; }
        public Punt punt { get; set; }

        public bool Equals(object X)
        {

        }
        public int GetHashCode()
        {

        }
        public Knoop(int knoopID, Punt punt)
        {
            this.knoopID = knoopID;
            this.punt = punt;
        }
        public string ToString()
        {

        }
    }
}
