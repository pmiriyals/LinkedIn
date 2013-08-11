using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace revcharrecur
{
    class Program
    {
        public static void rev(char[] s, int end)
        {
            if (end < s.Length)
            {
                rev(s, end + 1);
                if (s.Length - end - 1 < end)
                {
                    char c = s[end];
                    s[end] = s[s.Length - end - 1];
                    s[s.Length - end - 1] = c;
                }
            }
        }

        public static void reverse(char[] s)
        {
            int end = s.Length - 1;
            int start = 0;
            while (start < end)
            {
                char c = s[start];
                s[start++] = s[end];
                s[end--] = c;
            }
        }

        static void Main(string[] args)
        {
            char[] s = "Reverse this stringa".ToCharArray();
            reverse(s);
            Console.WriteLine(s);
            Console.ReadLine();
        }
    }
}
