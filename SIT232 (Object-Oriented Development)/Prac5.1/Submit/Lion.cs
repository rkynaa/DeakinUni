    class Lion : Feline
    {
        public Lion(String name, String diet, String location, double weight, int age, String color, String species)
        : base (name, diet, location, weight, age, color, species)
        {

        }
        public override void eat()
        {
            Console.WriteLine("I can eat 25lbs of meat");
        }
        public override void makeNoise()
        {
            Console.WriteLine("ROARRRRRRRRRR");
        }

        public override void swim()
        {
            Console.WriteLine("I can swim up to 2 miles");
        }
    }