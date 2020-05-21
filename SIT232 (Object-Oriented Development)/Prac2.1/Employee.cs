    class Employee
    {
        // Instance variable
        private String name;
        private double salary;

        // VARIABLES
        private const double TAX_PERCENTAGE_1 = 0.19;
        private const double TAX_PERCENTAGE_2 = 0.325;
        private const double TAX_PERCENTAGE_3 = 0.37;
        private const double TAX_PERCENTAGE_4 = 0.45;

        public Employee(String employeeName, double currentSalary){
            this.name = employeeName;
            this.salary = currentSalary;
        }

        // Accessor Methods
        public String getName()
        {
            return this.name;
        }
        public String getSalary()
        {
            return this.salary.ToString("C");
        }

        // Methods
        public void raiseSalary(double percentage)
        {
            this.salary += salary * (percentage/100);
            Console.WriteLine("Salary raised! New salary: " + getSalary());
        }
        public void tax()
        {
            double salaryTax = 0;
            if (this.salary >= 18201 && this.salary <= 37000)
            {
                salaryTax += (this.salary - 18200) * TAX_PERCENTAGE_1;
            }
            else if (this.salary >= 37001 && this.salary <= 90000)
            {
                salaryTax += 3572;
                salaryTax += (this.salary - 37000) * TAX_PERCENTAGE_2;
            }
            else if (this.salary >= 90001 && this.salary <= 180000)
            {
                salaryTax += 20737;
                salaryTax += (this.salary - 90000) * TAX_PERCENTAGE_3;
            }
            else if (this.salary >= 180001)
            {
                salaryTax += 54096;
                salaryTax += (this.salary - 18000) * TAX_PERCENTAGE_4;
            }
            Console.WriteLine("Total tax amount: " + salaryTax.ToString("C"));
        }
    }