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
        public Settings DashSettings;

        public override void SilentInstall(DiContainer subContainer)
        {
            subContainer.BindInstances(DashSettings.Clip);

            subContainer
                .BindInterfacesTo<PlayAnimation>()
                .AsSingle()
                .WithArguments(ISkill.State.Action);

            subContainer
                .BindInterfacesTo<BreakIn>()
                .AsSingle();

            subContainer
                .BindInterfacesAndSelfTo<WingsOfNight>()
                .AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public AnimationClip Clip;
        }
    }
}
