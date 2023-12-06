using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entity.Skills
{
    public class Charge : ISkillComponent, Zenject.IInitializable
    {
        public bool IsDone { get; private set; }

        private Events _events;

        public Charge(Events events)
        {
            _events = events;
        }

        public void Initialize()
        {
            _events.EndCharge += () => { Debug.Log("End"); }; 
        }

        public class Events
        {
            public Action EndCharge;
        }
    }
}
