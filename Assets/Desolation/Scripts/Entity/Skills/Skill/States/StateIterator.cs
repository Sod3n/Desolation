using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Entity.Skills
{
    public class StateIterator
    {
        public StateIterator(List<State> states)
        {
            _states = states;
        }


        public State State 
        {
            get => _state;
        }

        /// <summary>
        /// Find state controller of state and enters it.
        /// </summary>
        /// <param name="state"></param>
        public void EnterState(State.Identificator state)
        {
            _state = _states.Where(s => s.Id == state).FirstOrDefault();
            _state?.Enter();
        }

        public void ReturnToFirstState()
        {
            EnterState(_states.Min(s => s.Id));
        }

        /// <summary>
        /// Change state on next while will not find not done state. 
        /// If so returns its controller.
        /// If all states are done will return null.
        /// </summary>
        /// <returns></returns>
        public State IterateToNotDoneState()
        {
            while (State?.IsDone ?? false)
            {
                NextState();
            }

            return State;
        }

        private void NextState()
        {
            EnterState(_state.Id + 1);
        }

        private State _state;
        private List<State> _states = new List<State>();
    }
}
