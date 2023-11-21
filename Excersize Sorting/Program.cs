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

            /// https://leetcode.com/explore/learn/card/sorting/
            /// 

            //string[] words = { "we", "top", "are", "dic" };

            //Array.Sort(words, new MyComparer());

            //foreach(string w in words)
            //    Console.WriteLine(w);

            int[] arr = { 2, 0, 2, 1, 1, 0 };
            //int[] result = SelectionSort(arr);
            int[] result2 = BubbleSort(arr);


        }

        // selection Sort
        static public int[] SelectionSort(int[] arr)
        {
            int minIndex;

            for (int i = 0; i < arr.Length; i++)
            {
                minIndex = i;

                for (int j = i + 1; j < arr.Length; j++)
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

        public static void BubbleSort(int[] arr)
        {
            bool hasSwapped = true;

            while (hasSwapped)
            {
                hasSwapped = false;

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] > arr[i + 1])
                    {
                        int temp = arr[i];
                        arr[i] = arr[i + 1];
                        arr[i + 1] = temp;
                        hasSwapped = true;
                    }
                }
            }

        }

        // Buble Sort Mine
        public static int[] BubbleSortMine(int[] nums)
        {
            for (int i = 0; i < nums.Length - 1; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] > nums[j])
                    {
                        int temp = nums[i];
                        nums[i] = nums[j];
                        nums[j] = temp;
                    }
                }
            }

            return nums;
        }

    }
}
