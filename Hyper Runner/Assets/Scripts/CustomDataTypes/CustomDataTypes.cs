using System;
using System.Collections.Generic;

/// <summary>
/// Custom data types that are used throughout the project
/// </summary>
namespace CustomDataTypes
{
    public class BidirectionalDictionary<K, V>
    {
        private Dictionary<K, V> keyToValue = new Dictionary<K, V>();
        private Dictionary<V, K> valueToKey = new Dictionary<V, K>();
        
        public BidirectionalDictionary(){}
        
        public BidirectionalDictionary(List<K> keys, List<V> values)
        {
            if (keys.Count != values.Count)
            {
                throw new Exception("Keys and values should be the same length");
            }

            for (int i = 0; i < keys.Count; i++)
            {
                keyToValue.Add(keys[i], values[i]);
                valueToKey.Add(values[i], keys[i]);
            }
        }

        public K getKeyFromValue(V value)
        {
            if (!valueToKey.ContainsKey(value))
            {
                throw new Exception("Could not find key from value");
            }

            return valueToKey[value];
        }

        public V getValueFromKey(K key)
        {
            if (!keyToValue.ContainsKey(key))
            {
                throw new Exception("Could not find value from key");
            }

            return keyToValue[key];
        }
    }
}
