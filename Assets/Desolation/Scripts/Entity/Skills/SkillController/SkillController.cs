using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Skills
{
    public class SkillController : ISkillController
    {
        public ISkill LastUsedSkill { get; set; }


        public bool TryUseSkill(ISkill skill)
        {

            if (!LastUsedSkill?.IsDone ?? false)
            {
                if(LastUsedSkill.Breakeable && LastUsedSkill != skill)
                    LastUsedSkill?.Break();
                else
                    return false;
            }

            LastUsedSkill = skill;
            LastUsedSkill?.Use();

            return true;
        }
    }
}
