using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Player
{
    public class PlayerHealth : Health, IRegenerable
    {
        [Header("Health Regeneration")]
        public float HealthRegenerationRate;
        public int HealthRegenerationAmount;

        public PlayerHealth(Settings settings) : base(settings)
        {
            HealthSettings = settings;
        }

        public async UniTaskVoid HealthRegeneration()
        {
        }

    }
}
