using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RemoveDups.Tests
{
    [TestClass]
    public class RemoveDupsTests
    {
        private LinkedList<int> linkedList;

        [TestInitialize]
        public void Initialize()
        {
            linkedList = new LinkedList<int>();
        }

        [TestMethod]
        public void RemoveDuplicates_ShouldDoNothing_WhenElementsAreUnique()
        {
            linkedList.AppendHead(1);
            linkedList.AppendHead(2);
            linkedList.AppendHead(3);

            linkedList.RemoveDuplicates();

            Assert.AreEqual(3, linkedList.Enumerate().Count());
        }

        [TestMethod]
        public void RemoveDuplicates_ShouldRemoveSingleDuplicate_WhenItIsPresent()
        {
            var list = new LinkedList<int>();
            linkedList.AppendHead(1);
            linkedList.AppendHead(2);
            linkedList.AppendHead(2);

            linkedList.RemoveDuplicates();

            Assert.AreEqual(2, linkedList.Enumerate().Count());
        }

        [TestMethod]
        public void RemoveDuplicates_ShouldRemoveMultipleDuplicates_WhenDuplicatesExist()
        {
            var list = new LinkedList<int>();
            linkedList.AppendHead(2);
            linkedList.AppendHead(2);
            linkedList.AppendHead(2);

            linkedList.RemoveDuplicates();

            Assert.AreEqual(1, linkedList.Enumerate().Count());
        }
    }
}
