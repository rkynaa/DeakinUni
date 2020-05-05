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

        MyPolynomial Add(MyPolynomial Another)
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
            double[] coeffs_final = new double[m];
            
            for (int i = 0; i < n; i++)
            {
                coeffs_final[i] = _coeffs[i];
            }
            for (int i = 0; i < Another.GetDegree(); i++)
            {
                coeffs_final[i] = Another._coeffs[i];
            }
            
            MyPolynomial result = new MyPolynomial(coeffs_final);
            return result;
        }

        MyPolynomial Multiply(MyPolynomial Another)
        {
            int size = n+Another.GetDegree()-1;
            double[] coeffs_final = new double[size];
            for (int i = 0; i < size; i++)
            {
                coeffs_final[i] = 0;
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < Another.GetDegree(); j++)
                {
                    coeffs_final[i+j] += _coeffs[i]*Another._coeffs[j];
                }
            }

            MyPolynomial result = new MyPolynomial(coeffs_final);
            return result;
        }
    }