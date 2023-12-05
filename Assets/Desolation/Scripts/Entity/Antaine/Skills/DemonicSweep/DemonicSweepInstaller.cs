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
            subContainer.BindInstances(DemonicSweepSettings.AttackClip);

            subContainer
                .BindInterfacesTo<PlayAnimation>()
                .AsSingle()
                .WithArguments(ISkill.State.Action);

            subContainer
                .BindInterfacesAndSelfTo<DemonicSweep>()
                .AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public AnimationClip AttackClip;
        }
    }
}
