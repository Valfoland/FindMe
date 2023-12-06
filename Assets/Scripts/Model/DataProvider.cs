using Basement.Common;
using fastJSON;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


namespace BusinessLogic
{
    public static class DataProvider
    {
        private const string FilePathKey = "file-path";
        private const string DirectoryPathsFilePath = "directories-paths.json";
        private const string DataFilePath = "data.json";

        private static readonly string _editorSaveDirectory = $"{Application.dataPath}/../Data";
        private static readonly string _defaultSaveDirectory = $"{Application.persistentDataPath}";
        private static RawNode _repositories;
        private static RawNode _playerProgress;

        public static string SaveDirectory
        {
            get
            {
#if UNITY_EDITOR
                return _editorSaveDirectory;
#else
                return defaultSaveDirectory;
#endif
            }
        }

        public static RawNode PlayerProgress => _playerProgress;

        public static RawNode Repositories => _repositories;


        public static RawNode LoadProgress()
        {
            _playerProgress = new RawNode(JSON.Instance.Parse(File.ReadAllText(Path.Combine(SaveDirectory, DataFilePath))));
            return _playerProgress;
        }


        public static RawNode LoadRepositories()
        {
            var pathContainer = File.ReadAllText(Path.Combine(SaveDirectory, DirectoryPathsFilePath));
            var files = new RawNode(JSON.Instance.Parse(pathContainer));
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

        public static void WritePlayerProgressData(string dataText)
        {
            File.WriteAllText(Path.Combine(SaveDirectory, DataFilePath), dataText);
        }
    }
}