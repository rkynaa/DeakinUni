    class EmployeeProgram
    {
        static void Main(string[] args)
        {
            Employee mike = new Employee("Mike", 18700);

            Console.WriteLine("Employee name : " + mike.getName() + "\nSalary : " + mike.getSalary());

            Console.WriteLine();
            mike.raiseSalary(10);
            mike.tax();

            Console.ReadLine();
        }
    }