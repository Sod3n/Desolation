using AniMate;
using Desolation.Entity.Skills;
using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using Zenject;
using ZenjectExtender;

namespace Desolation.Entity.Antaine
{
    public class PlayerInstaller : MonoInstaller
    {
        public AniMateComponent AniMateComponent;
        public Transform Transform;
        public CharacterController CharacterController;

        public IdleInstaller IdleInstaller;

        public WorldsApartInstaller WorldsApartInstaller;
        public WingsOfNightInstaller WingsOfNightInstaller;
        public DemonicSweepInstaller DemonicSweepInstaller;
        public BasicAttackSequenceInstaller BasicAttackSequenceInstaller;

        public override void InstallBindings()
        {
            Container
                .BindInstances(AniMateComponent, Transform, CharacterController);


            Container
                .BindInterfacesAndSelfTo<StateController>()
                .AsCached();

            Container
                .BindInterfacesAndSelfTo<Idle>()
                .FromSubContainerResolve()
                .ByNewGameObjectScriptableInstaller(IdleInstaller)
                .AsCached()
                .WhenNotInjectedInto<TransitionSequence>();

            

            Container
                .BindInterfacesAndSelfTo<StateTickableManager>()
                .AsCached();


            Container
                .Bind<WorldsApart.ChargeActions>()
                .AsSingle();


            Container
                .Bind<LookIn.Direction>()
                .AsSingle();


            Container
                .BindInterfacesAndSelfTo<Input>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<TrackMouseInput>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<TrackWorldApartCharge>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<TrackSkillsTransitionGroup>()
                .FromSubContainerResolveAll()
                .ByMethod(BindSkillsTransitor)
                .AsSingle();

        }

        private void BindSkillsTransitor(DiContainer subContainer)
        {

            subContainer
                .BindInterfacesAndSelfTo<TrackSkillsTransitionGroup>()
                .AsSingle();



            subContainer
                .BindInterfacesAndSelfTo<WorldsApart>()
                .FromSubContainerResolve()
                .ByNewGameObjectScriptableInstaller(WorldsApartInstaller)
                .AsCached()
                .WhenInjectedInto<TrackSkillsTransitionGroup>();

            subContainer
                .BindInterfacesAndSelfTo<WingsOfNight>()
                .FromSubContainerResolve()
                .ByNewGameObjectScriptableInstaller(WingsOfNightInstaller)
                .AsCached()
                .WhenInjectedInto<TrackSkillsTransitionGroup>();

            subContainer
                .BindInterfacesAndSelfTo<DemonicSweep>()
                .FromSubContainerResolve()
                .ByNewGameObjectScriptableInstaller(DemonicSweepInstaller)
                .AsCached()
                .WhenInjectedInto<TrackSkillsTransitionGroup>();

            subContainer
                .BindInterfacesAndSelfTo<BasicAttackSequence>()
                .FromSubContainerResolve()
                .ByNewGameObjectScriptableInstaller(BasicAttackSequenceInstaller)
                .AsCached()
                .WhenInjectedInto<TrackSkillsTransitionGroup>();
        }
    }
}
