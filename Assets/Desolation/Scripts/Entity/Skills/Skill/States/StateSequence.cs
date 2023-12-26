using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity.Skills
{
    public class StateSequence
    {
        private List<State.Identificator> _states = new List<State.Identificator>();

        public StateSequence(List<State.Identificator> states)
        {
            _states = states;
        }

        public State.Identificator State(int index)
        {
            return _states[index];
        }
    }
}
