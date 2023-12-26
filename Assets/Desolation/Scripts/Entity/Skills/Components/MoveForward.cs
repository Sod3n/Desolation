using log4net.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

namespace Entity.Skills
{
    public class MoveForward : IComponent.IFixedTickable
    {
        private Settings _settings;
        private CharacterController _characterController;


        public MoveForward(CharacterController characterController, Settings settings)
        {
            _characterController = characterController;
            _settings = settings;
        }

        public bool IsDone { get; set; } = true;

        public void FixedTick()
        {
            _characterController.Move(
                _characterController.transform.forward * _settings.UnitsPerSecond * Time.fixedDeltaTime);
        }

        [Serializable]
        public class Settings
        {
            public float UnitsPerSecond;
        }
    }
}
