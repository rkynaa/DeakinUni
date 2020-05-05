    class Penguin : Bird
    {
        private double wingSpan;

        public Penguin(String name, String diet, String location, double weight, int age, String color, String species, double wingSpan) 
        : base(name, diet, location, weight, age, color, species)
        {
            this.wingSpan = wingSpan;
        }
        
        public override void eat()
        {
            Console.WriteLine("I can eat 13lbs of fish");
        }
        public override void makeNoise()
        {
            Console.WriteLine("SNEEEEZEEEE");
        }

        public override void swim()
        {
            Console.WriteLine("I can swim for 65 miles");
        }

        public override void layEgg()
        {
            // Code to allow the eagle to lay egg
            Console.WriteLine("I lay eggs for about 65 days");
        }

        public override void fly()
        {
            // Code to allow the eagle to fly
            Console.WriteLine("Uh oh! I can't fly");
        }

    }