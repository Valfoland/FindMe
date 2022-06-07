using System.Collections;
using System.Collections.Generic;
using Frameworks.BlFramework.Utils;

namespace Frameworks.BlFramework.Base
{
    public abstract class DescriptionCollectionBase<TDescription>: IDescription, IEnumerable<KeyValuePair<string, TDescription>> where TDescription : IDescription
    {
        public string Key { get; }
        protected TreeData NodeData { get; }
        
        private readonly Dictionary<string, IDescription> _items = new Dictionary<string, IDescription>();

        protected abstract IDescription GetNewDescription(TreeData childData);

        protected DescriptionCollectionBase(TreeData nodeData)
        {
            Key = nodeData.GetKey();
            NodeData = nodeData;
        }

        public IEnumerator<KeyValuePair<string, TDescription>> GetEnumerator()
        {
            foreach (var item in NodeData.GetCollection())
            {
                yield return new KeyValuePair<string, TDescription>(item.Key, GetChild(item.Key));
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
        private void AddChild(IDescription child)
        {
            _items.Add(child.Key, child);
        }
        
        public TDescription GetChild(string key)
        {
            if (_items.TryGetValue(key, out var item))
            {
                return (TDescription) item;
            }
            
            AddChild(GetNewDescription(NodeData.GetChildData(key)));
            
            return (TDescription) _items[key];
        }
    }
}
