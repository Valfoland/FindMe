using Basement.Common;
using fastJSON;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace BusinessLogic
{
    public class DataKeeper
    {
        private const string DirectoryPathsFilePath = "/directoryPaths.json";
        
        public static readonly string editorSaveDirectory = $"{Application.dataPath}/../data/data.json";
        public static readonly string defaultSaveDirectory = $"{Application.persistentDataPath}/data.json";
        public RawNode Repositories => _repositories;
        private RawNode _repositories;

        public void LoadData()
        {
            var files = new RawNode(JSON.Instance.Parse(File.ReadAllText(editorSaveDirectory + "/files.json")));
            var allRepos = new Dictionary<string, object>();
            
            foreach (var file in files.GetSortedCollection())
            {
                var fileName = file.Value.GetString("file");
                var fileBody = File.ReadAllText(editorSaveDirectory + "/" + fileName);
                var jsonDict = (Dictionary<string, object>)JSON.Instance.Parse(fileBody);
                allRepos.Add(file.Key, jsonDict);
            }

            _repositories = new RawNode(allRepos);
        }
    }
}