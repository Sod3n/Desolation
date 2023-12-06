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
        public interface IChargeable : ISkillComponent
        {
            public void Charge();
        }

        public interface ITickable : ISkillComponent
        {
            /// <summary>
            /// State of skill when all ticks accures.
            /// </summary>
            public ISkill.State TargetState { get; }
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
