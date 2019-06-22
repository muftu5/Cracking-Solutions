using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace MaximumSubarray.Tests
{
    [TestClass]
    public class MaximumSubarrayTests
    {
        [TestMethod]
        public void MaxSubArray_ShouldReturnMaxSubarray()
        {
            var array = new int[] { 13, -3, -25, 20, -3, -16, -23, 18, 20, -7, 12, -5, -22, 15, -4, 7 };

            var (a, b, c) = array.MaxSubArray(0, array.Length - 1);

            Assert.AreEqual(43, c);
            Assert.AreEqual(7, a);
            Assert.AreEqual(10, b);
        }
    }
}
