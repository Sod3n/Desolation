using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity.Skills
{
    public interface ISkillController :  Zenject.ITickable, Zenject.IFixedTickable, Zenject.ILateTickable
    {
        /// <summary>
        /// Last used skill.
        /// </summary>
        public ISkill Skill { get; set; }

        /// <summary>
        /// Event that is called when trying to use a skill, before checking if current skill done.
        /// </summary>
        public event Action<ISkill> TryingUse;

        /// <summary>
        /// Use skill if possible(if previus skill is done or something make its done on OnTryUseSkill event).
        /// </summary>
        /// <param name="skill"></param>
        /// <returns></returns>
        public bool TryUseSkill(ISkill skill);

    }
}
