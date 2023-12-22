using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Player
{
    public class Movement : IInitializable
    {
        public Vector3 MovementDirection { get => _settings.MovementDirection; set => _settings.MovementDirection = value; }

        private Settings _settings;
        private CharacterController _characterController;

        public Movement(Settings settings, CharacterController characterController)
        {  
            _settings = settings;
            _characterController = characterController;
        }

        public void Initialize()
        {
            
        }

        public void Move()
        {
            _characterController.Move(MovementDirection * _settings.UnitsPerSeconds * Time.fixedDeltaTime);

            _characterController.transform.rotation = Quaternion.Slerp(_characterController.transform.rotation, Quaternion.LookRotation(MovementDirection), _settings.RotationSmooth);
        }

        [Serializable]
        public class Settings // Заменить на SO?
        {
            public float UnitsPerSeconds = 50f;
            public float RotationSmooth = 0.15f;
            public Vector3 MovementDirection;
        }
    }
}
