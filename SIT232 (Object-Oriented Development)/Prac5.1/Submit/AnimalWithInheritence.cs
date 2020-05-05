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
    }