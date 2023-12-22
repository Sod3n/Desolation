using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Entity.Skills
{
    public abstract class SkillInstaller : ScriptableObjectInstaller
    {
        protected abstract void InstallStates();
    }

    /// <summary>
    /// Bind skill of type T to Container from silent install sub container.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SkillInstaller<T> : SkillInstaller where T : ISkill
    {
        protected StateSequenceFactory _stateSequenceFactory;

        protected bool _breakeable = false;

        public override void InstallBindings()
        {
            _stateSequenceFactory = new StateSequenceFactory();

            InstallStates();

            Container
                .BindInterfacesAndSelfTo<T>()
                .AsSingle()
                .WithArguments(_breakeable);

            Container
                .BindInterfacesTo<SkillTickableManager>()
                .AsSingle();

            Container
                .Bind<StateIterator>()
                .AsCached();
        }

        protected void MakeBreakeable()
        {
            _breakeable = true;
        }
    }

    public static class SkillInstallerExtensions
    {
        public static void BindComponent<TComponent>(
            this DiContainer container, 
            params object[] arguments) 
            where TComponent : IComponent
        {
            container
                .BindInterfacesTo<TComponent>()
                .AsCached()
                .WithArguments(arguments);
        }

        public static void BindController(
            this DiContainer container, 
            State.Identificator state)
        {
            container
                .Bind<State>()
                .AsCached()
                .WithArguments(state);
        }

        public static void BindState(
            this DiContainer container, 
            Action<DiContainer> byMethod)
        {
            container
                .Bind<State>()
                .FromSubContainerResolve()
                .ByMethod(byMethod)
                .WithKernel()
                .AsCached();
        }
    }
}
