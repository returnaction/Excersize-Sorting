


using Microsoft.VisualBasic.FileIO;
using System.ComponentModel.Design;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 2, 3, 5, 1, 4 };

            // BubbleSort 1, 2, 3, 4, 5

            BubbleSort(arr);
        }

        private static void BubbleSort(int[] arr)
        {
            bool swapped = true;

            while (swapped)
            {
                swapped = false;

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        swapped = true;
                    }
                }
            }
        }
    }
}






















// SelectionSort
// Time Complexity Big O(n squared);
// Space Complexity Big O(1) 