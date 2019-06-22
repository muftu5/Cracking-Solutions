using System;
using Common.DataStructures.Queue;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.DataStructures.UnitTests
{
    [TestClass]
    public class QueueTests
    {
        private IQueue<int> queue;

        [TestInitialize]
        public void Initialize()
        {
            queue = new Queue<int>();
        }

        [TestMethod]
        public void Queue_ShouldAddElements()
        {
            queue.Add(1);
            Assert.AreEqual(1, queue.Peek());

            queue.Add(3);
            Assert.AreEqual(1, queue.Peek());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_ShouldThrowException_WhenPeekingEmptyQueue() => queue.Peek();

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Remove_ShouldThrowException_WhenQueueIsEmpty() => queue.Remove();

        [TestMethod]
        public void Remove_ShouldReturnHeadElement()
        {
            queue.Add(1);
            queue.Add(2);

            Assert.AreEqual(1, queue.Remove());
            Assert.AreEqual(2, queue.Remove());
        }

        [TestMethod]
        public void IsEmpty_ShouldReturnTrue_WhenHeadIsNull()
            => Assert.IsTrue(queue.IsEmpty());

        [TestMethod]
        public void IsEmpty_ShouldReturnFalse_WhenHeadIsNotNull()
        {
            queue.Add(1);

            Assert.IsFalse(queue.IsEmpty());
        }
    }
}
