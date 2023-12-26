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
    public class SkillSequence : ISkill
    {
        [Inject] private List<ISkill> _skills;
        [Inject] private IResetTaskFactory _resetTaskFactory;
        [Inject] public bool Breakeable { get; private set; }
        [InjectOptional] private CancellationTokenSource _resetCancelToken = new CancellationTokenSource();
        
        
        public bool IsDone
        {
            get
            {
                return _currentSkill?.IsDone ?? true;
            }
        }

        public State.Identificator CurrentState 
        { 
            get => _currentSkill?.CurrentState ?? State.Identificator.None; 
        }

        public void Use()
        {
            _currentSkill = _skills[_sequenceIndex];
            _currentSkill.Use();
            RestartResetSequence();
            IncreaseComboIndex();
        }

        public void Break()
        {
            _currentSkill?.Break();
            _sequenceIndex = 0;
            _currentSkill = null;
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

        private int _sequenceIndex = 0;

        private ISkill _currentSkill;
    }
}
