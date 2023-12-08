using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Entity.Skills
{
    public interface IComponent
    {
        /// <summary>
        /// Inform skill that this component is done.
        /// </summary>
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
            /// <summary>
            /// Accure when something breaks skill. Generaly its other skill with BreakIn component.
            /// </summary>
            public void OnBreak();
        }
    }
}
