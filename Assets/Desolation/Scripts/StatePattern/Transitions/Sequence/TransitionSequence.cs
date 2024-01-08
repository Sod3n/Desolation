using Cysharp.Threading.Tasks;
using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class TransitionSequence : Transition, IInitializable
    {
        [Inject] private IResetTaskFactory _resetTaskFactory;
        [InjectOptional] private CancellationTokenSource _resetCancelToken = new CancellationTokenSource();

        private List<ITransition> _skills;

        public TransitionSequence(List<ITransition> skills, IStateController stateController) 
            : base(skills.First().TargetState, stateController)
        {
            _skills = skills;
        }

        public void ResetSequence()
        {
            _sequenceIndex = 0;
        }

        private void RestartResetSequenceTask()
        {
            _resetCancelToken.Cancel();
            _resetCancelToken.Dispose();
            _resetCancelToken = new CancellationTokenSource();
            _ = ResetSequenceTask();
        }
        private void IncreaseSequenceIndex()
        {
            _sequenceIndex++;

            if(_sequenceIndex >= _skills.Count)
            {
                _sequenceIndex = 0;
            }
        }

        private async UniTask ResetSequenceTask()
        {
            var reset = _resetTaskFactory.Create(_resetCancelToken.Token);

            var isCanceled = await reset.SuppressCancellationThrow();

            if (isCanceled) return;

            ResetSequence();
        }

        public void NextStep()
        {
            RestartResetSequenceTask();
            IncreaseSequenceIndex();
            Debug.Log(_sequenceIndex);
            TargetState = _skills[_sequenceIndex].TargetState;
        }

        public void Initialize()
        {
            OnInvoked += _ => NextStep();
        }

        private int _sequenceIndex = 0;
    }
}
