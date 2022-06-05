using System;
using Frameworks.StateMachine;
using Game.BusinessLogic.Descriptions;
using Game.UiController.Windows.WindowsUi;

namespace Game.UiController.StateController
{
    public class UiState : State
    {
        private readonly UiTransitionDescriptionCollection _transitionCollection;

        public UiState(StateContext context, UiTransitionDescriptionCollection transitionCollection) : base(context)
        {
            _transitionCollection = transitionCollection;
        }
        
        protected override IStateAction GetStateAction()
        {
            throw new NotImplementedException();
        }

        protected override IStateTransition GetTransition()
        {
            var transitionDescription = _transitionCollection.GetChild(transitionKey);
            //onSetTransition?.Invoke(transitionDescription);
        }
    }
}
