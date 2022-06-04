using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Game.BusinessLogic.Utils
{
    public class DataUtil
    {
        public static class Entities
        {
            public const string UiMap = "UiMap";
        }
        
        private static class FileNames
        {
            public const string UiMapPath = "ViewData/UiMap.json";
        }

        public Dictionary<string, JToken> GetFileData()
        {
            var dictionary = new Dictionary<string, JToken>();

            var uiMap = JsonConvert.DeserializeObject<JToken>(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, FileNames.UiMapPath)));
            dictionary.Add(Entities.UiMap, uiMap);
            
            return dictionary;
        }
    }
}
