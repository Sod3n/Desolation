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

    [CreateAssetMenu(fileName = "BasicAttack", menuName = "Installers/UntitledInstaller")]
    public class BasicAttackInstaller : TransitionInstaller<BasicAttack>
    {
        public Settings StateSettings;

        protected override void InstallStates()
        {
            var stateListing = new StateListing();

            _startState = stateListing.ActionState;

            var actionState = new ActionStateFormer(stateListing, StateSettings.Action);
            Container.BindStateByMethod(actionState.Bind);
        }

        public class ActionStateFormer
        {
            private StateListing _stateListing;
            private Settings _settings;

            public ActionStateFormer(StateListing stateListing, Settings settings)
            {
                _stateListing = stateListing;
                _settings = settings;
            }

            public void Bind(DiContainer subContainer)
            {
                subContainer.BindState(_stateListing.ActionState);

                subContainer.BindComponent<PlayAnimation>(_settings.Animation);
                subContainer.BindComponent<MakeDamage>(_settings.MakeDamage);
                subContainer.BindComponent<MoveForward>(_settings.MoveForward);
                subContainer.BindComponent<LookIn>();

                subContainer.BindTransitions<Transitions>();
            }

            public class Transitions : IInitializable
            {
                [Inject] private IStateController _stateController;
                [Inject] private PlayAnimation _playAnimation;
                [Inject] private TrackSkillsTransitionGroup _skillsTransitionGroup;
                [Inject] private IState _state;

                public void Initialize()
                {
                    _playAnimation.OnPlayed += _stateController.BaseTransition.Invoke;

                    _skillsTransitionGroup.AddTransitionsToState(_state);
                }
            }

            [Serializable]
            public class Settings
            {
                public PlayAnimation.Settings Animation;
                public MoveForward.Settings MoveForward;
                public MakeDamage.Settings MakeDamage;
            }
        }


        public class StateListing
        {
            public State ActionState = new State();
        }


        [Serializable]
        public class Settings
        {
            public ActionStateFormer.Settings Action;
        }
    }
}
