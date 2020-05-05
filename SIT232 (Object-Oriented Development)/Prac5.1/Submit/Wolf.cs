    class Wolf : Animal
    {
        public Wolf(String name, String diet, String location, double weight, int age, String color) 
        : base(name, diet, location, weight, age, color)
        {

        }
        public override void eat()
        {
            Console.WriteLine("I can eat 10lbs of meat");
        }
        public override void makeNoise()
        {
            Console.WriteLine("HOWWWWWWWWWWLLLLLLLLL");
        }

        public override void swim()
        {
            Console.WriteLine("I can swim up to 8 miles");
        }
    }