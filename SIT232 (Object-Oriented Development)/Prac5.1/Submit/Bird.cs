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