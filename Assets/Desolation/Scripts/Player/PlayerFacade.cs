using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerFacade : MonoBehaviour
    {
        private CharacterController _characterController;

        [Inject]
        public void Inject(CharacterController characterController)
        {
            _characterController = characterController;
        }
    }
}
