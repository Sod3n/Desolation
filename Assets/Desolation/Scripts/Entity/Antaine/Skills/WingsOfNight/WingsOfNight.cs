using Entity.Skills;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity.Antaine
{
    public class WingsOfNight : Skill
    {
        public WingsOfNight(List<ISkillComponent> components, ISkill.StateIterator state) : base(components, state)
        {
        }
    }
}
