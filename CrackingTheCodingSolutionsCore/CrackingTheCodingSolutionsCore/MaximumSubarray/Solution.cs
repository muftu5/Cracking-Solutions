
using System;

namespace MaximumSubarray
{
    public static class Solution
    {
        /// <summary>
        /// A variable to explore recursion depth in console output.
        /// </summary>
        private static int RecursionDepth { get; set; }

        private static string Offset() => new string('\t', RecursionDepth);

        public static (int, int, int) MaxSubArray(
            this int[] A, int low, int high)
        {
            if (high == low)
            {
                Console.WriteLine($"High == low ({high} == {low})");
                return (low, high, A[low]);
            }
            else
            {
                var mid = (low + high) / 2;

                Console.WriteLine($"{Offset()}MaxSubArray (left) {low}:{mid} about to be called."); RecursionDepth++;

                var (leftLow, leftHigh, leftSum) = MaxSubArray(A, low, mid);

                Console.WriteLine($"{Offset()}LeftLow: {leftLow}, LeftHigh: {leftHigh}, LeftSum: {leftSum}"); RecursionDepth--;
                Console.WriteLine($"{Offset()}MaxSubArray (right) {mid + 1}:{high} about to be called."); RecursionDepth++;

                var (rightLow, rightHigh, rightSum) = MaxSubArray(A, mid + 1, high);

                Console.WriteLine($"{Offset()}RightLow: {rightLow}, RightHigh: {rightHigh}, RightSum: {rightSum}"); RecursionDepth--;
                Console.WriteLine($"{Offset()}MaxCrossingSubArray {low}:{mid}:{high} about to be called."); RecursionDepth++;

                var (crossLow, crossHigh, crossSum) = MaxCrossingSubArray(A, low, mid, high);

                Console.WriteLine($"{Offset()}CrossLow: {crossLow}, CrossHigh: {crossHigh}, CrossSum: {crossSum}"); RecursionDepth--;

                if (leftSum >= rightSum && leftSum >= crossSum)
                    return (leftLow, leftHigh, leftSum);
                else if (rightSum >= leftSum && rightSum >= crossSum)
                    return (rightLow, rightHigh, rightSum);
                else
                    return (crossLow, crossHigh, crossSum);
            }
        }

        private static (int, int, int) MaxCrossingSubArray(
            int[] A, int low, int mid, int high)
        {
            var leftSum = -int.MaxValue;
            var sum = 0;
            var maxLeft = 0;

            for (var i = mid; i >= low; i--)
            {
                sum += A[i];
                if (sum > leftSum)
                {
                    leftSum = sum;
                    maxLeft = i;
                }
            }

            var rightSum = -int.MaxValue;
            var maxRight = 0;
            sum = 0;

            for (var i = mid + 1; i <= high; i++)
            {
                sum += A[i];
                if (sum > rightSum)
                {
                    rightSum = sum;
                    maxRight = i;
                }
            }

            return (maxLeft, maxRight, leftSum + rightSum);
        }
    }
}
