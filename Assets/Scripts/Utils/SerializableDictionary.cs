using System;
using System.Collections.Generic;
using UnityEngine;


namespace Utils
{
    [Serializable]
    public class SerializableDictionary<TKey, TValue> : ISerializationCallbackReceiver
    {
        private Dictionary<TKey, TValue> dictionary = new();
        [SerializeField] private List<DictionaryItem> list = new();


        public Dictionary<TKey, TValue> Dictionary => dictionary;


        public TValue this[TKey key]
        {
            get
            {
                dictionary.TryGetValue(key, out var value);
                return value;
            }
        }


        public void Add(TKey key, TValue value)
        {
            list.Add(new DictionaryItem(key, value));
            dictionary.Add(key, value);
        }


        public void Clear()
        {
            list.Clear();
            dictionary.Clear();
        }


        public void OnBeforeSerialize() { }


        public void OnAfterDeserialize()
        {
            dictionary.Clear();

            foreach (var item in list)
            {
                if (dictionary.ContainsKey(item.key))
                {
                    Debug.LogError($"Item with key {item.key} already exists. It will be passed");
                    continue;
                }

                dictionary.Add(item.key, item.value);
            }
        }


        [Serializable]
        private class DictionaryItem
        {
            public TKey key;
            public TValue value;


            public DictionaryItem(TKey key, TValue value)
            {
                this.key = key;
                this.value = value;
            }
        }
    }
}