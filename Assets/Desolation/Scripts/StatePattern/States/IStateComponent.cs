using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;

namespace Desolation.StatePattern
{
    public interface IStateComponent
    {
        public interface IEnterable : IStateComponent
        {
            public void OnEnter();
        }
        public interface ITickable : IStateComponent
        {
            public void Tick();
        }
        public interface IFixedTickable : IStateComponent
        {
            public void FixedTick();
        }
        public interface ILateTickable : IStateComponent
        {
            public void LateTick();
        }
        public interface IExitable : IStateComponent
        {
            public void OnExit();
        }
        public interface IInitializable : IStateComponent, Zenject.IInitializable
        {

        }
    }
}
