using Desolation.Entity.Skills;
using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
namespace Desolation.Entity.Antaine
{
    public class PrepareStateFormer
    {
        private WorldsApartInstaller.StateListing _stateListing;
        private Settings _settings;

        public PrepareStateFormer(
            WorldsApartInstaller.StateListing stateListing, 
            Settings settings)
        {
            _stateListing = stateListing;
            _settings = settings;
        }

        public void Bind(DiContainer subContainer)
        {
            subContainer.BindState(_stateListing.PrepareState);

            subContainer.BindComponent<PlayAnimation>(_settings.Animation);
            subContainer.BindComponent<LookIn>();

            subContainer.BindTransitions<Transitions>(_stateListing);

            subContainer.BindComponent<Cooldown>(_settings.Cooldown);
        }

        public class Transitions : IInitializable
        {
            [Inject] private IStateController _stateController;
            [Inject] private PlayAnimation _playAnimation;
            [Inject] private State _state;
            [Inject] private WorldsApartInstaller.StateListing _stateListing;
            [Inject] private Cooldown _cooldown;

            public void Initialize()
            {
                _cooldown.OnEnteredWhenInColldown += _stateController.BaseTransition.Invoke;

                _playAnimation.OnPlayed += 
                    _state.AddTransition(_stateListing.ChargeState, _stateController).Invoke;
            }
        }

        [Serializable]
        public class Settings
        {
            public PlayAnimation.Settings Animation;
            public Cooldown.Settings Cooldown;
        }
    }

}
