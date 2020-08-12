using System;

namespace Task01
{
    class TestPolynomial
    {
        static void Main(string[] args)
        {
            double[] a = new double[] { 1, 2, 3, 4, 5, 6 };
            MyPolynomial value = new MyPolynomial(a);

            Console.WriteLine(value.ToString());

            Console.WriteLine(string.Join(", ", value.GetCoeffs()));

            Console.WriteLine(value.GetDegree());

            Console.WriteLine(value.Evaluate(1));

            double[] b = new double[] { 6, 5, 4, 3, 2,1 };

            MyPolynomial value1 = new MyPolynomial(b);

            Console.WriteLine(value.Add(value1).ToString());

            Console.WriteLine(value.Multiply(value1).ToString());
        }
    }
}
