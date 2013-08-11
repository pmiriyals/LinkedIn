using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pow
{
    class Program
    {
        public static double pow(double x, int y)
        {
            if (y == 0)
                return 1;

            double temp = pow(x, y / 2);

            if (y % 2 == 0)
                return temp * temp;
            else
            {
                if (y < 0)
                {
                    return temp * temp / x;
                }
                else
                    return temp * temp * x;
            }
        }

        public static double squareroot(double n)
        {
            double x = n;
            double y = 1;
            double e = 0.0000001;

            while (x - y > e)
            {
                x = (x + y) / 2;
                y = n / x;
            }
            return x;
        }


        static void Main(string[] args)
        {
            Console.WriteLine(pow(3, -2));
            Console.WriteLine(squareroot(2));
            Console.ReadLine();
        }
    }
}
