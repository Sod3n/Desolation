using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using UnityEngine;
using Zenject;
using ZenjectExtender;

namespace Entity.Skills
{
    public abstract class SkillSequenceInstaller<T> : SkillInstaller<T> where T : SkillSequence
    {
        public Settings SkillSequnceSettings;

        public override void InstallBindings()
        {
            foreach (var skill in SkillSequnceSettings.Skills)
            {
                Container
                    .Bind<ISkill>()
                    .FromSubContainerResolve()
                    .ByNewGameObjectScriptableInstaller(skill)
                    .AsCached();
            }

            Container
                .Bind<ISkillController>()
                .To<SkillController>()
                .AsSingle();

            InstallStates();

            Container
                .Bind<T>()
                .AsCached()
                .WithArguments(_breakeable)
                .WhenNotInjectedInto<T>();
        }

        [Serializable]
        public class Settings
        {
            public List<SkillInstaller> Skills;
        }
    }

    public static class SkillSequenceInstallerExtensions
    {
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
