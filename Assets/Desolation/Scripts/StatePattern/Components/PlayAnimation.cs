using AniMate;
using Desolation.StatePattern;
using HierarchicalStatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UPlayable.AnimationMixer;
using Zenject;

namespace Desolation.StatePattern
{
    [RequireComponent(typeof(AnimationClipOutput))]
    public class PlayAnimation : StateBehaviour
    {
        private AnimationClipOutput _animationClipOutput;

        public event Action OnPlayed;

        public override void OnEnter()
        {
            if(!_animationClipOutput)
                _animationClipOutput = GetComponent<AnimationClipOutput>();
            
            _animationClipOutput.Play();

            _animationClipOutput.OnEnd += () => OnPlayed?.Invoke();
        }
    }
}
