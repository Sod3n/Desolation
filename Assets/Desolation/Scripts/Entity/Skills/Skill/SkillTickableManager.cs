using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Skills
{
    public class SkillTickableManager : Zenject.ITickable,
        Zenject.IFixedTickable, Zenject.ILateTickable
    {
        [Inject] private StateIterator _stateIterator;

        public void Tick()
        {
            _stateIterator.IterateToNotDoneState()?.Tick();
        }

        public void FixedTick()
        {
            _stateIterator.IterateToNotDoneState()?.FixedTick();
        }

        public void LateTick()
        {
            _stateIterator.IterateToNotDoneState()?.LateTick();
        }
    }
}
