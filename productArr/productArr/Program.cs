using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace productArr
{
    class Program
    {
        public static int[] product(int[] a)
        {
	        //1, 2, 3, 4, 5
	        //1, 1, 1*2, 1*2*3*5, 1*2*3*4


	        int[] prod = new int[a.Length];
	        int product = 1;

	        for(int i = 0; i < a.Length; i++)
	        {
		        prod[i] = product;
		        product *= a[i];
	        }

	        product = 1;

	        for(int i = a.Length-1; i>= 0; i--)
	        {
		        prod[i] *= product;
		        product	*= a[i];
	        }

	        foreach(int x in prod)
		        Console.Write(x + " ");
	        Console.ReadLine();
	        return prod;
        }
        
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5 };
            product(a);
        }
    }
}
