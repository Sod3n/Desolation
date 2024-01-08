using AniMate;
using Cysharp.Threading.Tasks;
using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    /// <summary>
    /// Component become done when on clip end. 
    /// </summary>
    public class PlayAnimation : IStateComponent.IEnterable
    {
        private AniMateComponent _animate;
        private Settings _settings;

        public PlayAnimation(
            AniMateComponent animate,
            Settings settings)
        {
            _animate = animate;
            _settings = settings;
        }

        public event Action OnPlayed;

        public void OnEnter()
        {
            var state = _animate.Play(_settings.Clip);

            state.OnEnd += OnPlayed;
        }

        [Serializable]
        public class Settings
        {
            public AnimationClip Clip;
        }
    }
}
