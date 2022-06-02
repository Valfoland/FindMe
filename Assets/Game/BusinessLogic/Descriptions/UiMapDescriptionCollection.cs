using BlFramework;
using Frameworks.BlFramework;
using Frameworks.BlFramework.Utils;

namespace Game.BusinessLogic.Descriptions
{
    public class UiMapDescriptionCollection : DescriptionCollectionBase<UiMapDescription>
    {
        public UiMapDescriptionCollection(TreeData nodeData) : base(nodeData)
        {
            
        }

        protected override IDescription GetNewDescription(TreeData childData)
        {
            return new UiMapDescription(childData);
        }
    }
}
