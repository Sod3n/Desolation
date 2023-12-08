using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Skills
{
    public class StateSequenceFactory
    {
        private uint _nextStateIndex = 0;

        public StateSequence Create(int length)
        {
            List<State.Identificator> states = new List<State.Identificator>();

            for(int i = 0; i < length; i++)
            {
                states.Add(NextState());
            }

            EndStateSequence();

            return new StateSequence(states);
        }

        private State.Identificator NextState()
        {
            var state = State.ToId(_nextStateIndex);

            _nextStateIndex++;

            return state;
        }

        private void EndStateSequence()
        {
            _nextStateIndex++;
        }
    }
}
