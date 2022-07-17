using Frameworks.StateMachine;
using Game.BusinessLogic.Descriptions;
using Game.Data.BusinessLogic.Descriptions.UiMapDescription;
using Game.UiController.Windows;

namespace Game.UiController.StateController
{
    public class UiStateController : Frameworks.StateMachine.StateController
    {
        private readonly UiMapDescriptionCollection _uiMap;
        
        public UiStateController(string stateId, IStateTransitionData transitionMap) : base(null, stateId, transitionMap)
        {
            _uiMap = (UiMapDescriptionCollection) transitionMap;
        }

        protected override void OnEnter()
        {
            var states = new State[_uiMap.CountChild];
            var index = 0;
            foreach (var ui in _uiMap)
            {
                states[index] = new UiState(this, ui.Key, ui.Value);

                foreach (var transition in (UiTransitionDescriptionCollection) ui.Value)
                {
                    states[index].AddTransition(GetTransition((UiTransitionDescription) transition.Value));
                }
                
                index++;
            }
            
            Setup(states);
        }

        private IStateTransition GetTransition(UiTransitionDescription transitionDescription)
        {
            return WindowFactory.GetWindowTransition(transitionDescription.TransitionType, transitionDescription);
        }

        protected override IStateAction GetStateAction(string stateId, IStateTransitionData transitionsData)
        {
            throw new System.NotImplementedException();
        }
    }
}
