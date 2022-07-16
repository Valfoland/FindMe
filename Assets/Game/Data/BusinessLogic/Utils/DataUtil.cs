using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace Game.Data.BusinessLogic.Utils
{
    public class DataUtil
    {
        public static class Entities
        {
            public const string UiMap = "UiMap";
            public const string CharacterPrefabs = "CharacterPrefabs";
            
            public static HashSet<string> entitiesHashSet = new()
            {
                UiMap,
                CharacterPrefabs
            };
        }
        
        private static class FileNames
        {
            private const string UiMapPath = "Data/UiMap.json";
            private const string CharacterPrefabPath = "Data/UiMap.json";

            public static HashSet<string> fileHashSet = new()
            {
                UiMapPath,
                CharacterPrefabPath
            };
        }

        public Dictionary<string, JToken> GetFileData()
        {
            var dictionary = new Dictionary<string, JToken>();
            var fileNames = FileNames.fileHashSet.ToList();

            var index = 0;
            
            foreach (var entityName in Entities.entitiesHashSet)
            {
                var entity = JsonConvert.DeserializeObject<JToken>(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, fileNames[index])));
                dictionary.Add(entityName, entity);

                index++;
            }

            return dictionary;
        }
    }
}
