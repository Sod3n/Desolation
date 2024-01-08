using Desolation.Entity.Skills;
using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.Entity.Antaine
{
    public class WorldsApartInstaller : TransitionInstaller<WorldsApart>
    {
        public Settings StateSettings;

        protected override void InstallStates()
        {
            var stateListing = new StateListing();

            _startState = stateListing.PrepareState;

            Container.Bind<Charge.Power>().AsSingle();

            Container
                .Bind<Charge.Actions>()
                .To<WorldsApart.ChargeActions>()
                .FromResolve()
                .AsCached();


            var prepareState = new PrepareStateFormer(stateListing, StateSettings.Prepare);
            Container.BindStateByMethod(prepareState.Bind);

            var chargeState = new ChargeStateFormer(stateListing, StateSettings.Charge);
            Container.BindStateByMethod(chargeState.Bind);

            var attackState = new AttackStateFormer(stateListing, StateSettings.Attack);
            Container.BindStateByMethod(attackState.Bind);

            var overchargeState = new OverchargeStateFormer(stateListing, StateSettings.Overcharge);
            Container.BindStateByMethod(overchargeState.Bind);
        }

        

        public class StateListing
        {
            public State PrepareState = new State();
            public State ChargeState = new State();
            public State AttackState = new State();
            public State OverchargeState = new State();
        }


        [Serializable]
        public class Settings
        {
            public PrepareStateFormer.Settings Prepare;
            public ChargeStateFormer.Settings Charge;
            public AttackStateFormer.Settings Attack;
            public OverchargeStateFormer.Settings Overcharge;
        }
    }
}
