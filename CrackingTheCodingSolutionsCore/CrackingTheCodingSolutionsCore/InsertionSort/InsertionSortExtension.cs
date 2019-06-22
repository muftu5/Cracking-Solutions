using System;

namespace InsertionSort
{
    public static class InsertionSortExtension
    {
        public static int[] InsertionSort(this int[] A)
        {
            for (var j = 1; j < A.Length; j++)
            {
                var key = A[j];
                var i = j - 1;

                while (i >= 0 && A[i] > key)
                {
                    A[i + 1] = A[i];
                    i = i - 1;
                }

                A[i + 1] = key;
            }

            return A;
        }
    }
}
