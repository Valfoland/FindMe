using System.Collections.Generic;
using Frameworks.BlFramework.Base;
using Frameworks.BlFramework.Utils;
using Frameworks.StateMachine;
using Game.Data.BusinessLogic.Descriptions.UiMapDescription;

namespace Game.BusinessLogic.Descriptions
{
    public class UiMapDescriptionCollection : DescriptionCollectionBase<UiTransitionDescriptionCollection>, IEnumerable<KeyValuePair<string, IStateTransitionData>>, IStateTransitionData
    {
        public UiMapDescriptionCollection(TreeData nodeData) : base(nodeData)
        {
            
        }

        protected override IDescription GetNewDescription(TreeData childData)
        {
            return new UiTransitionDescriptionCollection(childData);
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
