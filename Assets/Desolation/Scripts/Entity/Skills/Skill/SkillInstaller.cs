using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Skills
{
    public abstract class SkillInstaller : ScriptableObjectInstaller
    {
        /// <summary>
        /// Must add skill of type T to subContainer. 
        /// Also this is place where all skill components will be binded to skill.
        /// </summary>
        /// <param name="subContainer"></param>
        public abstract void SilentInstall(DiContainer subContainer);
    }

    /// <summary>
    /// Bind skill of type T to Container from silent install sub container.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SkillInstaller<T> : SkillInstaller where T : ISkill
    {
        public override void InstallBindings()
        {
            Container
                .Bind(typeof(T), typeof(Zenject.IInitializable))
                .To<T>()
                .FromSubContainerResolve()
                .ByMethod(SilentInstall)
                .AsSingle();
        }

        public override void SilentInstall(DiContainer subContainer)
        {
            subContainer
                .BindInterfacesAndSelfTo<T>()
                .AsSingle()
                .WhenNotInjectedInto<T>();
            
        }

        private int _stateCount;

        protected void SetStatesCount(DiContainer subContainer, int count = 3)
        {
            _stateCount = count;

            subContainer
                .Bind<ISkill.StateIterator>()
                .AsSingle()
                .WithArguments(count)
                .IfNotBound();
        }

        protected ISkill.State State(uint i)
        {
            if (i >= _stateCount)
                throw new Exception(
                    "Trying to get state that greater than state count. " +
                    "Expand state count or take smaller state.");

            return ISkill.ToState(i);
        }
    }
}
