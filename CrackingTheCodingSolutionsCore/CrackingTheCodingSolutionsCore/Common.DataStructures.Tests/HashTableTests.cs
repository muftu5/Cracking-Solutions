using AutoFixture;
using Common.DataStructures.HashTable;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Common.DataStructures.UnitTests
{
    [TestClass]
    public class HashTableTests
    {
        private IFixture fixture;
        private Stopwatch stopwatch; 

        [TestInitialize]
        public void Initialize()
        {
            fixture = new Fixture();
            stopwatch = new Stopwatch();
        }

        [TestMethod]
        public void Add_ComparisonWithBuiltInHashTable_ShouldBeAlmostSameEffectiveOnAdd()
        {
            var numberOfKeys = 20000;
            var hashTable = new HashTable<string, int>();

            stopwatch.Start();
            foreach (var key in fixture.CreateMany<string>(numberOfKeys))
                hashTable.Add(key, default(int));

            var customHashTableTrialElasped = stopwatch.Elapsed.Milliseconds;
            stopwatch.Reset();

            var builtInHashTable = new Dictionary<string, int>();

            fixture = new Fixture();
            stopwatch.Start();
            foreach (var key in fixture.CreateMany<string>(numberOfKeys))
                builtInHashTable.Add(key, default(int));

            var builtInHashTableTrialElasped = stopwatch.Elapsed.Milliseconds;

            const float thresholdMultiplier = 0.8f;
            Assert.IsTrue(customHashTableTrialElasped * thresholdMultiplier 
                < builtInHashTableTrialElasped);
        }

        [TestMethod]
        public void HasKey_ShouldReturnKey_WhenKeyExistsInList()
        {
            var hashTable = new HashTable<string, int>();
            var key = fixture.Create<string>();
            var value = fixture.Create<int>();

            hashTable.Add(key, value);

            int data;
            hashTable.HasKey(key, out data);

            Assert.AreEqual(value, data);
        }

        [TestMethod]
        public void Remove_ShouldRemoveKeyFromHashTable()
        {
            var hashTable = new HashTable<string, int>();
            var key = fixture.Create<string>();
            var value = fixture.Create<int>();

            hashTable.Add(key, value);
            hashTable.Remove(key);

            int data;

            Assert.IsFalse(hashTable.HasKey(key, out data));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Remove_ShouldThrowAnException_WhenKeyNotFound()
            => new HashTable<int, int>().Remove(fixture.Create<int>());

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Add_ShouldThrowAnException_WhenKeyAlreadyAdded()
        {
            var hashTable = new HashTable<string, int>();
            var key = fixture.Create<string>();
            var value = fixture.Create<int>();

            hashTable.Add(key, value);
            hashTable.Add(key, value);
        }
    }
}
