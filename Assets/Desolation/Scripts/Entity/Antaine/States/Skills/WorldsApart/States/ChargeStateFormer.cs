using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.Entity.Antaine
{
    public class ChargeStateFormer
    {
        private WorldsApartInstaller.StateListing _stateListing;
        private Settings _settings;

        public ChargeStateFormer(
            WorldsApartInstaller.StateListing stateListing, 
            Settings settings)
        {
            _stateListing = stateListing;
            _settings = settings;
        }

        public void Bind(DiContainer subContainer)
        {
            subContainer.BindState(_stateListing.ChargeState);

            subContainer.BindComponent<Charge>(_settings.Charge);
            subContainer.BindComponent<PlayAnimation>(_settings.Animation);
            subContainer.BindComponent<Overcharge>(_settings.Overcharge);

            subContainer.BindTransitions<Transitions>(
                _stateListing,
                _stateListing.ChargeState);
        }

        public class Transitions : IInitializable
        {
            [Inject] private IStateController _stateController;
            [Inject] private Overcharge _overcharge;
            [Inject] private Charge.Actions _chargeActions;
            [Inject] private State _state;
            [Inject] private WorldsApartInstaller.StateListing _stateListing;

            public void Initialize()
            {
                _chargeActions.OnChargeInterapted += 
                    _state.AddTransition(_stateListing.AttackState, _stateController).Invoke;
                _overcharge.OnOvercharged += 
                    _state.AddTransition(_stateListing.OverchargeState, _stateController).Invoke;
            }
        }

        [Serializable]
        public class Settings
        {
            public PlayAnimation.Settings Animation;
            public Charge.Settings Charge;
            public Overcharge.Settings Overcharge;
        }
    }

}
