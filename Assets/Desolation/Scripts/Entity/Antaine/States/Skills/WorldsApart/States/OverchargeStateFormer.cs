using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.Entity.Antaine
{
    public class OverchargeStateFormer
    {
        private WorldsApartInstaller.StateListing _stateListing;
        private Settings _settings;

        public OverchargeStateFormer(
            WorldsApartInstaller.StateListing stateListing, 
            Settings settings)
        {
            _stateListing = stateListing;
            _settings = settings;
        }

        public void Bind(DiContainer subContainer)
        {
            subContainer.BindState(_stateListing.OverchargeState);

            subContainer.BindComponent<WaitSeconds>(_settings.WaitSeconds);
            subContainer.BindComponent<PlayAnimation>(_settings.Animation);

            subContainer.BindTransitions<Transitions>();
        }

        public class Transitions : IInitializable
        {
            [Inject] private IStateController _stateController;
            [Inject] private WaitSeconds _waitSeconds;
            [Inject] private State _state;

            public void Initialize()
            {
                _waitSeconds.OnCompleted += _stateController.BaseTransition.Invoke;
            }
        }

        [Serializable]
        public class Settings
        {
            public PlayAnimation.Settings Animation;
            public WaitSeconds.Settings WaitSeconds;
        }
    }

}
