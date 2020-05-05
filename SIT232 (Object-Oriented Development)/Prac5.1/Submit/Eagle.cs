    class Eagle : Bird
    {
        private double wingSpan;

        public Eagle(String name, String diet, String location, double weight, int age, String color, String species, double wingSpan) 
        : base(name, diet, location, weight, age, color, species)
        {
            this.wingSpan = wingSpan;
        }
        
        public override void eat()
        {
            Console.WriteLine("I can eat 1lbs of fish");
        }
        public override void makeNoise()
        {
            Console.WriteLine("SCREEEEEEEECH");
        }

        public override void swim()
        {
            Console.WriteLine("Uh oh! I can't swim");
        }

        public override void layEgg()
        {
            // Code to allow the eagle to lay egg
            Console.WriteLine("I lay eggs for about 56 days");
        }

        public override void fly()
        {
            // Code to allow the eagle to fly
            Console.WriteLine("I can fly up to 50 miles per hour");
        }
    }