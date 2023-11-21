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

            int[] arr = { 1, 1, 4, 2, 1, 3 };
            //int[] result = SelectionSort(arr);
            //int[] result2 = BubbleSort(arr);
            int result = HeightChecker(arr);


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

        public static int HeightCheckerMine(int[] arr)
        {

            int[] sortArr = new int[arr.Length];
            int counter = 0;
            foreach(int num in arr)
            {
                sortArr[counter++] = num;
            }

            bool hasSwapped = true;

            while (hasSwapped)
            {
                hasSwapped = false;

                for (int i = 0; i < sortArr.Length - 1; i++)
                {
                    if (sortArr[i] > sortArr[i + 1])
                    {
                        int temp = sortArr[i];
                        sortArr[i] = sortArr[i + 1];
                        sortArr[i + 1] = temp;
                        hasSwapped = true;
                    }
                }
            }

            counter = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != sortArr[i])
                    counter++;
            }

            return counter;
        }

        public int HeightChecker(int[] heights)
        {
            int res = 0;
            int curHeight = 0;
            int[] freq = new int[101];

            // time: 0(n);
            // space : o(1);

            foreach (var height in heights)
            {
                freq[height]++;
            }

            for (int i = 0; i < heights.Length; i++)
            {
                while (freq[curHeight] == 0)
                    curHeight++;

                if (curHeight != heights[i])
                    res++;

                freq[curHeight]--;
            }

            return res;
        }
    }
}
