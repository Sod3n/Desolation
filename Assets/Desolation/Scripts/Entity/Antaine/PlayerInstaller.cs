using AniMate;
using Entity.Skills;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using ZenjectExtender;

namespace Entity.Antaine
{
    public class PlayerInstaller : MonoInstaller
    {
        public AniMateComponent AniMateComponent;
        public Transform Transform;
        public CharacterController CharacterController;

        public WorldsApartInstaller WorldsApartInstaller;
        public WingsOfNightInstaller WingsOfNightInstaller;
        public DemonicSweepInstaller DemonicSweepInstaller;
        public BasicAttackSequenceInstaller BasicAttackSequenceInstaller;

        public override void InstallBindings()
        {
            Container
                .BindInstances(AniMateComponent, Transform, CharacterController);

            Container
                .BindInterfacesAndSelfTo<Input>()
                .AsSingle();

            Container
                .BindInterfacesTo<SkillController>()
                .AsSingle();

            Container
                .Bind<WorldsApart.ChargeEvents>()
                .AsSingle();

            Container
                .Bind<LookIn.Direction>()
                .AsSingle();

            Container
                .BindInterfacesTo<BindInput>()
                .AsSingle();

            Container
                .Bind<WorldsApart>()
                .FromSubContainerResolve()
                .ByNewGameObjectScriptableInstaller(WorldsApartInstaller)
                .AsCached();

            Container
                .Bind<WingsOfNight>()
                .FromSubContainerResolve()
                .ByNewGameObjectScriptableInstaller(WingsOfNightInstaller)
                .AsCached();

            Container
                .Bind<DemonicSweep>()
                .FromSubContainerResolve()
                .ByNewGameObjectScriptableInstaller(DemonicSweepInstaller)
                .AsCached();

            Container
                .Bind<BasicAttackSequence>()
                .FromSubContainerResolve()
                .ByNewGameObjectScriptableInstaller(BasicAttackSequenceInstaller)
                .AsCached();
        }

        
    }
}
