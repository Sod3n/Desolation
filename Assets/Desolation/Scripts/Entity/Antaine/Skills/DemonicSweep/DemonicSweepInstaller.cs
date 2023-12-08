using Entity.Skills;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace Entity.Antaine
{

    //[CreateAssetMenu(fileName = "BasicAttack", menuName = "Installers/UntitledInstaller")]
    public class DemonicSweepInstaller : SkillInstaller<DemonicSweep>
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

            subContainer.BindComponent<Cooldown>(StateSettings.Action.Cooldown);
            subContainer.BindComponent<PlayAnimation>(StateSettings.Action.Animation);
            subContainer.BindComponent<MoveForward>(StateSettings.Action.MoveForward);
            subContainer.BindComponent<MakeDamage>(StateSettings.Action.MakeDamage);
            subContainer.BindComponent<LookIn>();
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
                public MakeDamage.Settings MakeDamage;
                public Cooldown.Settings Cooldown;
            }
        }
    }
}
