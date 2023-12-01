using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Player
{
    public class Movement : ITickable
    {
        public Vector3 MovementDirection { get => _settings.MovementDirection; set => _settings.MovementDirection = value; }

        private Settings _settings;
        private CharacterController _characterController;

        public Movement(Settings settings, CharacterController characterController)
        {
            _settings = settings;
            _characterController = characterController;
        }

        public void Tick()
        {
            Move();
        }


        private void Move()
        {
            _characterController.Move(MovementDirection * _settings.MoveSpeed * Time.deltaTime);
        }

        [Serializable]
        public class Settings // Заменить на SO?
        {
            public float MoveSpeed = 50f;
            public Vector3 MovementDirection;
        }
    }
}
