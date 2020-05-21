using System;

namespace Prac3._3
{
    class TestMyPolynomial
    {
        static void Main(string[] args)
        {
            double[] test_arr = {(double) 1, (double) 1};
            MyPolynomial test = new MyPolynomial(test_arr);
            Console.WriteLine("Current degree: " + test.GetDegree());
            Console.WriteLine(test.ToString());
            Console.WriteLine();

            MyPolynomial test2 = new MyPolynomial(test_arr);
            test = test.Multiply(test2);
            Console.WriteLine("Current degree: " + test.GetDegree());
            Console.WriteLine(test.ToString());
        }
    }
        class MyPolynomial
    {
        // Instance Variables
        int n; // Degree of polynomial
        double[] _coeffs; // Coefficients of n-degree polynomial

        public MyPolynomial(double[] coeffs)
        {
            _coeffs = coeffs;
            n = coeffs.Length - 1;
        }

        public int GetDegree()
        {
            return n;
        }

        public string ToString()
        {
            String[] equation = new String[n+1];
            String result = "";
            for (int i = n; i >= 0; i--)
            {
                if (i != 0 && i != 1)
                {
                    equation[i] = String.Concat(Convert.ToString(_coeffs[i]), "x^", Convert.ToString(i));
                }
                else if (i == 1)
                {
                    equation[i] = String.Concat(Convert.ToString(_coeffs[i]), "x");
                }
                else 
                {
                    equation[i] = String.Concat(Convert.ToString(_coeffs[i]));
                }
            }
            for (int i = n; i >= 0; i--)
            {
                result += equation[i];
                if (i != 0)
                {
                    result += " + ";
                }
            }
            return result;
        }

        public double Evaluate(double x)
        {
            double result = 0;
            for (int i = n; i >= 0; i--)
            {
                result += _coeffs[i]*(Math.Pow(x, i));
            }
            return result;
        }

        public MyPolynomial Add(MyPolynomial Another)
        {
            int m;
            if (n > Another.GetDegree())
            {
                m = n;
            }
            else
            {
                m = Another.GetDegree();
            }
            double[] coeffs_final = new double[m+1];
            
            for (int i = 0; i <= n; i++)
            {
                coeffs_final[i] = _coeffs[i];
            }
            for (int i = 0; i <= Another.GetDegree(); i++)
            {
                coeffs_final[i] += Another._coeffs[i];
            }
            
            MyPolynomial result = new MyPolynomial(coeffs_final);
            return result;
        }

        public MyPolynomial Multiply(MyPolynomial Another)
        {
            int size = n+Another.GetDegree();
            double[] coeffs_final = new double[size+1];
            for (int i = 0; i < size; i++)
            {
                coeffs_final[i] = 0;
            }
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= Another.GetDegree(); j++)
                {
                    coeffs_final[i+j] += _coeffs[i]*Another._coeffs[j];
                }
            }

            MyPolynomial result = new MyPolynomial(coeffs_final);
            return result;
        }
    }
}
