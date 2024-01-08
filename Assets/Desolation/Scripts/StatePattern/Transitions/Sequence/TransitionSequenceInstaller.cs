using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using Zenject;
using ZenjectExtender;

namespace Desolation.StatePattern
{
    public abstract class TransitionSequenceInstaller<T> : TransitionInstaller<T> where T : TransitionSequence
    {
        public Settings SkillSequnceSettings;

        public override void InstallBindings()
        {
            foreach (var skill in SkillSequnceSettings.Skills)
            {
                Container
                    .Bind<ITransition>()
                    .FromSubContainerResolve()
                    .ByNewGameObjectScriptableInstaller(skill)
                    .AsCached()
                    .WhenInjectedInto<T>();
            }

            ConfigureTransitionSequence();
            
            Container
                .Bind(typeof(T), typeof(IInitializable))
                .To<T>()
                .AsCached();
            
        }

        protected override void InstallStates() { }

        protected abstract void ConfigureTransitionSequence();

        [Serializable]
        public class Settings
        {
            public List<TransitionInstaller> Skills;
        }
    }
}
