using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.Entity.Antaine
{
    public class AttackStateFormer
    {
        private WorldsApartInstaller.StateListing _stateListing;
        private Settings _settings;

        public AttackStateFormer(
            WorldsApartInstaller.StateListing stateListing, 
            Settings settings)
        {
            _stateListing = stateListing;
            _settings = settings;
        }

        public void Bind(DiContainer subContainer)
        {
            subContainer.BindState(_stateListing.AttackState);

            subContainer.BindComponent<PlayAnimation>(_settings.Animation);
            subContainer.BindComponent<MakeDamageByCharge>(_settings.Damage);

            subContainer.BindTransitions<Transitions>();
        }

        public class Transitions : IInitializable
        {
            [Inject] private IStateController _stateController;
            [Inject] private PlayAnimation _playAnimation;

            public void Initialize()
            {
                _playAnimation.OnPlayed += _stateController.BaseTransition.Invoke;
            }
        }

        [Serializable]
        public class Settings
        {
            public PlayAnimation.Settings Animation;
            public MakeDamageByCharge.Settings Damage;
        }
    }

}
