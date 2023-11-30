using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Skills
{
    public class SkillController : ISkillController, ITickable, IFixedTickable
    {
        public ISkill Skill { get; set; }

        public event Action<ISkill> OnTryUseSkill = (_) => { };

        private bool _IsCurrentSkillDone
        {
            get => Skill?.IsDone ?? true;
        }

        public void FixedTick()
        {
            if(_IsCurrentSkillDone) return;

            Skill?.FixedTick();
        }

        public void Tick()
        {
            if (_IsCurrentSkillDone) return;

            Skill?.Tick();
        }

        public bool TryUseSkill(ISkill skill)
        {
            OnTryUseSkill.Invoke(skill);

            if (!Skill?.IsDone ?? false) return false;

            Skill = skill;
            Skill.Use();

            return true;
        }
    }
}
