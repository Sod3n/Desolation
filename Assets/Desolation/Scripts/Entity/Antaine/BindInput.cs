using Entity.Skills;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Antaine
{
    public class BindInput : IInitializable, ITickable
    {
        private ISkill _basicAttack;
        private ISkill _wingsOfNight;
        private ISkill _demonicSweep;
        private ISkill _worldsApart;
        private Input _input;
        private ISkillController _skillController;
        private WorldsApart.ChargeEvents _worldsApartChargeEvents;
        

        private LookIn.Direction _lookDirection;
        private Transform _transform;

        public BindInput(
            BasicAttackSequence basicAttackSequence, Input input,
            ISkillController skillController, WingsOfNight dash,
            DemonicSweep demonicSweep, WorldsApart.ChargeEvents worldsApartChargeEvents,
            WorldsApart worldsApart,
            Transform transform, LookIn.Direction lookDirection)
        {
            _basicAttack = basicAttackSequence;
            _input = input;
            _skillController = skillController;
            _wingsOfNight = dash;
            _demonicSweep = demonicSweep;
            _worldsApartChargeEvents = worldsApartChargeEvents;
            _worldsApart = worldsApart;
            _transform = transform;
            _lookDirection = lookDirection;
        }

        public void Initialize()
        {
            _input.BasicAttack += () => { _skillController.TryUseSkill(_basicAttack); };
            _input.SkillOne += () => { _skillController.TryUseSkill(_demonicSweep); };
            _input.SkillTwo += () => { _skillController.TryUseSkill(_wingsOfNight); };
            _input.SkillThree += () => { _skillController.TryUseSkill(_worldsApart); };
            _input.SkillThreeReleased += () => { _worldsApartChargeEvents.EndCharge.Invoke(); };
        }

        public void Tick()
        {
            _lookDirection.Value = (_input.WorldAimPoint - _transform.position);
            _lookDirection.Value.y = 0;
            _lookDirection.Value = _lookDirection.Value.normalized;
        }
    }
}
