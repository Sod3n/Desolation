using Entity.Skills;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Antaine
{
    public class WingsOfNightInstaller : SkillInstaller<WingsOfNight>
    {
        public Settings StateSettings;

        private State.Identificator _state;

        protected override void InstallStates()
        {
            _state = _stateSequenceFactory.Create(1).State(0);

            Container.BindState(State);
        }

        private void State(DiContainer subContainer)
        {
            subContainer.BindController(_state);

            subContainer.BindComponent<PlayAnimation>(StateSettings.Action.Animation);
            subContainer.BindComponent<MoveForward>(StateSettings.Action.MoveForward);
        }

        [Serializable]
        public class Settings
        {
            public ActionState Action;

            [Serializable]
            public class ActionState
            {
                public PlayAnimation.Settings Animation;
                public MoveForward.Settings MoveForward;
            }
        }
    }
}
