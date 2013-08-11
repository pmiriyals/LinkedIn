using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CoinChange
{
    class Program
    {
        public static int makechange(int n, int denom)
        {            
            int next_denom = 0;

            switch (denom)
            {
                case 25: next_denom = 10;
                    break;

                case 10: next_denom = 5;
                    break;

                case 5: next_denom = 1;
                    break;

                case 1: return 1;
            }

            int ways = 0;

            for (int i = 0; i * denom <= n; i++)
            {
                ways += makechange(n - (i * denom), next_denom);
            }
            return ways;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(makechange(10, 25));
            Console.ReadLine();
        }
    }
}
