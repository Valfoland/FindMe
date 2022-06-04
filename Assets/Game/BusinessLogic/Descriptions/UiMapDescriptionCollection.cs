using Frameworks.BlFramework;
using Frameworks.BlFramework.Base;
using Frameworks.BlFramework.Utils;

namespace Game.BusinessLogic.Descriptions
{
    public class UiMapDescriptionCollection : DescriptionCollectionBase<UiTransitionDescriptionCollection>
    {
        public UiMapDescriptionCollection(TreeData nodeData) : base(nodeData)
        {
            
        }

        protected override IDescription GetNewDescription(TreeData childData)
        {
            return new UiTransitionDescriptionCollection(childData);
        }
    }
}
