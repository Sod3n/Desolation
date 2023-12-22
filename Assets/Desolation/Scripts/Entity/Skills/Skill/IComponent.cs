using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Entity.Skills
{
    public interface IComponent
    {
        public bool IsDone { get; }

        public interface IEnterable : IComponent
        {
            public void OnStateEnter();
        }

        public interface ITickable : IComponent
        {
            public void Tick();
        }
        public interface IFixedTickable : IComponent
        {
            public void FixedTick();
        }
        public interface ILateTickable : IComponent
        {
            public void LateTick();
        }
        public interface IBreakable : IComponent
        {
            public void OnBreak();
        }
    }
}
