using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

            /// https://leetcode.com/explore/learn/card/sorting/

            //string[] words = { "we", "top", "are", "dic" };

            //Array.Sort(words, new MyComparer());

            //foreach(string w in words)
            //    Console.WriteLine(w);

            int[] array = { 5,3,2,1,4 };

            CountingSort(array);


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
        public static void CountingSort(int[] arr)
        {
            int MaxElement(int[] arr)
            {
                int maxElement = arr[0];

                for(int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] > maxElement)
                        maxElement = arr[i];
                }

                return maxElement;
            }

            int maxElement = MaxElement(arr);

            int[] occurrences = new int[maxElement + 1];

            for(int i = 0; i < arr.Length; i++)
            {
                occurrences[arr[i]]++;
            }

            for(int i = 0, j = 0; i <= maxElement; i++)
            {
                while (occurrences[i] > 0)
                {
                    arr[j] = i;
                    j++;
                    occurrences[i]--;
                }
            }
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

            while(temp != null)
            {
                ListNode next = temp.next;
                ListNode start = head;
                ListNode prev = head;

                while(start != next)
                {
                    if(start.val > temp.val)
                    {
                        temp.next = start;
                        if(start == head)
                        {
                            head = temp;
                        }
                        else
                        {
                            prev.next = temp;
                        }
                        while(start.next != temp)
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
