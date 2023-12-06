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
        public Settings WorldsApartSettings;

        public override void SilentInstall(DiContainer subContainer)
        {
            base.SilentInstall(subContainer);
            SetStatesCount(subContainer);

            subContainer
                .BindInterfacesAndSelfTo<Charge>()
                .AsSingle();

            subContainer
                .Bind<Charge.Events>()
                .To<WorldsApart.ChargeEvents>()
                .FromResolve()
                .AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public AnimationClip ChargeStartClip;
            public AnimationClip ChargeIdleClip;
            public AnimationClip AttackClip;
        }
    }
}
