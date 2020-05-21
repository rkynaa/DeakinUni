    class Car
    {
        // Instance variables
        private double mpg, fuel, totalMiles;

        // VARIABLE
        private const double CURR_COST_PER_LITRE = 1.385;

        public Car(double mpg)
        {
            this.mpg = mpg;
            this.fuel = 0.0;
            this.totalMiles = 0.0;
        }

        // Accessor Methods
        public double getFuel()
        {
            return this.fuel;
        }
        public double getTotalMiles()
        {
            return this.totalMiles;
        }

        // Motator Methods
        public void setTotalMiles(double totalMiles)
        {
            this.totalMiles = totalMiles;
        }

        // Methods
        public String printFuelCost(double cost)
        {
            return cost.ToString("C");
        }
        public void addFuel(double addNewFuel)
        {
            this.fuel += convertToLitres(addNewFuel);
            calcCost(convertToLitres(addNewFuel));
        }
        public void calcCost(double fuel)
        {
            double cost = fuel * CURR_COST_PER_LITRE;
            Console.WriteLine("Total costs: " + printFuelCost(cost));
        }
        public double convertToLitres(double gallons)
        {
            double litres = gallons * 4.546;
            return litres;
        }
        public void drive(double miles)
        {
            double gallons = miles / mpg;
            double tempFuel = this.fuel - convertToLitres(gallons);
            if (tempFuel < 0) {
                Console.WriteLine("Error: car won't run for more than " + miles + " miles!");
                return;
            } else {
                Console.WriteLine("Acceptable!");
                double litres = convertToLitres(gallons);
                calcCost(litres);
            }
        }
    }