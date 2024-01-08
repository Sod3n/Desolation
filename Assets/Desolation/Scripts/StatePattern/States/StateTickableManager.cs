using Desolation.StatePattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.Entity.Skills
{
    public class StateTickableManager : 
        Zenject.ITickable, 
        Zenject.IFixedTickable, 
        Zenject.ILateTickable
    {
        [Inject] private IStateController _controller;

        private StateTickables _tickables;

        public void Tick()
        {
            _tickables = _controller.CurrentState?.Tickables;
            _tickables?.BaseTickables?.ForEach(tickable => tickable.Tick());
        }

        public void FixedTick()
        {
            _tickables = _controller.CurrentState?.Tickables;
            _tickables?.FixedTickables?.ForEach(tickable => tickable.FixedTick());
        }

        public void LateTick()
        {
            _tickables = _controller.CurrentState?.Tickables;
            _tickables?.LateTickables?.ForEach(tickable => tickable.LateTick());
        }
    }
}
