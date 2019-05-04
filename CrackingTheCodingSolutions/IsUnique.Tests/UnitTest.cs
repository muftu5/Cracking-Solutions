using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IsUnique.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Test1() => Assert.IsTrue(Solution.HasUniqueChars("abcdef"));

        [TestMethod]
        public void Test2() => Assert.IsTrue(Solution.HasUniqueChars("qwertyasdfghzxcvbnm"));

        [TestMethod]
        public void Test3() => Assert.IsFalse(Solution.HasUniqueChars("aabbcc"));

        [TestMethod]
        public void Test4() => Assert.IsFalse(Solution.HasUniqueChars("qweaabnd"));
    }
}
