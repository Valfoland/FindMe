using Basement.OEPFramework.UnityEngine._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Frameworks.FSM
{
    public class FsmController : DroppableItemBase
    {
        private readonly List<StateBase> _states = new();
        private StateBase _currentState;


        public void Start()
        {
            if (_states.Count == 0)
            {
                throw new Exception("Can't start empty state controller");
            }

            _currentState = _states[0];
            _currentState.OnEnter();
        }


        public override void Drop()
        {
            CloseCurrentState();

            foreach (var state in _states)
            {
                state.Drop();
            }
            
            _states.Clear();

            base.Drop();
        }


        public void AddState(StateBase state)
        {
            if (_states.Any(cachedState => cachedState.Id == state.Id))
            {
                throw new Exception("This was a try of adding an already cached state!");
            }

            _states.Add(state);

            state.OnFinishState += () => StateBase_OnFinishState(state);
        }


        public void RemoveState(string stateId)
        {
            var stateToRemove = _states.FirstOrDefault(state => state.Id == stateId);

            if (stateToRemove != null)
            {
                _states.Remove(stateToRemove);
            }
        }


        public void RemoveState(StateBase state)
        {
            _states.Remove(state);
        }


        public void CloseCurrentState()
        {
            CloseState(_currentState);
        }


        public void CloseState(string stateTag)
        {
            GetStateById(stateTag).OnExit();
        }


        public void CloseState(StateBase state)
        {
            if (state == null)
            {
                Debug.LogError($"State: {state} is null");
                return;
            }

            state.OnExit();
        }


        public void SetState(string stateTag)
        {
            SetState(GetStateById(stateTag));
        }


        public void SetState(StateBase state)
        {
            if (state == null)
            {
                Debug.LogError($"State: {state} is null");
                return;
            }

            if (_currentState == state)
            {
                return;
            }

            var defaultTransition = new StateTransition(_currentState, state, null);
            defaultTransition.Transit(newState => { _currentState = newState; });
        }


        public StateBase GetStateById(string stateId)
        {
            var requiredState = _states.FirstOrDefault(s => s.Id == stateId);
            if (requiredState != null)
            {
                return requiredState;
            }

            throw new Exception($"Cannot transit to state by tag: {stateId}");
        }


        public void Transit(string stateTag, Action<StateBase> onCompleted)
        {
            Transit(GetStateById(stateTag), onCompleted);
        }


        public void Transit(StateBase state, Action<StateBase> onCompleted)
        {
            foreach (var stateTransition in state.stateTransitions)
            {
                if (!stateTransition.Check())
                {
                    continue;
                }

                stateTransition.Transit(onCompleted);
                return;
            }

            throw new Exception($"Cannot transit from state: {state.Id}");
        }


        private void StateBase_OnFinishState(StateBase state)
        {
            Transit(state, null);
        }
    }
}