using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using Zenject;

namespace Entity.Skills
{
    public class SkillSequence : SkillController, ISkill
    {
        private List<ISkill> _skills;
        private int _sequenceIndex = 0;
        private IResetTaskFactory _resetTaskFactory;
        private CancellationTokenSource _resetCancelToken;

        public bool IsDone
        {
            get
            {
                return Skill?.IsDone ?? true;
            }
        }

        public ISkill.State CurrentState => Skill?.CurrentState ?? ISkill.State.None;

        public List<ISkillComponent> Components => Skill?.Components;

        public SkillSequence(List<ISkill> ñomboSkills, 
            IResetTaskFactory resetTaskFactory)
        {
            _skills = ñomboSkills;
            _resetTaskFactory = resetTaskFactory;
            _resetCancelToken = new CancellationTokenSource();
        }

        public void Use()
        {
            if(!TryUseSkill(_skills[_sequenceIndex])) return;

            RestartResetSequence();
            IncreaseComboIndex();
        }

        public void Break()
        {
            Skill?.Break();
            _sequenceIndex = 0;
            Skill = null;
        }

        private void RestartResetSequence()
        {
            _resetCancelToken.Cancel();
            _resetCancelToken.Dispose();
            _resetCancelToken = new CancellationTokenSource();
            _ = ResetSequence();
        }
        private void IncreaseComboIndex()
        {
            _sequenceIndex++;

            if(_sequenceIndex >= _skills.Count)
            {
                _sequenceIndex = 0;
            }
        }

        private async UniTask ResetSequence()
        {
            var reset = _resetTaskFactory.Create(_resetCancelToken.Token);

            var isCanceled = await reset.SuppressCancellationThrow();

            if (isCanceled) return;

            _sequenceIndex = 0;
        }

        public void Initialize()
        {
            _skills.ForEach(skill => skill.Initialize());
        }
    }
}
