using System;
using System.Collections.Generic;
using HashTableLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HashTableTests
{
    [TestClass]
    public class Tests
    {
        [TestMethod]
        public void Ctor_GivenNone_SizeIsZero()
        {
            var hashTable = new HashTable<int,int>();
            Assert.AreEqual(0,hashTable.Size);
        }

        [TestMethod]
        public void SearchByKey_GivenKey_ReturnsExpectedValue()
        {
            var hashTable = new HashTable<int,int>();
            hashTable.Add(5, 2);
            hashTable.Add(6, 4);
            hashTable.Add(17, 1);
            hashTable.Add(12, 8);
            hashTable.Add(48, 30);
            hashTable.Add(11, 7);
            hashTable.Add(78, 25);
            hashTable.Add(9, 29);
            hashTable.Add(15, 21);
            hashTable.Add(7, 58);
            hashTable.Remove(11);
            Assert.AreEqual(25,hashTable.SearchByKey(78));
        }

        [TestMethod, ExpectedException(typeof(KeyNotFoundException))]
        public void Add_GivenKeyAndValue_PairInATable()
        {
            var hashTable = new HashTable<int, int>();
            hashTable.Add(5, 2);
            hashTable.Add(48, 30);
            hashTable.Add(11, 7);
            hashTable.Add(78, 25);
            hashTable.Add(7, 58);
            Assert.AreEqual(7, hashTable.SearchByKey(58));
        }

        [TestMethod, ExpectedException(typeof(KeyNotFoundException))]
        public void Remove_GivenTheSameKeySecondTime_ThrownExpectedException()
        {
            var hashTable = new HashTable<int, int>();
            hashTable.Add(31, 2);
            hashTable.Add(21, 30);
            hashTable.Add(11, 7);
            hashTable.Add(41, 25);
            hashTable.Add(7, 58);
            hashTable.Remove(11);
            hashTable.Remove(11);
        }

        [TestMethod]
        public void Remove_GivenKey_ReturnedExpectedValue()
        {
            var hashTable = new HashTable<int, int>();
            hashTable.Add(31, 2);
            hashTable.Add(21, 30);
            hashTable.Add(11, 7);
            hashTable.Add(41, 25);
            hashTable.Add(7, 58);
            Assert.AreEqual(7, hashTable.Remove(11));
        }
    }
}
