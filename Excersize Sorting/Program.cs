using System.Collections;

namespace Excersize_Sorting
{

    internal class Program
    {
        public class MyComparer : IComparer<string>
        {
            public int Compare(string? x, string? y)
            {
                if (x.Length > y.Length)
                    return 1;
                else if (x.Length < y.Length)
                    return -1;
                return 0;

            }
        }

        static void Main(string[] args)
        {
            //string[] words = { "we", "top", "are", "dic" };

            //Array.Sort(words, new MyComparer());

            //foreach(string w in words)
            //    Console.WriteLine(w);

            int[] arr = { 5, 3, 1, 2, 4 };
            int[] result = SelectionSort(arr);


        }

        // selection Sort
        static public int[] SelectionSort(int[] arr)
        {
            int minIndex;

            for(int i = 0; i < arr.Length; i++)
            {
                minIndex = i;

                for(int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[minIndex])
                        minIndex = j;
                }

                int temp = arr[minIndex];
                arr[minIndex] = arr[i];
                arr[i] = temp;
            }

            return arr;
        }

        // Buble Sort
        
    }


}
