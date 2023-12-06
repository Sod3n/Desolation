using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Entity.Skills
{
    public class BreakIn : ISkillComponent, IInitializable
    {
        public bool IsDone => true;

        private ISkillController _controller;
        private LazyInject<ISkill> _owner;

        public BreakIn(ISkillController controller, LazyInject<ISkill> owner)
        {
            _controller = controller;
            _owner = owner;
        }

        public void Initialize()
        {
            _controller.TryingUse += (ISkill skill) =>
            {
                if (skill == _owner.Value && _controller.Skill != _owner.Value)
                {
                    _controller.Skill?.Break();
                }
            };
        }
    }
}
