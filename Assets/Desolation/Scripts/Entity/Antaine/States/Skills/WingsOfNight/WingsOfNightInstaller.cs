using Desolation.Entity.Skills;
using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Desolation.Entity.Antaine
{
    public class WingsOfNightInstaller : TransitionInstaller<WingsOfNight>
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
                subContainer.BindComponent<MoveForward>(_settings.MoveForward);

                subContainer.BindTransitions<Transitions>();
            }

            public class Transitions : IInitializable
            {
                [Inject] private IStateController _stateController;
                [Inject] private PlayAnimation _playAnimation;
                [Inject] private IState _state;

                public void Initialize()
                {
                    _playAnimation.OnPlayed += _stateController.BaseTransition.Invoke;
                }
            }

            [Serializable]
            public class Settings
            {
                public PlayAnimation.Settings Animation;
                public MoveForward.Settings MoveForward;
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
