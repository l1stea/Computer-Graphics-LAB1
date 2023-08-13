using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB1
{
    public class Complex
    {
        public decimal X { get; set; }
        public decimal Y { get; set; }

        public decimal MagnitudeSQ
        {
            get
            {
                return X * X + Y * Y;
            }
        }

        public Complex()
        {
            X = 0;
            Y = 0;
        }

        public Complex(decimal x, decimal y)
        {
            X = x;
            Y = y;
        }

        public Complex(Complex C)
        {
            X = C.X;
            Y = C.Y;
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            return new Complex(c1.X + c2.X, c1.Y + c2.Y);
        }

        public static Complex operator *(Complex c1, Complex c2)
        {
            return new Complex(c1.X * c2.X - c1.Y * c2.Y, c1.X * c2.Y + c2.X * c1.Y);
        }
    }
}
