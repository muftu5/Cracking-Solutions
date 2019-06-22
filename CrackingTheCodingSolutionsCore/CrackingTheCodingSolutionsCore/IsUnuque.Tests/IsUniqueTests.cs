using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace IsUnique.Tests
{
    [TestClass]
    public class IsUniqueTests
    {
        [TestMethod]
        public void HasUniqueChars_ShouldReturnTrue_WhenStringsHaveAllUniqueCharacters()
        {
            Assert.IsTrue(Solution.HasUniqueChars("abc123def"));
            Assert.IsTrue(Solution.HasUniqueChars("qwertyasd123456fghzxcvbnm"));
        }

        [TestMethod]
        public void HasUniqueChars_ShouldReturnFlase_WhenStringsHaveNonUniqueCharacters()
        {
            Assert.IsFalse(Solution.HasUniqueChars("aabbcc"));
            Assert.IsFalse(Solution.HasUniqueChars("qwe2233&&bnd"));
        }
    }
}
