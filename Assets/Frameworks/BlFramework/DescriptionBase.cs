using System.Collections.Generic;
using BlFramework;
using Frameworks.BlFramework.Utils;

namespace Frameworks.BlFramework
{
    public abstract class DescriptionBase : IDescription
    {
        public string Key { get; }

        private readonly TreeData _nodeData;
        private readonly Dictionary<string, IDescription> _items = new Dictionary<string, IDescription>();
        
        protected DescriptionBase(TreeData nodeData)
        {
            Key = nodeData.GetKey();
            _nodeData = nodeData;
        }
        
        protected void AddChild(IDescription child)
        {
            _items.Add(child.Key, child);
        }
        
        public TDescription GetChild<TDescription>(string key) where TDescription : IDescription
        {
            return (TDescription) _items[key];
        }
    }
}
