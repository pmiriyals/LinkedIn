using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace log2n
{
    class Program
    {
        public static int log2n(int n)
        {
            return n < 2 ? 0 : log2n(n / 2) + 1;
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine(log2n(3));
            Console.ReadLine();
        }
    }
}
