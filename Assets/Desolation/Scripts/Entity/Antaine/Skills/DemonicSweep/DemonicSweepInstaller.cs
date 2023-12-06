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
        public Settings DemonicSweepSettings;

        public override void SilentInstall(DiContainer subContainer)
        {
            base.SilentInstall(subContainer);
            SetStatesCount(subContainer);

            subContainer.BindInstances(DemonicSweepSettings.AttackClip);

            subContainer
                .BindInterfacesTo<PlayAnimation>()
                .AsSingle()
                .WithArguments(State(0));

            subContainer
                .BindInterfacesTo<Cooldown>()
                .AsSingle()
                .WithArguments(DemonicSweepSettings.Cooldown);
        }

        [Serializable]
        public class Settings
        {
            public AnimationClip AttackClip;
            public float Cooldown;
        }
    }
}
