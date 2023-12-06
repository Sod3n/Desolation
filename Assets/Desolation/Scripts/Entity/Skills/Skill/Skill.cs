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
        private List<ISkillComponent.IBreakable> _breakables;
        private List<Zenject.IInitializable> _initializables;

        private ISkill.StateIterator _stateIterator;
        public ISkill.State CurrentState => _stateIterator.State;
        private bool _isBreaked;
        public bool IsDone
        {
            get
            {
                return _isBreaked || _components.All(c => c.IsDone);
            }
        }

        public List<ISkillComponent> Components { get => _components; }

        public Skill(List<ISkillComponent> components, ISkill.StateIterator state)
        {
            _components = components;
            _stateIterator = state;
        }

        /// <summary>
        /// Set state of skill to first and use all useables components.
        /// </summary>
        public void Use()
        {
            _stateIterator.Reset();
            _isBreaked = false;

            _useables.ForEach(c => c.Use());
        }

        /// <summary>
        /// Do some init logic of skill and initialize all initializable components.
        /// </summary>
        public void Initialize()
        {
            SortComponentsByInterfaces();

            _initializables.ForEach(c => c.Initialize());
        }


        /// <summary>
        /// Not execute if state is null.
        /// While its not find any _tickable component with target state as current state of skill
        /// and that not done yet it will change skill state to next. When it find this it will execute Tick on finded
        /// tickables components.
        /// </summary>
        public void Tick()
        {
            foreach(var tickable in TickablesOfType<Zenject.ITickable>())
            {
                tickable.Tick();
            }
        }

        /// <summary>
        /// Same as tick, but for fixed tick of zenject.
        /// </summary>
        public void FixedTick()
        {
            foreach (var tickable in TickablesOfType<Zenject.IFixedTickable>())
            {
                tickable.FixedTick();
            }
        }

        /// <summary>
        /// Same as tick, but for late tick of zenject.
        /// </summary>
        public void LateTick()
        {
            foreach (var tickable in TickablesOfType<Zenject.ILateTickable>())
            {
                tickable.LateTick();
            }
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
            _stateIterator.State = ISkill.State.None;
            _isBreaked = true;
        }

        private void SortComponentsByInterfaces()
        {
            _useables = _components.OfType<ISkillComponent.IUseable>().ToList();
            _tickables = _components.OfType<ISkillComponent.ITickable>().ToList();
            _breakables = _components.OfType<ISkillComponent.IBreakable>().ToList();
            _initializables = _components.OfType<Zenject.IInitializable>().ToList();
        }
        private IEnumerable<T> TickablesOfType<T>() where T : class
        {
            LoopComponentsStates();

            if (_stateIterator.IsNone())
                yield break;

            foreach (var tickable in _tickables.Where(c => c.TargetState == _stateIterator.State && !c.IsDone))
            {
                var concreteTickable = tickable as T;

                if (concreteTickable is null) continue;

                yield return concreteTickable;
            }
        }

        private void LoopComponentsStates()
        {
            if (IsDone)
            {
                _stateIterator.State = ISkill.State.None;
                return;
            }

            while (!_tickables.Any(c => c.TargetState == _stateIterator.State && !c.IsDone))
            {
                if (_stateIterator.IsNone())
                    return;

                _stateIterator.NextState();
            }
        }
    }
}
