using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Reflection.Metadata;
using System.Security;

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
            int[] array2 = { 22, 50, 32, 28, 41, 12 };
            int[] result2 = BucketSort(array2, 5);

            //string[] array = { "102", "473", "251", "814" };
            //int[][] queries = [[1, 1], [2, 3], [4, 2], [1, 2]];

            //var resutlt = SmallestTrimmedNumbers(array, queries);

            //int[] SmallestTrimmedNumbers(string[] nums, int[][] queries)
            //{
            //    Dictionary<int, List<Pair>> map = new Dictionary<int, List<Pair>>();

            //    for (int i = 0; i < nums.Length; i++)
            //    {
            //        string str = nums[i];
            //        int n = str.Length;
            //        int l = n;
            //        for (int j = 0; j < n; j++)
            //        {
            //            if (!map.ContainsKey(l))
            //            {
            //                map[l] = new List<Pair>();
            //            }

            //            Pair pair = new Pair(str.Substring(j), i);
            //            map[l--].Add(pair);
            //        }
            //    }

            //    int[] ans = new int[queries.Length];
            //    int idx = 0;

            //    foreach (int[] query in queries)
            //    {
            //        int kthElement = query[0];
            //        int key = query[1];

            //        List<Pair> list = map[key];

            //        list.Sort((p1, p2) =>
            //        {
            //            if (p1.S.Equals(p2.S))
            //                return p1.Index - p2.Index;
            //            return string.Compare(p1.S, p2.S, StringComparison.Ordinal);
            //        });

            //        ans[idx++] = list[kthElement - 1].Index;
            //    }

            //    return ans;
            //}

        }

        //  Comparisson Sort

        // Selection Sort
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

                int temp = arr[i];
                arr[i] = arr[minIndex];
                arr[minIndex] = temp;
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
            foreach (int num in arr)
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

        // Insertion Sort
        static public int[] InsertionSort(int[] arr)
        {
            // is good for small array;
            // is good when input is very close to being sorted;

            //7, 3, 2, 5, 6, 10, 9, 8, 1 

            for (int i = 1; i < arr.Length; i++)
            {
                int curI = i;

                while (curI > 0 && arr[curI - 1] > arr[curI])
                {
                    int temp = arr[curI];
                    arr[curI] = arr[curI - 1];
                    arr[curI - 1] = temp;
                    curI--;
                }
            }

            return arr;
        }
        static void HeapSort(int[] arr)
        {
            for (int i = arr.Length / 2 - 1; i >= 0; i--)
            {
                MaxHeapify(arr, arr.Length, i);
            }

            for (int i = arr.Length - 1; i > 0; i--)
            {
                int temp = arr[i];
                arr[i] = arr[0];
                arr[0] = temp;
                MaxHeapify(arr, i, 0);
            }
        }

        public static void MaxHeapify(int[] arr, int heapSize, int index)
        {
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            int largest = index;
            if (left < heapSize && arr[left] > arr[largest])
            {
                largest = left;
            }
            if (right < heapSize && arr[right] > arr[largest])
            {
                largest = right;
            }
            if (largest != index)
            {
                int temp = arr[index];
                arr[index] = arr[largest];
                arr[largest] = temp;
                MaxHeapify(arr, heapSize, largest);
            }
        }

        // Non Comparisson Sort
        // CountingSort
        public static void CountingSort1(int[] arr)
        {
            // implementation of CodeCaza
            int MaxElement(int[] arr)
            {
                int maxElement = arr[0];

                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] > maxElement)
                        maxElement = arr[i];
                }

                return maxElement;
            }

            int maxElement = MaxElement(arr);

            int[] occurrences = new int[maxElement + 1];

            for (int i = 0; i < arr.Length; i++)
            {
                occurrences[arr[i]]++;
            }

            for (int i = 0, j = 0; i <= maxElement; i++)
            {
                while (occurrences[i] > 0)
                {
                    arr[j] = i;
                    j++;
                    occurrences[i]--;
                }
            }
        }
        public static void CountingSortLeetCode(int[] arr)
        {
            // implementation of leetcode
            int shift = arr.Min();
            int K = arr.Max() - shift;
            int[] counts = new int[K + 1];

            foreach (int elem in arr)
            {
                counts[elem - shift]++;
            }

            int startingIndex = 0;
            for (int i = 0; i < K + 1; i++)
            {
                int count = counts[i];
                counts[i] = startingIndex;
                startingIndex += count;
            }

            int[] sortedArray = new int[arr.Length];
            foreach (int elem in arr)
            {
                sortedArray[counts[elem - shift]] = elem;
                counts[elem - shift]++;
            }

            Array.Copy(sortedArray, arr, arr.Length);

        }

        public static IList<IList<int>> MinimumAbsDifference(int[] arr)
        {
            /*
                Given an array of distinct integers arr, find all pairs of elements with the minimum absolute difference of any two elements.
                Return a list of pairs in ascending order(with respect to pairs), each pair [a, b] follows
                a, b are from arr
                a < b
                b - a equals to the minimum absolute difference of any two elements in arr
             */
            int[] sortedArray = CountingSortLeetCode2(arr);

            IList<IList<int>> result = new List<IList<int>>();

            int minDiff = int.MaxValue;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int curDif = sortedArray[i + 1] - sortedArray[i];

                if (curDif < minDiff)
                {
                    result.Clear();
                    minDiff = curDif;
                }

                if (curDif == minDiff)
                    result.Add(new List<int> { sortedArray[i], sortedArray[i + 1] });
            }

            return result;
        }
        public static int[] CountingSortLeetCode2(int[] arr)
        {
            int shift = arr.Min();
            int K = arr.Max() - shift;
            int[] counts = new int[K + 1];

            foreach (int elem in arr)
            {
                counts[elem - shift]++;
            }

            int startingIndex = 0;
            for (int i = 0; i < K + 1; i++)
            {
                int count = counts[i];
                counts[i] = startingIndex;
                startingIndex += count;
            }

            int[] sortedArray = new int[arr.Length];
            foreach (int elem in arr)
            {
                sortedArray[counts[elem - shift]] = elem;
                counts[elem - shift]++;
            }

            Array.Copy(sortedArray, arr, arr.Length);

            return arr;
        }

        // Redix Sort

        public static int GetMaxVal(int[] array, int size)
        {
            var maxVal = array[0];
            for (int i = 1; i < size; i++)
                if (array[i] > maxVal)
                    maxVal = array[i];
            return maxVal;
        }

        public static int[] RadixSort(int[] array, int size)
        {
            var maxVal = GetMaxVal(array, size);

            for (int exponent = 1; maxVal / exponent > 0; exponent *= 10)
                CountingSort(array, size, exponent);
            return array;
        }

        public static void CountingSort(int[] array, int size, int exponent)
        {
            var outputArr = new int[size];
            var occurences = new int[10];
            for (int i = 0; i < 10; i++)
                occurences[i] = 0;
            for (int i = 0; i < size; i++)
                occurences[(array[i] / exponent) % 10]++;
            for (int i = 1; i < 10; i++)
                occurences[i] += occurences[i - 1];
            for (int i = size - 1; i >= 0; i--)
            {
                outputArr[occurences[(array[i] / exponent) % 10] - 1] = array[i];
                occurences[(array[i] / exponent) % 10]--;
            }
            for (int i = 0; i < size; i++)
                array[i] = outputArr[i];
        }

        // Radix Sort 

        public static int[] RadixSort2(int[] data)
        {
            int[] temp = new int[data.Length];

            for (int shift = 31; shift > -1; shift--)
            {
                int j = 0;

                for (int i = 0; i < data.Length; i++)
                {
                    bool move = (data[i] << shift) >= 0;

                    if (shift == 0 ? !move : move)
                    {
                        data[i - j] = data[i];
                    }
                    else
                    {
                        temp[j++] = data[i];
                    }
                }

                Array.Copy(temp, 0, data, data.Length - j, j);
            }

            return data;
        }

        //radix leet code
        //public void CountingSort(int[] arr, int placeVal)
        //{
        //    // Sorts an array of integers where the minimum value is 0 and the maximum value is NUM_DIGITS
        //    int[] counts = new int[10];

        //    foreach (int elem in arr)
        //    {
        //        int current = elem / placeVal;
        //        counts[current % 10] += 1;
        //    }

        //    // We now overwrite our original counts with the starting index
        //    // of each digit in our group of digits
        //    int startingIndex = 0;
        //    for (int i = 0; i < counts.Length; i++)
        //    {
        //        int count = counts[i];
        //        counts[i] = startingIndex;
        //        startingIndex += count;
        //    }

        //    int[] sortedArray = new int[arr.Length];
        //    foreach (int elem in arr)
        //    {
        //        int current = elem / placeVal;
        //        sortedArray[counts[current % 10]] = elem;
        //        // Since we have placed an item in the index counts[current % NUM_DIGITS],
        //        // we need to increment counts[current % NUM_DIGITS] index by 1 so the
        //        // next duplicate digit is placed in the appropriate index
        //        counts[current % 10] += 1;
        //    }

        //    // Common practice to copy over the sorted list into the original arr
        //    // It's fine to just return the sortedArray at this point as well
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        arr[i] = sortedArray[i];
        //    }
        //}

        //public void RadixSort(int[] arr)
        //{
        //    int maxElem = int.MinValue;
        //    foreach (int elem in arr)
        //    {
        //        if (elem > maxElem)
        //        {
        //            maxElem = elem;
        //        }
        //    }

        //    int placeVal = 1;
        //    while (maxElem / placeVal > 0)
        //    {
        //        CountingSort(arr, placeVal);
        //        placeVal *= 10;
        //    }
        //}

        //  Maximum Gap Mine Emplementation
        // https://leetcode.com/explore/learn/card/sorting/695/non-comparison-based-sorts/4491/
        static int MaximumGap(int[] nums)
        {

            if (nums.Length < 2)
                return 0;

            void BubbleSort(int[] arr)
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

            BubbleSort(nums);

            int maxGap = 0;

            for (int j = 1; j < nums.Length; j++)
            {
                if (nums[j] - nums[j - 1] > maxGap)
                    maxGap = nums[j] - nums[j - 1];
            }

            return maxGap;
        }
        static int MaximumGap2(int[] nums)
        {
            if (nums == null || nums.Length < 2)
                return 0;

            Array.Sort(nums);

            int maxGap = 0;

            for (int i = 1; i < nums.Length; i++)
            {
                int gap = nums[i] - nums[i - 1];
                maxGap = Math.Max(maxGap, gap);
            }

            return maxGap;
        }

        // Bucket Sort 
        static int[] BucketSort(int[] arr, int K)
        {
            List<List<int>> buckets = new List<List<int>>(K);

            int shift = arr.Min();
            int maxvalue = arr.Max() - shift;

            // Initialize buckets

            for (int i = 0; i < K; i++)
            {
                buckets.Add(new List<int>());
            }

            // Place elements into buckets

            double bucketSize = (double)maxvalue / K;

            if (bucketSize < 1)
                bucketSize = 1.0;

            foreach (int elem in arr)
            {
                int index = (int)((elem - shift) / bucketSize);

                if (index == K)
                    buckets[K - 1].Add(elem);
                else
                {
                    buckets[index].Add(elem);
                }
            }

            // Sort individual buckets

            foreach (List<int> bucket in buckets)
            {
                bucket.Sort();
            }

            // Convert sorted buckets into final output

            List<int> sortedList = new List<int>();

            foreach (List<int> bucket in buckets)
            {
                sortedList.AddRange(bucket);
            }

            // Mutate the original array with sorted elements 
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = sortedList[i];
            }

            return arr;

        }

        //Query Kth Smallest Trimmed Number


        public class Pair
        {
            public string S { get; }
            public int Index { get; }

            public Pair(string s, int index)
            {
                S = s;
                Index = index;
            }
        }





        // Kastet help me

        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode? next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public class Solution
        {
            public ListNode InsertionSortList(ListNode head)
            { //https://leetcode.com/explore/learn/card/sorting/694/comparison-based-sorts/4485/
                if (head == null || head.next == null)
                    return head;

                ListNode temp = head;

                while (temp != null)
                {
                    ListNode next = temp.next;
                    ListNode start = head;
                    ListNode prev = head;

                    while (start != next)
                    {
                        if (start.val > temp.val)
                        {
                            temp.next = start;
                            if (start == head)
                            {
                                head = temp;
                            }
                            else
                            {
                                prev.next = temp;
                            }
                            while (start.next != temp)
                            {
                                start = start.next;
                            }
                            start.next = next;
                        }

                        prev = start;
                        start = start.next;
                    }

                    temp = next;
                }

                return head;
            }
        }
    }
}

