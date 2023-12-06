using Entity.Skills;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Antaine
{
    public class BindSkills : IInitializable
    {
        private BasicAttackSequence _basicAttack;
        private WingsOfNight _wingsOfNight;
        private DemonicSweep _demonicSweep;
        private Input _input;
        private ISkillController _skillController;
        private WorldsApart.ChargeEvents _worldsApartChargeEvents;

        public BindSkills(
            BasicAttackSequence basicAttack, Input input,
            ISkillController skillController, WingsOfNight dash,
            DemonicSweep demonicSweep, WorldsApart.ChargeEvents worldsApartChargeEvents)
        {
            _basicAttack = basicAttack;
            _input = input;
            _skillController = skillController;
            _wingsOfNight = dash;
            _demonicSweep = demonicSweep;
            _worldsApartChargeEvents = worldsApartChargeEvents;
        }

        public void Initialize()
        {
            _input.BasicAttack += () => { _skillController.TryUseSkill(_basicAttack); };
            _input.SkillOne += () => { _skillController.TryUseSkill(_demonicSweep); };
            _input.SkillTwo += () => { _skillController.TryUseSkill(_wingsOfNight); };
            _input.SkillThree += () => { _worldsApartChargeEvents.EndCharge(); };

        }
    }
}
