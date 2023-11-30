using Cysharp.Threading.Tasks;
using Entity.Skills;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Entity.Antaine
{
    public class BasicAttackSequence : SkillSequence
    {
        public BasicAttackSequence(List<ISkill> ñomboSkills, IResetTaskFactory resetTaskFactory) 
            : base(ñomboSkills, resetTaskFactory)
        {
        }
    }
}
