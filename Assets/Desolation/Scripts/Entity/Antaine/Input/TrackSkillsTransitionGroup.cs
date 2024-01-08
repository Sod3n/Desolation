using Desolation.Entity.Skills;
using Desolation.StatePattern;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Zenject;

namespace Desolation.Entity.Antaine
{
    public class TrackSkillsTransitionGroup : TransitionGroup, IInitializable
    {
        [Inject] private BasicAttackSequence _basicAttackSequence;
        [Inject] private WingsOfNight _wingsOfNight;
        [Inject] private DemonicSweep _demonicSweep;
        [Inject] private WorldsApart _worldsApart;

        [Inject] private Input _input;

        public void Initialize()
        {
            _input.BasicAttack += _basicAttackSequence.Invoke;
            _input.SkillOne += _demonicSweep.Invoke;
            _input.SkillTwo += _wingsOfNight.Invoke;
            _input.SkillThree += _worldsApart.Invoke;
        }
    }
}
