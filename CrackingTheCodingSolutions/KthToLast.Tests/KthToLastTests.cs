using AutoFixture;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RemoveDups;
using System;
using System.Linq;

namespace KthToLast.Tests
{
    [TestClass]
    public class KthToLastTests
    {
        private LinkedList<int> list;
        private Fixture fixture = new Fixture();

        [TestInitialize]
        public void Initialize()
        {
            list = new LinkedList<int>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetKthLast_ShouldThrowArgumentException_WhenKIsOutOfRange()
        {
            list.GetKthLast(int.MaxValue);
        }

        [TestMethod]
        public void GetKthLast_ShouldReturnKthLastElement_BigExample()
        {
            var numberOfElementsInList = 1000;
            var array = fixture.CreateMany<int>(numberOfElementsInList).ToArray();

            foreach (var item in array)
                list.AppendHead(item);

            var k = fixture.Create<Generator<int>>()
                .First(x => x > 0 && x < numberOfElementsInList);

            var kthElement = list.GetKthLast(k);

            Assert.AreEqual(array[array.Length - k - 1], kthElement);
            Assert.AreNotSame(default(int), kthElement);
        }

        [TestMethod]
        public void GetKthLast_ShouldReturnFirstElement_WhenKIsMaximum()
        {
            var numberOfElementsInList = 1000;
            var array = fixture.CreateMany<int>(numberOfElementsInList).ToArray();

            foreach (var item in array)
                list.AppendHead(item);

            var k = numberOfElementsInList - 1;
            var kthElement = list.GetKthLast(k);

            Assert.AreEqual(array.First(), kthElement);
            Assert.AreNotSame(default(int), kthElement);
        }

        [TestMethod]
        public void GetKthLast_ShouldReturnHead_WhenKIsZero()
        {
            var numberOfElementsInList = 1000;
            var array = fixture.CreateMany<int>(numberOfElementsInList).ToArray();

            foreach (var item in array)
                list.AppendHead(item);

            var k = 0;
            var kthElement = list.GetKthLast(k);

            Assert.AreEqual(array.Last(), kthElement);
            Assert.AreNotSame(default(int), kthElement);
        }
    }
}
