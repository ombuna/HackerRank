using System;
using System.Runtime.InteropServices;

namespace HackerRank
{
    internal class MergeSort
    {
        public static int[] mergeSort(int[] arr)
        {
            if (arr.Length <= 1) return arr;
            int mid = arr.Length / 2;
            int[] left = new int[mid];
            int[] right = new int[arr.Length % 2 == 0 ? mid : mid + 1];
            int[] result = new int[arr.Length];

            for (int i = 0; i < mid; i++)
            {
                left[i] = arr[i];
            }
            int x = 0;
            for (int i = mid; i < arr.Length; i++)
            {
                right[x] = arr[i];
                x++;
            }
            left = mergeSort(left);
            right = mergeSort(right);
            result = merge(left, right);
            return result;
        }

        private static int[] merge(int[] left, int[] right)
        {
            int resultLength = left.Length + right.Length;
            int[] result = new int[resultLength];

            int indexLeft = 0, indexRight = 0, indexResult = 0;
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    if (left[indexLeft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexResult++;
                        indexLeft++;
                    }
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexResult++;
                        indexRight++;
                    }
                }
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexResult++;
                    indexLeft++;
                }
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexResult++;
                    indexRight++;
                }
            }
            return result;
        }
    }
}