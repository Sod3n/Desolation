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
        private Dash _dash;
        private Input _input;
        private ISkillController _skillController;

        public BindSkills(BasicAttackSequence basicAttack, 
            Input input, ISkillController skillController, Dash dash)
        {
            _basicAttack = basicAttack;
            _input = input;
            _skillController = skillController;
            _dash = dash;
        }

        public void Initialize()
        {
            _input.BasicAttack += () => { _skillController.TryUseSkill(_basicAttack); };
            _input.SkillTwo += () => { _skillController.TryUseSkill(_dash); };
        }
    }
}
