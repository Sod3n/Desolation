using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerInstaller : MonoInstaller
    {
        public Settings PlayerSettings;

        public Movement.Settings MovementSettings;

        public override void InstallBindings()
        {
            Container.BindInstances(MovementSettings);
            Container.BindInstances(PlayerSettings.CharacterController);

            Container.BindInterfacesAndSelfTo<Input>().AsSingle();
            Container.BindInterfacesAndSelfTo<Movement>().AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public CharacterController CharacterController;
        }
    }
}
