using System;
using System.Collections.Generic;
using System.Text;

namespace Task01
{
    class MyPolynomial
    {
        private double[] _coeffs;

        public MyPolynomial(double[] coeffs)
        {
            this._coeffs = coeffs;
        }

        public int GetDegree()
        {
            return _coeffs.Length - 1;
        }

        public double[] GetCoeffs()
        {
            return _coeffs;
        }

        public String ToString()
        {
            string a = "";
            for (int i = _coeffs.Length - 1; i >= 0; i--)
            {
                a += (_coeffs[i] + (i != 0 ? "*x^" + i + " + " : ""));
            }

            return a;
        }

        public double Evaluate(double x)
        {
            double sum = 0.0;
            double item = 1.0;
            for (int i = 0; i < _coeffs.Length; i++)
            {
                item *= (i == 0 ? 1.0 : x);
                sum += item * _coeffs[i];
            }
            return sum;
        }

        public MyPolynomial Add(MyPolynomial another)
        {
            MyPolynomial final = this;
            //get the biggest array
            if (final.GetDegree() < another.GetDegree())
            {
                final = another;
                another = this;
            }

            double[] resultCoeffs = final.GetCoeffs();
            double[] anotherCoeffs = another.GetCoeffs();

            // use the longest array for check all elements
            for (int i = 0; i < resultCoeffs.Length; i++)
            {
                if (i <= anotherCoeffs.Length - 1)
                {
                    resultCoeffs[i] += anotherCoeffs[i];
                }
            }
            //return result as new MyPolynomial
            return new MyPolynomial(resultCoeffs);
        }

        public MyPolynomial Multiply(MyPolynomial another)
        {
            double[] resultCoeffs = new double[this.GetDegree() + another.GetDegree() + 1];
            double[] anotherCoeffs = another.GetCoeffs();

            for (int i = 0; i < resultCoeffs.Length; i++)
            {
                double tmp = 0.0;
                for (int a = 0; a <= i; a++)
                {
                    if (a <= _coeffs.Length - 1)
                    {
                        if (i - a <= anotherCoeffs.Length - 1)
                        {
                            tmp += _coeffs[a] * anotherCoeffs[i - a];
                        }
                    }
                }
                resultCoeffs[i] = tmp;
            }
            return new MyPolynomial(resultCoeffs);
        }
    }
}
