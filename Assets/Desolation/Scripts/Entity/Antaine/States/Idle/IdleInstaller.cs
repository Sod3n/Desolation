using Desolation.Entity.Skills;
using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace Desolation.Entity.Antaine
{

    public class IdleInstaller : TransitionInstaller<Idle>
    {
        public Settings StateSettings;

        protected override void InstallStates()
        {
            var stateListing = new StateListing();

            _startState = stateListing.IdleState;

            var idleState = new IdleStateFormer(stateListing, StateSettings.Idle);
            Container.BindStateByMethod(idleState.Bind);
        }

        public class IdleStateFormer
        {
            private StateListing _stateListing;
            private Settings _settings;

            public IdleStateFormer(StateListing stateListing, Settings settings)
            {
                _stateListing = stateListing;
                _settings = settings;
            }

            public void Bind(DiContainer subContainer)
            {
                subContainer.BindComponent<PlayAnimation>(_settings.Animation);

                subContainer.BindTransitions<Transitions>();

                subContainer.BindState(_stateListing.IdleState);

            }

            public class Transitions : IInitializable
            {
                [Inject] private IStateController _stateController;
                [Inject] private TrackSkillsTransitionGroup _skillsTransitionGroup;
                [Inject] private State _state;

                public void Initialize()
                {
                    _skillsTransitionGroup.AddTransitionsToState(_state);
                }
            }

            [Serializable]
            public class Settings
            {
                public PlayAnimation.Settings Animation;
            }
        }


        public class StateListing
        {
            public State IdleState = new State();
        }


        [Serializable]
        public class Settings
        {
            public IdleStateFormer.Settings Idle;
        }
    }
}
