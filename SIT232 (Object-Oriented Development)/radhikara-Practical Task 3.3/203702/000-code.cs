    class TestMyPolynomial
    {
        static void Main(string[] args)
        {
            double[] test_arr = {(double) 1, (double) 2, (double) 3};
            MyPolynomial test = new MyPolynomial(test_arr);
            Console.WriteLine("Current degree: " + test.GetDegree());
            Console.WriteLine(test.ToString());
        }
    }