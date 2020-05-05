using System;

namespace Task01
{
    class ZooPark
    {
        static void Main(string[] args)
        {
            // Animal williamWolf = new Animal("William the Wolf", "Meat", "Dog Village", 50.6, 9, "Grey");
            // Animal tonyTiger = new Animal("Tony the Tiger", "Meat", "Cat Land", 110, 6, "Orange and White");
            // Animal edgarEagle = new Animal("Edgar the Eagle", "Fish", "Bird Mania", 20, 5, "Black");

            Animal baseAnimal = new Animal("Animal name", "Animal diet", "Animal location", 0.0, 0, "Animal color");

            Wolf williamWolf = new Wolf("William the Wolf", "Meat", "Dog Village", 50.6, 9, "Grey");
            Tiger tonyTiger = new Tiger("Tony the Tiger", "Meat", "Cat Land", 110, 6, "Orange and White", "Siberian", "White");
            Eagle edgarEagle = new Eagle("Edgar the Eagle", "Fish", "Bird Mania", 20, 5, "Black", "Harpy", 98.5);
            Penguin privatePenguin = new Penguin("Private the Penguin", "Fish", "Penguin Iceland", 99, 4, "Black, Yellow and white", "Emperor", 30);

            // Comparing eat function
            baseAnimal.eat();
            tonyTiger.eat();
            edgarEagle.eat();
            williamWolf.eat();
            privatePenguin.eat();
            Console.WriteLine();

            // Comparing makeNoise function
            baseAnimal.makeNoise();
            tonyTiger.makeNoise();
            edgarEagle.makeNoise();
            williamWolf.makeNoise();
            privatePenguin.makeNoise();
            Console.WriteLine();

            // Comparing swim function
            baseAnimal.swim();
            tonyTiger.swim();
            edgarEagle.swim();
            williamWolf.swim();
            privatePenguin.swim();
            Console.WriteLine();

            // Comparing fly function (for bird class)
            edgarEagle.fly();
            privatePenguin.fly();
            Console.WriteLine();
        }
    }

    class Animal
    {
        private String name;
        private String diet;
        private String location;
        private double weight;
        private int age;
        private String color;

        public Animal(String name, String diet, String location, double weight, int age, String color)
        {
            this.name = name;
            this.diet = diet;
            this.location = location;
            this.weight = weight;
            this.age = age;
            this.color = color;
        }

        public virtual void eat()
        {
            // Code for the animal to eat
            Console.WriteLine("An animal eats");
        }

        public virtual void sleep()
        {
            // Code for the animal to sleep
        }

        public virtual void makeNoise()
        {
            // Code for the animal to make a noise
            Console.WriteLine("An animal makes a noise");
        }

        public virtual void swim()
        {
            // Code for the animal to swim
            Console.WriteLine("An animal swims");
        }

        // public void makeLionNoise()
        // {
        //     // Code for the lion to roar
        // }

        // public void makeEagleVoice()
        // {
        //     // Code for the eagle to cry
        // }

        // public void makeWolfVoice()
        // {
        //     // Code for the wolf to howl
        // }

        // public void eatMeat()
        // {
        //     // Code for the animal to eat meat
        // }

        // public void eatBerries()
        // {
        //     // Code for the animal to eat berries
        // }
    }
}
