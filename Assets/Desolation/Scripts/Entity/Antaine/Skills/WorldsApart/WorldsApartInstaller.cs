using Entity.Skills;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Antaine
{
    public class WorldsApartInstaller : SkillInstaller<WorldsApart>
    {
        public Settings StateSettings;
        private States _states = new States();

        protected override void InstallStates()
        {
            var baseStateSequence = _stateSequenceFactory.Create(3);

            _states.Prepare = baseStateSequence.State(0);
            _states.Charge = baseStateSequence.State(1);
            _states.Attack = baseStateSequence.State(2);

            var overchargeStateSequence = _stateSequenceFactory.Create(1);

            _states.Overcharge = overchargeStateSequence.State(0);

            Container
                .Bind<Charge.Power>()
                .AsSingle();

            Container
                .Bind<Charge.Events>()
                .To<WorldsApart.ChargeEvents>()
                .FromResolve()
                .AsSingle();

            Container.BindState(PrepareState);
            Container.BindState(ChargeState);
            Container.BindState(AttackState);
            Container.BindState(OverchargeState);
        }

        private void PrepareState(DiContainer subContainer)
        {
            subContainer.BindController(_states.Prepare);

            subContainer.BindComponent<Cooldown>(StateSettings.Prepare.Cooldown);
            subContainer.BindComponent<PlayAnimation>(StateSettings.Prepare.Animation);
            subContainer.BindComponent<LookIn>();
        }

        private void ChargeState(DiContainer subContainer)
        {
            subContainer.BindController(_states.Charge);

            subContainer.BindComponent<Charge>(StateSettings.Charge.Charge);
            subContainer.BindComponent<PlayAnimation>(StateSettings.Charge.Animation);
            subContainer.BindComponent<ChangeStateOnOvercharge>(
                StateSettings.Charge.ChangeStateOnOvercharge,
                _states.Overcharge
                );
        }

        private void AttackState(DiContainer subContainer)
        {
            subContainer.BindController(_states.Attack);

            subContainer.BindComponent<PlayAnimation>(StateSettings.Attack.Animation);
            subContainer.BindComponent<MakeDamageByCharge>(StateSettings.Attack.Damage);
        }

        private void OverchargeState(DiContainer subContainer)
        {
            subContainer.BindController(_states.Overcharge);

            subContainer.BindComponent<WaitSeconds>(StateSettings.Overcharge.WaitSeconds);
            subContainer.BindComponent<PlayAnimation>(StateSettings.Overcharge.Animation);
        }

        private class States
        {
            public State.Identificator Prepare;
            public State.Identificator Charge;
            public State.Identificator Attack;
            public State.Identificator Overcharge;
        }


        [Serializable]
        public class Settings
        {
            public PrepareState Prepare;
            public ChargeState Charge;
            public AttackState Attack;
            public OverchargeState Overcharge;


            [Serializable]
            public class PrepareState
            {
                public PlayAnimation.Settings Animation;
                public Cooldown.Settings Cooldown;
            }
            [Serializable]
            public class ChargeState
            {
                public PlayAnimation.Settings Animation;
                public Charge.Settings Charge;
                public ChangeStateOnOvercharge.Settings ChangeStateOnOvercharge;
            }
            [Serializable]
            public class AttackState
            {
                public PlayAnimation.Settings Animation;
                public MakeDamageByCharge.Settings Damage;
                
            }
            [Serializable]
            public class OverchargeState
            {
                public PlayAnimation.Settings Animation;
                public WaitSeconds.Settings WaitSeconds;
            }
        }
    }
}
