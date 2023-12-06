using Entity.Skills;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity.Antaine
{
    public class WorldsApart : Skill
    {
        public WorldsApart(List<ISkillComponent> components, ISkill.StateIterator state) : base(components, state)
        {
        }

        public class ChargeEvents : Charge.Events { }
    }
}
