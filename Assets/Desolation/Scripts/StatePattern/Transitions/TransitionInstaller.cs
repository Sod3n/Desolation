using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public abstract class TransitionInstaller : ScriptableObjectInstaller
    {
        protected abstract void InstallStates();
    }

    /// <summary>
    /// Bind skill of type T to Container from silent install sub container.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class TransitionInstaller<T> : TransitionInstaller where T : ITransition
    {
        protected IState _startState;
        public override void InstallBindings()
        {
            InstallStates();

            Container
                .BindInterfacesAndSelfTo<T>()
                .AsSingle()
                .WithArguments(_startState);
        }
    }
}
