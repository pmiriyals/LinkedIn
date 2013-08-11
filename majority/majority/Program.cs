using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace majority
{
    class Program
    {
        public static int majority(int[] arr)
        {
            if (arr.Length < 0)
                return -1;

            int count = 1;
            int maj = arr[0];
            int ndx = 1;
            while (ndx < arr.Length)
            {
                if (arr[ndx] == maj)
                    count++;
                else
                {
                    count--;
                    if (count == 0)
                    {
                        maj = arr[ndx];
                        count = 1;
                    }
                }
                ndx++;
            }

            return ismajority(arr, maj) ? maj  : -1;
        }

        public static bool ismajority(int[] arr, int maj)
        {
            int cnt = 0;
            foreach (int i in arr)
            {
                if (i == maj)
                    cnt++;
            }

            return (cnt > (arr.Length / 2));
        }
        
        static void Main(string[] args)
        {
            int[] arr = {3, 1, 3, 6, 3, 2, 3, 2, 3, 1, 3 };
            Console.WriteLine("Majority element = {0}", majority(arr));
            Console.ReadLine();
        }
    }
}
