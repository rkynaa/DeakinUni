using System;
namespace Task01
{
    class Feline : Animal
    {
        private String species;
        public Feline(String name, String diet, String location, double weight, int age, String color, String species) 
        : base(name, diet, location, weight, age, color)
        {
            this.species = species;
        }
        public override void sleep()
        {
            // Code for the feline animal to sleep
        }
    }

    class Bird : Animal
    {
        private String species;

        public Bird(String name, String diet, String location, double weight, int age, String color, String species) 
        : base(name, diet, location, weight, age, color)
        {
            this.species = species;
        }
        public virtual void layEgg()
        {
            // Code to allow the bird animal to lay egg
            Console.WriteLine("A bird laying its egg");
        }

        public virtual void fly()
        {
            // Code to allow the bird animal to fly
            Console.WriteLine("A bird flies");
        }
    }

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
}