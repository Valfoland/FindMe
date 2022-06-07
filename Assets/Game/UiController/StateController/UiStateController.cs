using System;
using Frameworks.StateMachine;
using Game.BusinessLogic.Descriptions;
using Game.BusinessLogic.Utils;

namespace Game.UiController.StateController
{
    public class UiStateController : Frameworks.StateMachine.StateController
    {
        private readonly UiMapDescriptionCollection _uiMap;
        
        public UiStateController()
        {
            _uiMap = GameManager.context.GetChild<UiMapDescriptionCollection>(DataUtil.Entities.UiMap);
        }
        
        protected override State GetState(Action<IStateTransitionData> onSetTransition, IStateTransitionData transitionData)
        {
            var transitionCollection = _uiMap.GetChild(transitionData.GetStateKey());
            return new UiState(onSetTransition, transitionData, transitionCollection);
        }

        protected override IStateTransition GetTransition()
        {
            throw new NotImplementedException();
        }
    }
}
