using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Entity.Skills
{
    public interface ISkillComponent
    {
        /// <summary>
        /// Inform skill that this component is done.
        /// </summary>
        public bool IsDone { get; }

        public interface IUseable : ISkillComponent
        {
            public void Use();
        }

        public interface ITickable : ISkillComponent
        {
            /// <summary>
            /// Note that it should be set in the constructor. Without changes at runtime.
            /// </summary>
            public ISkill.State TargetState { get; }
            /// <summary>
            /// Accure every zenject tick when state of skill equals TargetState.
            /// </summary>
            public void Tick();
        }
        public interface IFixedTickable : ISkillComponent
        {
            /// <summary>
            /// Note that it should be set in the constructor. Without changes at runtime.
            /// </summary>
            public ISkill.State TargetState { get; }
            /// <summary>
            /// Accure every zenject fixedTick when state of skill equals TargetState.
            /// </summary>
            public void FixedTick();
        }

        public interface IBreakable : ISkillComponent
        {
            /// <summary>
            /// Accure when something breaks skill. Generaly its other skill with BreakIn component.
            /// </summary>
            public void Break();
        }
    }
}
