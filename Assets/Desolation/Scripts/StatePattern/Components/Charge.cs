using Desolation.StatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    public class Charge : StateBehaviour
    {
        [SerializeField] private float _powerIncreasePerSecond;

        public float Power { get; set; }

        public override void OnEnter()
        {
            Power = 0;
        }

        private void FixedUpdate()
        {
            Power += _powerIncreasePerSecond * Time.deltaTime;
        }
    }
}
