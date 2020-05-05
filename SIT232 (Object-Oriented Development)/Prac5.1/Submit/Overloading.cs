    class Overloading
    {
        static void Main(string[] args)
        {
            methodToBeOverloaded("Rakyan");
            methodToBeOverloaded("Rakyan", 19);
        }

        public static void methodToBeOverloaded(String name)
        {
            Console.WriteLine("Name: " + name);
        }
        
        public static void methodToBeOverloaded(String name, int age)
        {
            Console.WriteLine("Name: " + name + "\nAge: " + age);
        }
    }