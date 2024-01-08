using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public static class ZenjectExtensions
    {
        public static void BindComponent<TComponent>(
            this DiContainer container,
            params object[] arguments)
            where TComponent : IStateComponent
        {
            container
                .BindInterfacesAndSelfTo<TComponent>()
                .AsCached()
                .WithArguments(arguments);
        }

        public static void BindState(
            this DiContainer container,
            State state)
        {
            container
                .Bind(typeof(State), typeof(IState))
                .To<State>()
                .FromInstance(state)
                .AsCached();

            container
                .QueueForInject(state);

            container
                .Bind<StateTickables>()
                .AsCached();
        }

        public static void BindStateByMethod(
            this DiContainer container,
            Action<DiContainer> byMethod)
        {
            container
                .BindInterfacesAndSelfTo<State>()
                .FromSubContainerResolve()
                .ByMethod(byMethod)
                .AsCached()
                .NonLazy();
        }
        public static void BindTransitions<T>(
            this DiContainer container,
            params object[] arguments)
        {
            container
                .BindInterfacesAndSelfTo<T>()
                .AsCached()
                .WithArguments(arguments);
        }
        public static void BindWaitSecondsReset(
            this DiContainer container,
            WaitSecondsReset.Settings settings
            )
        {
            container
                .Bind<IResetTaskFactory>()
                .To<WaitSecondsReset>()
                .AsCached()
                .WithArguments(settings);
        }


    }
}
