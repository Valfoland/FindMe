using Basement.Common;
using fastJSON;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace BusinessLogic
{
    public static class DataKeeper
    {
        private const string FilePathKey = "file-path";
        private const string DirectoryPathsFilePath = "directories-paths.json";
        private const string DataFilePath = "data.json";

        public static string SaveDirectory
        {
            get
            {
#if UNITY_EDITOR
                return editorSaveDirectory;
#else
                return defaultSaveDirectory;
#endif
            }
        }

        private static readonly string editorSaveDirectory = $"{Application.dataPath}/../data";
        private static readonly string defaultSaveDirectory = $"{Application.persistentDataPath}";


        public static RawNode PlayerProgress => _playerProgress;
        public static RawNode Repositories => _repositories;
        private static RawNode _repositories;
        private static RawNode _playerProgress;

        public static RawNode LoadProgress()
        {
            _playerProgress = new RawNode(JSON.Instance.Parse(File.ReadAllText(Path.Combine(SaveDirectory, DataFilePath))));
            return _playerProgress;
        }
        
        public static RawNode LoadRepositories()
        {
            var files = new RawNode(JSON.Instance.Parse(File.ReadAllText(Path.Combine(SaveDirectory, DirectoryPathsFilePath))));
            var allRepos = new Dictionary<string, object>();

            foreach (var file in files.GetSortedCollection())
            {
                var filePath = file.Value.GetString(FilePathKey);
                var fileBody = File.ReadAllText(Path.Combine(SaveDirectory, filePath));
                var jsonDict = (Dictionary<string, object>) JSON.Instance.Parse(fileBody);
                allRepos.Add(file.Key, jsonDict);
            }

            _repositories = new RawNode(allRepos);

            return _repositories;
        }
    }
}