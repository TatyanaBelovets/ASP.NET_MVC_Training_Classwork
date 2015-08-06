using System;
using System.Collections.Generic;
using System.Linq;

namespace HashTableLibrary
{
    public class HashTable<TKey, TValue>
    {
        public int Size { private set; get; }
        private const int InitialTableSize = 10;
        private Pair[] _hashTableArray = new Pair[InitialTableSize];

        public HashTable()
        {
            Size = 0;
        }

        public TValue SearchByKey(TKey key)
        {
            var pair = _hashTableArray[Math.Abs(key.GetHashCode()%_hashTableArray.Length)];
            if (pair == null)
            {
                throw new KeyNotFoundException("There is not such key!");
            }
            while (!pair.Key.Equals(key))
            {
                if (pair.NextPair != null)
                {
                    pair = pair.NextPair;
                }
                else
                {
                    throw new KeyNotFoundException("There is no such key!");
                }
            }
            return pair.Value;
        }

        public void Add(TKey key, TValue value)
        {
            var index = Math.Abs(key.GetHashCode()%_hashTableArray.Length);
            if (Size > _hashTableArray.Length*2/3)
            {
                IncreaseSizeOfInnerArray();
            }
            SimpleAdd(key, value, index);
        }

        private void SimpleAdd(TKey key, TValue value, int index)
        {
            _hashTableArray[index] = new Pair(key, value, _hashTableArray[index]);
            Size++;
        }

        public TValue Remove(TKey key)
        {
            var pair = _hashTableArray[Math.Abs(key.GetHashCode()%_hashTableArray.Length)];
            TValue value = default(TValue);
            if (pair == null)
            {
                throw new KeyNotFoundException("There is not such key!");
            }
            if (pair.Key.Equals(key))
            {
                value = pair.Value;
                _hashTableArray[Math.Abs(key.GetHashCode() % _hashTableArray.Length)] = pair.NextPair;
            }
            while (!pair.Key.Equals(key))
            {
                if (pair.NextPair != null && pair.NextPair.Key.Equals(key))
                {
                    value = pair.NextPair.Value;
                    pair.NextPair = pair.NextPair.NextPair;
                    break;
                }
                if (pair.NextPair == null)
                {
                     throw new KeyNotFoundException("There is no such key!");
                    
                }
                pair = pair.NextPair;
            }
            Size--;
            return value;
        }

        private class Pair
        {
            public readonly TKey Key;
            public readonly TValue Value;
            public Pair NextPair;

            public Pair(TKey key, TValue value, Pair nextPair = null)
            {
                Key = key;
                Value = value;
                NextPair = nextPair;
            }
        }

        private void IncreaseSizeOfInnerArray()
        {
            var oldHashTable = _hashTableArray;
            _hashTableArray = new Pair[2 * _hashTableArray.Length + 1];
            foreach (var pair in oldHashTable.Where(pair => pair != null))
            {
                var temp = _hashTableArray[Math.Abs(pair.Key.GetHashCode() % _hashTableArray.Length)];
                _hashTableArray[Math.Abs(pair.Key.GetHashCode() % _hashTableArray.Length)] = new Pair(pair.Key,
                    pair.Value, temp);
                var nextPair = pair.NextPair;
                while (nextPair != null)
                {
                    Add(nextPair.Key, nextPair.Value);
                    Size--;
                    nextPair = nextPair.NextPair;
                }
            }
        }
    }
}