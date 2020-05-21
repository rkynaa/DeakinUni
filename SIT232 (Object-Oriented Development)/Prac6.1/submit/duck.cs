    // Subclass -> Duck
    // Inheritence from Bird (base class)
    class Duck : Bird
    {
        // Instance properties (with a get-set function)
        public double size { get; set; }
        public String kind { get; set; }


        // Overridden function ToString() (from Bird.ToString() function)
        public override String ToString()
        {
            return "A duck called " + base.name + " is a " + size + " inch " + kind;
        }
    }
}
