using AniMate;
using Cysharp.Threading.Tasks;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity.Skills
{
    /// <summary>
    /// Component become done when clip is ended.
    /// </summary>
    public class PlayAnimation : ISkillComponent.IFixedTickable, ISkillComponent.IUseable
    {
        private AniMateComponent _animate;
        private AnimationClip _clip;
        public ISkill.State TargetState { get; }

        public PlayAnimation(
            ISkill.State targetState, 
            AniMateComponent animate, 
            AnimationClip clip)
        {
            TargetState = targetState;
            _animate = animate;
            _clip = clip;
        }

        public bool IsDone { get; private set; }

        private bool _isAnimationPlaying;

        public void Use()
        {
            
            IsDone = false;
            _isAnimationPlaying = false;
        }

        public void FixedTick()
        {
            if(_isAnimationPlaying) return;

            _isAnimationPlaying = true;
            var state = _animate.Play(_clip);
            state.OnEnd += () => { IsDone = true; };
        }
    }
}
