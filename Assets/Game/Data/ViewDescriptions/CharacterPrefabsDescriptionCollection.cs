using Frameworks.BlFramework.Base;
using Frameworks.BlFramework.Utils;

namespace Game.Data.ViewDescriptions
{
    public class CharacterPrefabsDescriptionCollection : DescriptionCollectionBase<CharacterPrefabDescription>
    {
        public CharacterPrefabsDescriptionCollection(TreeData nodeData) : base(nodeData)
        {
        }

        protected override IDescription GetNewDescription(TreeData childData)
        {
            return new CharacterPrefabDescription(childData);
        }
    }
}
