using Frameworks.StateMachine;
using Game.BusinessLogic.Descriptions;
using Game.UiController.Windows;

namespace Game.UiController.StateController
{
    public class UiStateController : Frameworks.StateMachine.StateController
    {
        private readonly UiMapDescriptionCollection _uiMap;
        
        public UiStateController(IStateTransitionData transitionMap) : base(transitionMap)
        {
            _uiMap = (UiMapDescriptionCollection) transitionMap;
        }
        
        protected override State GetState(string stateId)
        {
            var transitionCollection = _uiMap.GetChild(stateId);
            return new UiState(this, stateId, transitionCollection);
        }

        protected override bool TryGetTransition(string fromStateId, string toStateId, out IStateTransition stateTransition)
        {
            var transitionCollection = _uiMap.GetChild(fromStateId);
            var transitionDescription = transitionCollection.GetChild(toStateId);

            if (transitionDescription != null)
            {
                stateTransition = WindowFactory.GetWindowTransition(transitionDescription.TransitionType, transitionDescription);
                return true;
            }

            stateTransition = null;
            return false;
        }
    }
}
