using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

namespace Entity.Skills
{
    public class WaitSecondsReset : IResetTaskFactory
    {
        private Settings _settings;

        public WaitSecondsReset(Settings settings)
        {
            _settings = settings;
        }

        public UniTask Create(CancellationToken cancellationToken)
        {
            return UniTask.WaitForSeconds(_settings.Seconds, false, PlayerLoopTiming.Update, cancellationToken);
        }

        [Serializable]
        public class Settings
        {
            public float Seconds;
        }
    }
}
