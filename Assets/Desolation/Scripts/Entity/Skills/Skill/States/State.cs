using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Entity.Skills
{
    /// <summary>
    /// 
    /// </summary>
    public class State
    {
        [Inject] private List<IComponent> _components = new List<IComponent>();
        [Inject] private List<IComponent.IEnterable> _enterables;
        [Inject] private List<IComponent.ITickable> _tickables;
        [Inject] private List<IComponent.IFixedTickable> _fixedTickables;
        [Inject] private List<IComponent.ILateTickable> _lateTickables;
        [Inject] private List<IComponent.IBreakable> _breakables;
        [Inject] public Identificator Id { get; private set; }

        private bool _isBreaked;

        public bool IsDone
        {
            get
            {
                return _components.All(c => c.IsDone);
            }
        }

        public List<IComponent> Components { get => _components; }

        public void Enter()
        {
            _isBreaked = false;

            foreach (var enterable in _enterables)
            {
                enterable.OnStateEnter();

                if (_isBreaked) break;
            }
        }

        public void Tick()
        {
            foreach (var tickable in _tickables)
            {
                tickable.Tick();

                if (_isBreaked) break;
            }
        }

        public void FixedTick()
        {
            foreach (var tickable in _fixedTickables)
            {
                tickable.FixedTick();

                if (_isBreaked) break;
            }
        }

        public void LateTick()
        {
            foreach (var tickable in _lateTickables)
            {
                tickable.LateTick();

                if (_isBreaked) break;
            }
        }

        public void Break()
        {
            _isBreaked = true;
            foreach (var breackable in _breakables.Where(c => !c.IsDone))
            {
                breackable.OnBreak();
            }
        }

        public enum Identificator : int
        {
            None = -1
        }

        public static Identificator ToId(uint i)
        {
            return (Identificator)i;
        }
    }
}
