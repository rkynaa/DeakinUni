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