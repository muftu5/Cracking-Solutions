using System;
using System.Linq;
using Common.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RemoveDups.Tests
{
    [TestClass]
    public class RemoveDupsTests
    {
        [TestMethod]
        public void RemoveDuplicates_ShouldDoNothing_WhenElementsAreUnique()
        {
            var list = new SinglyLinkedList<int>();
            list.AppendHead(1);
            list.AppendHead(2);
            list.AppendHead(3);

            list.RemoveDuplicates();

            Assert.AreEqual(3, list.Enumerate().Count());
        }

        [TestMethod]
        public void RemoveDuplicates_ShouldRemoveSingleDuplicate_WhenItIsPresent()
        {
            var list = new SinglyLinkedList<int>();
            list.AppendHead(1);
            list.AppendHead(2);
            list.AppendHead(2);

            list.RemoveDuplicates();

            Assert.AreEqual(2, list.Enumerate().Count());
        }

        [TestMethod]
        public void RemoveDuplicates_ShouldRemoveMultipleDuplicates_WhenDuplicatesExist()
        {
            var list = new SinglyLinkedList<int>();
            list.AppendHead(2);
            list.AppendHead(2);
            list.AppendHead(2);

            list.RemoveDuplicates();

            Assert.AreEqual(1, list.Enumerate().Count());
        }
    }
}
