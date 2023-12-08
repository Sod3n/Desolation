using AniMate;
using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Skills
{
    /// <summary>
    /// Component become done when on clip end. 
    /// </summary>
    public class PlayAnimation : IComponent.IEnterable
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


        public bool IsDone { get; private set; }

        public void OnStateEnter()
        {
            IsDone = false;
            var state = _animate.Play(_settings.Clip);

            if (_settings.WaitClipEnd)
            {
                state.OnEnd += () => { IsDone = true; };
            }
            else
            {
                IsDone = true;
            }
        }

        [Serializable]
        public class Settings
        {
            public AnimationClip Clip;
            public bool WaitClipEnd = true;
        }
    }
}
