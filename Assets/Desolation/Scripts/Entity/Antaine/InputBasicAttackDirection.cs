using System;
using HierarchicalStatePattern;
using UnityEngine;
using Zenject;
using Input = Desolation.Entity.Antaine.Input;

namespace Desolation.StatePattern
{
    public class InputBasicAttackDirection : Direction
    {
        [Inject] private Controlls _controlls;
        [Inject] private Transform _transform;
        [Inject] private Input _input;

        private Vector3 _worldAimPoint;
        private Vector3 _clickDirection;
        private Vector3 _centerPoint;

        private void Start()
        {
            _input.BasicAttack += FindClickPosition;
        }

        private void FindClickPosition()
        {
            _worldAimPoint = _controlls.GameMap.AimPoint.ReadValue<Vector2>();

            _worldAimPoint.z = _worldAimPoint.y;
            _worldAimPoint.y = 0;
            
            _centerPoint.x = Screen.width/2;
            _centerPoint.z = Screen.height/2;
            
            _clickDirection = (_worldAimPoint - _centerPoint);
            
            _value = _clickDirection.normalized;
        }
    }
}