using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.Entity.Antaine
{
    public class Input : MonoBehaviour
    {
        [Inject] private Controlls _controlls;

        public event Action BasicAttack = () => { };
        public event Action SkillOne = () => { };
        public event Action SkillTwo = () => { };
        public event Action SkillThree = () => { };
        public event Action SkillThreeReleased = () => { };
        public event Action Moving = () => { };
        public event Action NotMoving = () => { };
        private void Start()
        {
            _controlls.GameMap.BasicAttack.performed += (_) => BasicAttack.Invoke();
            _controlls.GameMap.SkillOne.performed += (_) => SkillOne.Invoke();
            _controlls.GameMap.SkillTwo.performed += (_) => SkillTwo.Invoke();
            _controlls.GameMap.SkillThree.performed += (_) => SkillThree.Invoke();
            _controlls.GameMap.SkillThree.performed += (_) => SkillThreeReleased.Invoke();
            
        }

        private void Update()
        {
            if (_controlls.GameMap.MoveVector.IsInProgress())
                Moving.Invoke();
            else
                NotMoving.Invoke();
        }
    }
}
