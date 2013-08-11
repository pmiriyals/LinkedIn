using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Randomize
{
    class Program
    {
        public static void swap(int[] a, int i, int j)
        {
	        int temp = a[i];
	        a[i] = a[j];
	        a[j] = temp;
        }

        public static void shuffle(int[] a)
        {
	        Random r = new Random();
	
	        for(int i = a.Length-1; i> 0; i--)
	        {
		        int j = r.Next(0, i+1);

		        swap(a, i, j);
	        }
	        foreach(int x in a)
		        Console.Write(x + " " );
	        Console.WriteLine();
        }

        public static void ReservoirSample(int[] a, int k)
        {
            int[] sample = new int[k];
            for (int i = 0; i < k; i++)
                sample[i] = a[i];

            Random r = new Random();

            for (int i = k; i < a.Length; i++)
            {
                int j = r.Next(0, i);
                if (j < k)
                    swap(a, j, i);
            }
            Console.WriteLine("Sample = ");
            foreach (int x in sample)
                Console.Write(x + " ");
            Console.WriteLine();
        }

        //select random number based on the fequency of occurrence gfg
        //select random from stream of numbers gfg

        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5 };
            shuffle(a);
            ReservoirSample(a, 1);
            Console.ReadLine();
        }
    }
}
