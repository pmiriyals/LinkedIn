using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IsInt
{
    class Program
    {
        static double isInt(string s)
        {
            int i = 0;

            while (i < s.Length && s[i] == ' ' || s[i] == '\t')
                i++;

            if (i >= s.Length)
                return -1;

            int sign = (s[i] == '-' ? -1 : 1);            
            
            if (s[i] == '+' || s[i] == '-')
                i++;

            int num, power = 1;
            for (num = 0; i < s.Length && s[i] >= '0' && s[i] <= '9'; i++)
            {
                num = num*10 + s[i] - '0';
            }
            if (i < s.Length && s[i] == '.')
                for (power = 1, i++; i < s.Length && s[i] >= '0' && s[i] <= '9'; i++)
                {
                    num = 10 * num + s[i] - '0';
                    power = power * 10;
                }

            return (double)num * sign / power;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(isInt("   +1213.1213"));
            Console.ReadLine();
        }
    }
}
