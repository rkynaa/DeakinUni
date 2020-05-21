    // Subclass -> Penguin
    // Inheritence from Bird (base class)
    class Penguin : Bird
    {
        // Overridden function fly() (from Bird (base class))
        public override void fly()
        {
            Console.WriteLine("Penguins cannot fly");
        }

        // Overridden function ToString() (from Bird.ToString() function)
        public override String ToString()
        {
            return "A penguin called " + base.name;
        }
    }

