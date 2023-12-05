using AniMate;
using Entity.Skills;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Antaine
{
    public class PlayerInstaller : MonoInstaller
    {
        public AniMateComponent AniMateComponent;

        public override void InstallBindings()
        {
            Container
                .BindInstances(AniMateComponent);

            Container
                .BindInterfacesAndSelfTo<Input>()
                .AsSingle();

            Container
                .BindInterfacesTo<SkillController>()
                .AsSingle();

            Container
                .BindInterfacesTo<BindSkills>()
                .AsSingle();
        }

        
    }
}
