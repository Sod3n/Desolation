using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;
using Zenject;

namespace Entity.Skills
{
    public abstract class Skill : ISkill
    {

        [Inject] private StateIterator _stateIterator;
        [Inject] public bool Breakeable { get; private set; }

        public State.Identificator CurrentState
        { 
            get => _stateIterator.State.Id; 
            set => _stateIterator.EnterState(value); 
        }

        public bool IsDone
        {
            get
            {
                return _stateIterator.State is null;
            }
        }

        public void Use()
        {
            _stateIterator.ReturnToFirstState();
        }

        public void Break()
        {
            _stateIterator.State?.Break();
            _stateIterator.EnterState(State.Identificator.None);
        }
    }
}
