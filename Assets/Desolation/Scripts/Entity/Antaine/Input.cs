using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Antaine
{
    public class Input : IInitializable
    {
        public event Action BasicAttack;
        public event Action SkillOne;
        public event Action SkillTwo;
        public event Action SkillThree;

        private Controlls _controlls;

        public Input(Controlls controlls)
        {
            _controlls = controlls;
        }

        public void Initialize()
        {
            _controlls.GameMap.BasicAttack.performed += (_) => { BasicAttack.Invoke(); };
            _controlls.GameMap.SkillOne.performed += (_) => { SkillOne.Invoke(); };
            _controlls.GameMap.SkillTwo.performed += (_) => { SkillTwo.Invoke(); };
            _controlls.GameMap.SkillThree.performed += (_) => { SkillThree.Invoke(); };
        }
    }
}
