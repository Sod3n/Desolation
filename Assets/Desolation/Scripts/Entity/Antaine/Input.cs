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
        public event Action SkillTwo;

        private Controlls _controlls;

        public Input(Controlls controlls)
        {
            _controlls = controlls;
        }

        public void Initialize()
        {
            _controlls.GameMap.BasicAttack.performed += (_) => { BasicAttack.Invoke(); };
            _controlls.GameMap.SkillTwo.performed += (_) => { SkillTwo.Invoke(); };
        }
    }
}
