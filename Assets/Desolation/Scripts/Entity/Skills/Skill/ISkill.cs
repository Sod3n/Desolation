using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Entity.Skills
{
    public interface ISkill
    {
        public bool Breakeable { get; }

        public State.Identificator CurrentState { get; }

        public void Use();

        public void Break();

        public bool IsDone { get; }
    }
}
