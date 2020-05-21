    class CarProgram
    {
        static void Main(string[] args)
        {
            Car rakyan = new Car(10);
            
            rakyan.addFuel(5);
            rakyan.drive(10);

            Console.ReadLine();
        }
    }