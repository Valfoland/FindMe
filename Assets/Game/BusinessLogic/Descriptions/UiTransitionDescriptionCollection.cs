using Frameworks.BlFramework.Base;
using Frameworks.BlFramework.Utils;

namespace Game.BusinessLogic.Descriptions
{
    public class UiTransitionDescriptionCollection : DescriptionCollectionBase<UiTransitionDescription>
    {
        public UiTransitionDescriptionCollection(TreeData nodeData) : base(nodeData)
        {
            
        }

        protected override IDescription GetNewDescription(TreeData childData)
        {
            return new UiTransitionDescription(childData);
        }
    }
}
