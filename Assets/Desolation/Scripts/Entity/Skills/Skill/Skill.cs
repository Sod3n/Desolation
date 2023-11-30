using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Entity.Skills
{
    public class Skill : ISkill
    {
        private List<ISkillComponent> _components;
        private List<ISkillComponent.IUseable> _useables;
        private List<ISkillComponent.ITickable> _tickables;
        private List<ISkillComponent.IFixedTickable> _fixedTickables;
        private List<ISkillComponent.IBreakable> _breakables;

        private ISkill.State _state;
        public ISkill.State CurrentState => _state;
        private bool _isBreaked;
        public bool IsDone
        {
            get
            {
                return _isBreaked || _components.All(c => c.IsDone);
            }
        }

        public List<ISkillComponent> Components { get => _components; }

        public Skill(List<ISkillComponent> components,
            List<ISkillComponent.ITickable> tickables,
            List<ISkillComponent.IBreakable> breakables,
            List<ISkillComponent.IUseable> useables,
            List<ISkillComponent.IFixedTickable> fixedTickables)
        {
            _components = components;
            _tickables = tickables;
            _breakables = breakables;
            _useables = useables;
            _fixedTickables = fixedTickables;
        }

        /// <summary>
        /// Set state of skill to first and use all useables components.
        /// </summary>
        public void Use()
        {
            _state = ISkill.State.First;
            _useables.ForEach(c => c.Use());
            _isBreaked = false;
        }

        /// <summary>
        /// Not execute if state is null.
        /// While its not find any _tickable or _fixedTickable components with target state as current state of skill
        /// and that not done yet it will change its state to next. When it find so it will execute Tick on finded
        /// tickables components.
        /// </summary>
        public void Tick()
        {
            LoopComponentsStates();

            if (_state is null)
                return;

            foreach (var tickable in _tickables.Where(c => c.TargetState == _state && !c.IsDone)) 
                tickable.Tick();
        }
        /// <summary>
        /// Not execute if state is null.
        /// While its not find any _tickable or _fixedTickable components with target state as current state of skill
        /// and that not done yet it will change its state to next. When it find so it will execute FixedTick on finded
        /// fixed tickables components.
        /// </summary>
        public void FixedTick()
        {
            LoopComponentsStates();

            if (_state is null)
                return;

            foreach (var tickable in _fixedTickables.Where(c => c.TargetState == _state && !c.IsDone))
                tickable.FixedTick();
        }

        /// <summary>
        /// Execute break on all breakable components that isnt done yet, nulls state of skill and make skill done.
        /// </summary>
        public void Break()
        {
            foreach(var breackable in _breakables.Where(c => !c.IsDone))
            {
                breackable.Break();
            }
            _state = null;
            _isBreaked = true;
        }

        private void LoopComponentsStates()
        {
            if (IsDone)
            {
                _state = null;
                return;
            }

            while (!_tickables.Any(c => c.TargetState == _state && !c.IsDone) &&
                !_fixedTickables.Any(c => c.TargetState == _state && !c.IsDone))
            {
                if (_state is null)
                    return;

                _state = _state.NextState;
            }
        }

        
    }
}
