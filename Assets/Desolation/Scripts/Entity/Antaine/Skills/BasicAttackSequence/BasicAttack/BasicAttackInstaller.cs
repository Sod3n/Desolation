using Entity.Skills;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace Entity.Antaine
{

    [CreateAssetMenu(fileName = "BasicAttack", menuName = "Installers/UntitledInstaller")]
    public class BasicAttackInstaller : SkillInstaller<BasicAttack>
    {
        public Settings BasicAttackSettings;

        public override void SilentInstall(DiContainer subContainer)
        {
            base.SilentInstall(subContainer);
            SetStatesCount(subContainer);

            subContainer.BindInstances(BasicAttackSettings.AttackClip);

            subContainer
                .BindInterfacesTo<PlayAnimation>()
                .AsSingle()
                .WithArguments(State(0));
        }

        [Serializable]
        public class Settings
        {
            public AnimationClip AttackClip;
        }
    }
}
