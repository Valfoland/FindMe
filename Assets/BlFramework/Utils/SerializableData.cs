
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BusinessLogic.Utils
{
    public class SerializableData
    {
        private object _data;
        private string _key;
        
        private Dictionary<string, object> _dataDictionary;

        public SerializableData(object data, string key)
        {
            _data = data;
            _key = key;
            _dataDictionary = (Dictionary<string, object>) data;
        }

        public string GetDataKey()
        {
            return _key;
        }

        public SerializableData GetChildData(string dataKey)
        {
            if (_dataDictionary.TryGetValue(dataKey, out var data))
            {
                return new SerializableData(data, _key);
            }

            return new SerializableData(null, _key);
        }

        public string GetString(string dataKey)
        {
            if (_dataDictionary.TryGetValue(dataKey, out var data))
            {
                return data.ToString();
            }
            
            return String.Empty;
        }

        public IEnumerable<KeyValuePair<string, SerializableData>> GetCollection()
        {
            var collection = new KeyValuePair<string, SerializableData>[_dataDictionary.Count];
            var i = 0;
            
            foreach (var data in _dataDictionary)
            {
                collection[i++] = new KeyValuePair<string, SerializableData>(data.Key, new SerializableData(data.Value, data.Key));
            }
            
            return collection;
        }
    }
}
