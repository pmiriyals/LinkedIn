using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuickSort
{
    class Program
    {
        public static void quicksort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivot = low + (high - low) / 2;
                pivot = partition(arr, low, pivot, high);
                quicksort(arr, low, pivot - 1);
                quicksort(arr, pivot + 1, high);
            }
        }

        private static void swap(int[] arr, int x, int y)
        {
            arr[x] = arr[x] ^ arr[y];
            arr[y] = arr[x] ^ arr[y];
            arr[x] = arr[x] ^ arr[y];
        }

        public static int partition(int[] arr, int left, int right, int pivotIndex)
        {
            int pivot = arr[pivotIndex];
            int storeIndex = left;
            int i;
            swap(arr, pivotIndex, right); 
            for(i = left; i < right; i++)
            {
                if(arr[i] <= pivot)
                {
                swap(arr, i, storeIndex);
                storeIndex += 1;
                } 
            }
            swap(arr, storeIndex, right);
            return storeIndex;
        }

        
        static void Main(string[] args)
        {
            int[] arr = { 2, 7, 1, 8, 10 };
            quicksort(arr, 0, arr.Length - 1);
            foreach (int i in arr)
                Console.WriteLine(" {0} ", i);
            Console.ReadLine();
        }
    }
}
