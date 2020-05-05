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