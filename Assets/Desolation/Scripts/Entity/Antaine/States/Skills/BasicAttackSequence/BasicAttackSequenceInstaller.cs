using Cysharp.Threading.Tasks;
using Desolation.Entity.Skills;
using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using Zenject;

namespace Desolation.Entity.Antaine
{
    //[CreateAssetMenu(fileName = "BasicAttackSequence", menuName = "Installers/UntitledInstaller")]
    public class BasicAttackSequenceInstaller : TransitionSequenceInstaller<BasicAttackSequence>
    {
        public Settings BasicAttackSequenceSettings;

        protected override void ConfigureTransitionSequence()
        {
            Container.BindWaitSecondsReset(BasicAttackSequenceSettings.WaitSecondsResetSettings);
        }

        [Serializable]
        public new class Settings
        {
            public WaitSecondsReset.Settings WaitSecondsResetSettings;
        }
    }
}
