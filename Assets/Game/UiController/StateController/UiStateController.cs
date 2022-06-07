using System;
using System.Collections.Generic;
using Frameworks.StateMachine;
using Game.BusinessLogic.Descriptions;
using Game.BusinessLogic.Utils;
using Game.UiController.Windows;

namespace Game.UiController.StateController
{
    public class UiStateController : Frameworks.StateMachine.StateController
    {
        private readonly UiMapDescriptionCollection _uiMap;
        
        public UiStateController(IEnumerable<KeyValuePair<string, IStateTransitionData>> transitionMap) : base(transitionMap)
        {
            _uiMap = (UiMapDescriptionCollection) transitionMap;
        }
        
        protected override State GetState(string stateId)
        {
            var transitionCollection = _uiMap.GetChild(stateId);
            return new UiState(this, stateId, transitionCollection);
        }

        protected override IStateTransition GetTransition(string stateId)
        {
            var uiTransitionDescription = (UiTransitionDescription) transitionData;
            
            return new WindowFactory().GetWindowTransition(uiTransitionDescription.TransitionType, uiTransitionDescription);
        }
    }
}
