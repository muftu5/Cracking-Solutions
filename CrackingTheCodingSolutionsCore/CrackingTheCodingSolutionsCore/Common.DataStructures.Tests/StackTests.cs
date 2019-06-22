using System;
using Common.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Common.DataStructures.UnitTests
{
    [TestClass]
    public class StackTests
    {
        private Stack<int> stack;

        [TestInitialize]
        public void Initialize()
        {
            stack = new Stack<int>();
        }

        [TestMethod]
        public void Stack_ShouldAddElements()
        {
            stack.Push(1);
            Assert.AreEqual(1, stack.Peek());

            stack.Push(3);
            Assert.AreEqual(3, stack.Peek());

            stack.Push(2);
            Assert.AreEqual(2, stack.Peek());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Peek_ShouldThrowException_WhenPeekingEmptyStack()
        {
            Assert.IsNull(stack.Peek());
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Pop_ShouldThrowException_WhenStackIsEmpty()
        {
            Assert.IsNull(stack.Pop());
        }

        [TestMethod]
        public void Pop_ShouldReturnHeadElement()
        {
            stack.Push(1);
            stack.Push(2);

            Assert.AreEqual(2, stack.Pop());
            Assert.AreEqual(1, stack.Pop());
        }

        [TestMethod]
        public void IsEmpty_ShouldReturnTrue_WhenHeadIsNull()
            => Assert.IsTrue(stack.IsEmpty());

        [TestMethod]
        public void IsEmpty_ShouldReturnFalse_WhenHeadIsNotNull()
        {
            stack.Push(1);

            Assert.IsFalse(stack.IsEmpty());
        }
    }
}
