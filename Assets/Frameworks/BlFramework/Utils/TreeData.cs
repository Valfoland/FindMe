using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace Frameworks.BlFramework.Utils
{
    public class TreeData
    {
        private string _key;
        private Dictionary<string, JToken> _data;
        
        public TreeData(Dictionary<string, JToken> data, string key)
        {
            _data = data;
            _key = key;
        }

        public TreeData GetChildData(string childKey)
        {
            if (_data.TryGetValue(childKey, out JToken childToken))
            {
                return new TreeData(childToken.ToObject<Dictionary<string, JToken>>(), childKey);
            }

            throw new Exception($"Не найден ключ {childKey} в {_key}");
        }

        public IEnumerable<KeyValuePair<string, TreeData>> GetCollection()
        {
            foreach (var child in _data)
            {
                var childData = new TreeData(child.Value.ToObject<Dictionary<string, JToken>>(), child.Key);
                yield return new KeyValuePair<string, TreeData>(child.Key, childData);
            }
        }

        public string GetString(string key)
        {
            return _data[key].ToObject<string>();
        }

        public string GetKey()
        {
            return _key;
        }
    }
}
