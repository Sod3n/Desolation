using AniMate;
using Desolation.StatePattern;
using HierarchicalStatePattern;
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
    public class PlayAnimation : StateBehaviour
    {
        [Inject] private AniMateComponent _animate;
        [SerializeField] private AnimationClip _clip;
        [SerializeField] private bool _useDefaultDuration = true;
        [SerializeField] private float _clipDuration;

        public event Action OnPlayed = () => { };

        public override void OnEnter()
        {
            var state = _animate.Play(_clip);

            if(!_useDefaultDuration)
                state.Duration = _clipDuration;

            state.OnEnd += () => OnPlayed.Invoke();
        }
    }
}
