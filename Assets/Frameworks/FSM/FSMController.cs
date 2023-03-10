using Basement.OEPFramework.UnityEngine._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


namespace Frameworks.FSM
{
    public class FsmController : DroppableItemBase
    {
        protected readonly List<StateBase> states = new();
        protected StateBase currentState;

        public void Start()
        {
            if (states.Count == 0)
            {
                throw new Exception("Can't start empty state controller");
            }

            currentState = states[0];
            currentState.OnEnter();
        }


        public override void Drop()
        {
            CloseCurrentState();
            
            base.Drop();
        }


        public void AddState(StateBase state)
        {
            if (states.Any(cachedState => cachedState.Id == state.Id) || !states.Contains(state))
            {
                throw new Exception("It was try adding already cached state!");
            }
            
            states.Add(state);
        }

        
        public void RemoveState(string stateTag)
        {
            var stateToRemove = states.FirstOrDefault(state => state.Tag == stateTag);

            if (stateToRemove != null)
            {
                states.Remove(stateToRemove);
            }
        }
        
        public void RemoveState(StateBase state)
        {
            states.Remove(state);
        }


        public void CloseCurrentState()
        {
            CloseState(currentState);
        }
        
        
        public void CloseState(string stateTag)
        {
            if (GetStateByTag(stateTag, out var state))
            {
                state.OnExit();
            }
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
            if (GetStateByTag(stateTag, out var state))
            {
                SetState(state);
            }
        }
        
        public void SetState(StateBase state)
        {
            if (state == null)
            {
                Debug.LogError($"State: {state} is null");
                return;
            }
            
            if (currentState == state)
            {
                Debug.LogError($"State: {state} is already started");
                return;
            }

            var defaultTransition = new DefaultStateTransition("", currentState, state);
            defaultTransition.Transit(newState =>
            {
                currentState = newState;
            });
        }

        public bool GetStateByTag(string stateTag, out StateBase state)
        {
            var requiredState = states.FirstOrDefault(s => s.Tag == stateTag);
            if (requiredState != null)
            {
                state = requiredState;
                return true;
            }

            Debug.LogError($"Cannot find state by tag: {stateTag}");
            state = null;
            return false;
        }
        
        public void Transit(string transitionTag)
        {
            var transition = currentState.stateTransitions.FirstOrDefault(t => t.TransitionTag == transitionTag);

            if (transition == null)
            {
                throw new Exception($"Cannot transit to state by tag: {transitionTag}");
            }
            
            transition.Transit(newState =>
            {
                currentState = newState;
            });
        }
    }
}
