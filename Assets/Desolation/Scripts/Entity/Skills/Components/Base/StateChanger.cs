using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Skills
{
    public class StateChanger 
    {
        public bool IsDone => true;

        private State.Identificator _to;
        private LazyInject<ISkill> _owner;

        public StateChanger(State.Identificator to, LazyInject<ISkill> owner)
        {
            _to = to;
            _owner = owner;
        }

        protected void ChangeState()
        {
            Skill skill = _owner.Value as Skill;

            skill.CurrentState = _to; // we want to throw null exception here
        }

    }
}
