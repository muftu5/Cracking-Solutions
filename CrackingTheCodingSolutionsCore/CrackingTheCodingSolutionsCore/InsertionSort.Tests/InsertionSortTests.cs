using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace InsertionSort.Tests
{
    [TestClass]
    public class InsertionSortTests
    {
        private readonly IFixture fixture = new Fixture();

        [TestMethod]
        public void Sort_ShouldReturnOrderedArray()
        {
            var size = 10000;
            var array = fixture.CreateMany<int>(10000).ToArray();

            int[] compareWith = new int[size];
            array.CopyTo(compareWith, 0);

            var ordered = compareWith.ToList().OrderBy(x => x).ToList();
            var result = array.InsertionSort();

            Assert.IsTrue(ordered.Zip(result, (x, y) => x == y).All(x => x));
        }
    }
}
