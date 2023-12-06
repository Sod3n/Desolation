using Entity.Skills;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Antaine
{
    public class BasicAttack : Skill
    {
        public BasicAttack(List<ISkillComponent> components, ISkill.StateIterator state) : base(components, state)
        {
        }
    }
}
