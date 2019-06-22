namespace MaximumSubarray.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[] { 13, -3, -25, 20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7 };

            var (a, b, c) = array.MaxSubArray(0, array.Length - 1);
        }
    }
}
