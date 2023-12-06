using Entity.Skills;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Antaine
{
    public class DemonicSweep : Skill
    {

        public DemonicSweep(List<ISkillComponent> components, ISkill.StateIterator state) : base(components, state)
        {
        }
    }
}
