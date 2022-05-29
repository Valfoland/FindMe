using System;
using System.Collections;
using System.Collections.Generic;
using BusinessLogic.Utils;

namespace BlFramework
{
    public abstract class DescriptionBase : IDescription, IEnumerable<KeyValuePair<string, DescriptionBase>>
    {
        public string Key { get; }

        protected SerializableData data;

        private Dictionary<string, DescriptionBase> _items = new Dictionary<string, DescriptionBase>();

        protected DescriptionBase(SerializableData data)
        {
            this.data = data;

            Key = data.GetDataKey();
        }

        public IEnumerator<KeyValuePair<string, DescriptionBase>> GetEnumerator()
        {
            foreach (var item in data.GetCollection())
            {
                yield return new KeyValuePair<string, DescriptionBase>(item.Key, GetChild(item.Key));
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        protected void AddChild(DescriptionBase child)
        {
            _items.Add(child.Key, child);
        }
        
        private DescriptionBase GetChild(string collectionKey)
        {
            return _items[collectionKey];
        }
    }
}
