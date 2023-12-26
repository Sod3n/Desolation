using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity.Skills
{
    public interface ISkillController
    {
        public ISkill LastUsedSkill { get; set; }

        public bool TryUseSkill(ISkill skill);

    }
}
