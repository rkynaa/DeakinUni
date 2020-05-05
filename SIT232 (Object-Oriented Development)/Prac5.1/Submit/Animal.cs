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

        public void eat()
        {
            // Code for the animal to eat
            Console.WriteLine("An animal eats");
        }

        public void sleep()
        {
            // Code for the animal to sleep
        }

        public void makeNoise()
        {
            // Code for the animal to make a noise
            Console.WriteLine("An animal makes a noise");
        }

        public void swim()
        {
            // Code for the animal to swim
            Console.WriteLine("An animal swims");
        }

        public void makeLionNoise()
        {
            // Code for the lion to roar
        }

        public void makeEagleVoice()
        {
            // Code for the eagle to cry
        }

        public void makeWolfVoice()
        {
            // Code for the wolf to howl
        }

        public void eatMeat()
        {
            // Code for the animal to eat meat
        }

        public void eatBerries()
        {
            // Code for the animal to eat berries
        }
    }