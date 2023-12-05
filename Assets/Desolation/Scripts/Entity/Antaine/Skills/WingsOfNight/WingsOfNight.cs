using Entity.Skills;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity.Antaine
{
    public class WingsOfNight : Skill
    {
        public WingsOfNight(List<ISkillComponent> components, List<ISkillComponent.ITickable> tickables, List<ISkillComponent.IBreakable> breakables, List<ISkillComponent.IUseable> useables, List<ISkillComponent.IFixedTickable> fixedTickables) : base(components, tickables, breakables, useables, fixedTickables)
        {
        }
    }
}
