using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Entity.Skills
{
    public class BreakIn : ISkillComponent
    {
        public bool IsDone => true;

        private ISkillController _controller;

        public BreakIn(ISkillController controller)
        {
            _controller = controller;

            _controller.OnTryUseSkill += (ISkill skill) =>
            {
                if((skill.Components?.Contains(this) ?? false) && 
                (!_controller.Skill?.Components?.Contains(this) ?? true))
                {
                    _controller.Skill?.Break();
                }
            };
        }
    }
}
