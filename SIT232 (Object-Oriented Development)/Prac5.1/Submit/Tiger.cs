    class Tiger : Feline
    {
        private String colorStripes;

        public Tiger(String name, String diet, String location, double weight, int age, String color, String species, String colorStripes) 
        : base(name, diet, location, weight, age, color, species)
        {
            this.colorStripes = colorStripes;
        }

        public override void eat()
        {
            Console.WriteLine("I can eat 20lbs of meat");
        }
        public override void makeNoise()
        {
            Console.WriteLine("ROARRRRRRRRRR");
        }

        public override void swim()
        {
            Console.WriteLine("I can swim up to 18 miles");
        }
    }