using System;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerInstaller : MonoInstaller
    {
        public Settings PlayerSettings;

        public Movement.Settings MovementSettings;
        public PlayerHealth.Settings HealthSettings;

        public override void InstallBindings()
        {
            Container.BindInstances(MovementSettings);
            Container.BindInstances(HealthSettings);
            Container.BindInstances(PlayerSettings.CharacterController);

            Container.BindInterfacesAndSelfTo<Input>().AsSingle();
            Container.BindInterfacesAndSelfTo<Movement>().AsSingle();
            Container.BindInterfacesAndSelfTo<PlayerHealth>().AsSingle();

            Container.BindInterfacesTo<PlayerMovement>().AsSingle();
        }

        [Serializable]
        public class Settings
        {
            public CharacterController CharacterController;
        }
    }
}
