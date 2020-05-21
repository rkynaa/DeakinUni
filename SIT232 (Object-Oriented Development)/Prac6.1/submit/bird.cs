    // Base class -> Bird
    class Bird
    {
        // Instance property (with a get-set function)
        public String name { get; set; }

        // Construction function
        public Bird()
        {

        }

        // Virtual function fly()
        public virtual void fly()
        {
            Console.WriteLine("Flap, flap, flap");
        }

        // Overridden function ToString() (from System.ToString() function)
        public override String ToString()
        {
            return "A bird called " + name;
        }

    }

