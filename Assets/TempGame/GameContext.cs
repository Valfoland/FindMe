using System.Collections.Generic;
using BlFramework;
using BusinessLogic.Utils;
using TempGame.Descriptions;

namespace TempGame
{
    public class GameContext
    {
        public static class Entities
        {
            public const string UiMap = "UiMap";
        }
        
        private readonly SerializableData _data;
        private readonly Dictionary<string, IDescription> _children = new Dictionary<string, IDescription>();

        public GameContext()
        {
            _data = new SerializableData(new FileData().GetFileData(FileData.FileNames.UiMapPath), null);
            
            CreateContext();
        }

        private void CreateContext()
        {
            AddChild(new UiMapDescription(_data));
        }

        private void AddChild(IDescription dataSource)
        {
            _children.Add(dataSource.Key, dataSource);
        }

        public IDescription GetChild(string key)
        {
            return _children[key];
        }
    }
}
