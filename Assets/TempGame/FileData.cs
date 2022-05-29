using System.IO;
using Newtonsoft.Json.Linq;
using UnityEngine;

namespace TempGame
{
    public class FileData
    {
        public static class FileNames
        {
            public const string UiMapPath = "UiMap.json";
        }

        public object GetFileData(string path)
        {
            return JObject.Parse(File.ReadAllText(Path.Combine(Application.streamingAssetsPath, path)));
        }
    }
}
