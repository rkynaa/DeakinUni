using System;
using System.Collections.Generic;

namespace Task01
{
    class Program
    {
        // Main function
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello World!");

            // Task 01
            // Bird
            // Creating bird1 and bird2
            Bird bird1 = new Bird();
            Bird bird2 = new Bird();

            // Set the name for bird1 and bird2
            bird1.name = "Feathers";
            bird2.name = "Polly";

            // Use the ToString() and fly()
            // From bird1
            Console.WriteLine(bird1.ToString());
            bird1.fly();
            
            // From bird2
            Console.WriteLine(bird2.ToString());
            bird2.fly();

            Console.WriteLine();

            // Penguin
            // Creating penguin1 and penguin2
            Penguin penguin1 = new Penguin();
            Penguin penguin2 = new Penguin();

            // Set the name for penguin1 and penguin2
            penguin1.name = "Happy Feet";
            penguin2.name = "Gloria";

            // Use the ToString() and fly()
            // From bird1
            Console.WriteLine(penguin1.ToString());
            penguin1.fly();
            
            // From bird2
            Console.WriteLine(penguin2.ToString());
            penguin2.fly();

            Console.WriteLine();

            // Duck
            // Creating duck1 and duck2
            Duck duck1 = new Duck();
            Duck duck2 = new Duck();

            // Set the properties
            // for duck1
            duck1.name = "Daffy";
            duck1.size = 15;
            duck1.kind = "Mallard";

            // for duck2
            duck2.name = "Donald";
            duck2.size = 20;
            duck2.kind = "Decoy";

            // Use the ToString() and fly()
            // From bird1
            Console.WriteLine(duck1.ToString());
            
            // From bird2
            Console.WriteLine(duck2.ToString());

            Console.WriteLine();

            // Task 02
            // // List of birds
            // // Creating an empty list of birds
            // List<Bird> birds = new List<Bird>();
            
            // // For birds
            // // Creating bird1 and bird2
            // Bird bird1 = new Bird();
            // Bird bird2 = new Bird();

            // // Set the name for bird1 and bird2
            // bird1.name = "Feathers";
            // bird2.name = "Polly";

            // // For penguins
            // // Creating penguin1 and penguin2
            // Penguin penguin1 = new Penguin();
            // Penguin penguin2 = new Penguin();

            // // Set the name for penguin1 and penguin2
            // penguin1.name = "Happy Feet";
            // penguin2.name = "Gloria";
            
            // // for ducks
            // // Creating duck1 and duck2
            // Duck duck1 = new Duck();
            // Duck duck2 = new Duck();

            // // Set the properties
            // // for duck1
            // duck1.name = "Daffy";
            // duck1.size = 15;
            // duck1.kind = "Mallard";

            // // for duck2
            // duck2.name = "Donald";
            // duck2.size = 20;
            // duck2.kind = "Decoy";

            // // Adding all the birds into the list
            // birds.Add(bird1);
            // birds.Add(bird2);
            // birds.Add(penguin1);
            // birds.Add(penguin2);
            // birds.Add(duck1);
            // birds.Add(duck2);

            // Adding a new bird named "birdy"
            // birds.Add(new Bird(Name = "Birdy"));

            // Printing all the birds
            // foreach (Bird bird in birds)
            // {
            //     Console.WriteLine(bird);
            // }

            // Task 03
            // // Covariance
            // // for ducks
            // // Creating duck1 and duck2
            // Duck duck1 = new Duck();
            // Duck duck2 = new Duck();

            // // Set the properties
            // // for duck1
            // duck1.name = "Daffy";
            // duck1.size = 15;
            // duck1.kind = "Mallard";

            // // for duck2
            // duck2.name = "Donald";
            // duck2.size = 20;
            // duck2.kind = "Decoy";

            // // Creating lists of ducks with duck1 and duck2 as members
            // List<Duck> ducksToAdd = new List<Duck>()
            // {
            //     duck1,
            //     duck2,
            // };

            // // creaing IEnumerable of Bird
            // IEnumerable<Bird> upcastDucks = ducksToAdd;

            // // Creating an empty list of bird
            // List<Bird> birds = new List<Bird>();

            // // Adding a bird and name it "Feather"
            // birds.Add(new Bird(){ name = "Feather" });

            // // Adding the ducks to the list
            // birds.AddRange(upcastDucks);

            // // Printing all the birds
            // foreach (Bird bird in birds)
            // {
            //     Console.WriteLine(bird);
            // }
        }
    }

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
