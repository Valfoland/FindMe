using Frameworks.BlFramework;
using Frameworks.BlFramework.Utils;

namespace Game.BusinessLogic.Descriptions
{
    public class UiMapDescription : DescriptionBase
    {
        private const string TransitionToKey = "TransitionTo";
        
        public string TransitionTo { get; private set; }
        
        public UiMapDescription(TreeData nodeData) : base(nodeData)
        {
            TransitionTo = nodeData.GetString(TransitionToKey);
        }
    }
}
