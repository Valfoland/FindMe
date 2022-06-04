using System.Collections.Generic;
using Frameworks.BlFramework.Base;
using Frameworks.BlFramework.Utils;
using Game.BusinessLogic.Descriptions;
using Game.BusinessLogic.Utils;

namespace Game.BusinessLogic.Context
{
    public class GameContext
    {
        private const string RootKey = "Root";
        
        private readonly TreeData _data;
        private readonly Dictionary<string, IDescription> _children = new Dictionary<string, IDescription>();

        public GameContext()
        {
            _data = new TreeData(new DataUtil().GetFileData(), RootKey);
            
            CreateContext();
        }

        private void CreateContext()
        {
            AddChild(new UiMapDescriptionCollection(_data.GetChildData(DataUtil.Entities.UiMap)));
        }

        private void AddChild(IDescription dataSource)
        {
            _children.Add(dataSource.Key, dataSource);
        }

        public TDescription GetChild<TDescription>(string key) where TDescription : IDescription
        {
            return (TDescription) _children[key];
        }
    }
}
