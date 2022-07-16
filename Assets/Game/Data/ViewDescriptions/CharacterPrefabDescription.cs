using Frameworks.BlFramework.Base;
using Frameworks.BlFramework.Utils;

namespace Game.Data.ViewDescriptions
{
    public class CharacterPrefabDescription : DescriptionBase
    {
        private const string PathKey = "Path";
        
        public string Path { get; private set; }
        
        public CharacterPrefabDescription(TreeData nodeData) : base(nodeData)
        {
            Path = nodeData.GetString(PathKey);
        }
    }
}
