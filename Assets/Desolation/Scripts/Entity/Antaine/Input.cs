using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.Entity.Antaine
{
    public class Input : IInitializable, ITickable
    {
        public event Action BasicAttack = () => { };
        public event Action SkillOne = () => { };
        public event Action SkillTwo = () => { };
        public event Action SkillThree = () => { };
        public event Action SkillThreeReleased = () => { };

        public Vector3 WorldAimPoint;

        private Controlls _controlls;

        public Input(Controlls controlls)
        {
            _controlls = controlls;
        }

        public void Initialize()
        {
            _controlls.GameMap.BasicAttack.started += (_) => BasicAttack.Invoke();
            _controlls.GameMap.SkillOne.started += (_) => SkillOne.Invoke();
            _controlls.GameMap.SkillTwo.started += (_) => SkillTwo.Invoke();
            _controlls.GameMap.SkillThree.started += (_) => SkillThree.Invoke();
            _controlls.GameMap.SkillThree.canceled += (_) => SkillThreeReleased.Invoke();
        }

        public void Tick()
        {
            WorldAimPoint = _controlls.GameMap.AimPoint.ReadValue<Vector2>();
            WorldAimPoint = ScreenToWorldPointOnYSurface(WorldAimPoint);
        }


        private Vector3 ScreenToWorldPointOnYSurface(Vector2 vector2)
        {
            Vector3 direction = Camera.main.ScreenToWorldPoint(
                new Vector3(vector2.x, vector2.y, Camera.main.farClipPlane));

            direction *= 1 / direction.y;
            direction *= -Camera.main.transform.position.y;

            Debug.DrawRay(Camera.main.transform.position, direction);

            return Camera.main.transform.position + direction;
        }
    }
}
