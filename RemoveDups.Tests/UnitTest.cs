using System;
using System.Linq;
using Common.DataStructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RemoveDups.Tests
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void Test1()
        {
            var list = new SinglyLinkedList<int>();
            list.Append(1);
            list.Append(2);
            list.Append(3);

            list.RemoveDuplicates();

            Assert.AreEqual(3, list.Enumerate().Count());
        }

        [TestMethod]
        public void Test2()
        {
            var list = new SinglyLinkedList<int>();
            list.Append(1);
            list.Append(2);
            list.Append(2);

            list.RemoveDuplicates();

            Assert.AreEqual(2, list.Enumerate().Count());
        }

        [TestMethod]
        public void Test3()
        {
            var list = new SinglyLinkedList<int>();
            list.Append(2);
            list.Append(2);
            list.Append(2);

            list.RemoveDuplicates();

            Assert.AreEqual(1, list.Enumerate().Count());
        }
    }
}
