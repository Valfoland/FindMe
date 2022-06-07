using System.Collections.Generic;
using Frameworks.BlFramework.Base;
using Frameworks.BlFramework.Utils;
using Frameworks.StateMachine;

namespace Game.BusinessLogic.Descriptions
{
    public class UiTransitionDescriptionCollection : DescriptionCollectionBase<UiTransitionDescription>, IEnumerable<KeyValuePair<string, IStateTransitionData>>, IStateTransitionData
    {
        public UiTransitionDescriptionCollection(TreeData nodeData) : base(nodeData)
        {
            
        }

        public string GetStateKey()
        {
            return Key;
        }
        
        protected override IDescription GetNewDescription(TreeData childData)
        {
            return new UiTransitionDescription(childData);
        }

        public new IEnumerator<KeyValuePair<string, IStateTransitionData>> GetEnumerator()
        {
            foreach (var item in NodeData.GetCollection())
            {
                yield return new KeyValuePair<string, IStateTransitionData>(item.Key, GetChild(item.Key));
            }
        }
    }
}
