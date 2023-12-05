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
        public DemonicSweep(List<ISkillComponent> components, List<ISkillComponent.ITickable> tickables, List<ISkillComponent.IBreakable> breakables, List<ISkillComponent.IUseable> useables, List<ISkillComponent.IFixedTickable> fixedTickables) : base(components, tickables, breakables, useables, fixedTickables)
        {
        }
    }
}
