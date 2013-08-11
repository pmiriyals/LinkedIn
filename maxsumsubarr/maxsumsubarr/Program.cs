using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace maxsumsubarr
{
    class Program
    {
        public static int maxSubSum(int[] a)
        {
            int maxfoundsofar = 0;
            int maxtillhere = 0;
            bool isallneg = true;
            int min = int.MinValue;

            int i = 0;
            while (i < a.Length)
            {
                maxtillhere += a[i];

                if (maxtillhere < 0)
                {
                    maxtillhere = 0;
                    if (isallneg && a[i] > min)
                        min = a[i];
                }
                else
                    isallneg = false;

                if (maxfoundsofar < maxtillhere)
                    maxfoundsofar = maxtillhere;
                i++;
            }
            return isallneg ? min : maxfoundsofar;
        }

        static void Main(string[] args)
        {
            int[] a = { -3, -2, -2, -6, -5, -1, -3, -1 };
            Console.WriteLine(maxSubSum(a));
            Console.ReadLine();
        }
    }
}
