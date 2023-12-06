using System.Collections.Generic;
using Basement.BLFramework.Core.Context;
using Basement.BLFramework.Core.Model;
using Basement.Common;
using Zenject;


namespace BusinessLogic
{
    public class PlayerContext : IInitializable, IContext
    {
        private readonly RawNode _playerProgressNode;
        private readonly IDictionary<string, object> _children = new Dictionary<string, object>();

        public DataSources dataSources { get; }
        public RawNode repositories { get; }

        public PlayerContext(RawNode playerProgressNode, RawNode repositoryNode)
        {
            _playerProgressNode = playerProgressNode;
            repositories = repositoryNode;
            dataSources = new DataSources();
        }

        public void Initialize()
        {
            dataSources.AddChild(new UiWindowsDataSource(repositories.GetNode(EntityIds.UiWindowsConfig)));
        }

        public void Drop()
        {
        }

        public IModel GetChild(string collectionKey)
        {
            return (IModel)_children[collectionKey];
        }

        public void AddChild(IModel child)
        {
            _children.Add(child.key, child);
        }

        public void RemoveChild(string collectionKey)
        {
            _children.Remove(collectionKey);
        }

        public bool Exist(string collectionKey)
        {
            return _children.ContainsKey(collectionKey);
        }

        public T GetChild<T>(string collectionKey) where T : class
        {
            return (T)_children[collectionKey];
        }

        public object Serialize()
        {
            var dictionary = new Dictionary<string, object>();
            
            foreach (var pair in _children)
            {
                if (pair.Value is IModel model)
                {
                    var result = model.Serialize();
                    
                    if (result != null)
                    {
                        dictionary.Add(pair.Key, result);
                    }
                }
            }

            return dictionary;
        }
    }
}