using Cysharp.Threading.Tasks;
using Entity.Skills;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Zenject;

namespace Entity.Antaine
{
    //[CreateAssetMenu(fileName = "BasicAttackSequence", menuName = "Installers/UntitledInstaller")]
    public class BasicAttackSequenceInstaller : SkillSequenceInstaller<BasicAttackSequence>
    {
        public Settings BasicAttackSequenceSettings;

        public override void SilentInstall(DiContainer subContainer)
        {
            InstallSkills(subContainer);

            subContainer
                .Bind<IResetTaskFactory>()
                .To<WaitSecondsReset>()
                .AsSingle()
                .WithArguments(BasicAttackSequenceSettings.WaitSecondsResetSettings);

            subContainer
                .Bind<BasicAttackSequence>()
                .AsSingle();
        }

        [Serializable]
        public new class Settings
        {
            public WaitSecondsReset.Settings WaitSecondsResetSettings;
        }
    }
}
