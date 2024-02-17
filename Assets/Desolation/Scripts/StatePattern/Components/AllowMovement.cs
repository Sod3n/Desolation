using AniMate;
using Desolation.StatePattern;
using HierarchicalStatePattern;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Desolation.StatePattern
{
    /// <summary>
    /// Component become done when on clip end. 
    /// </summary>
    public class AllowMovement : StateBehaviour
    {
        [Inject] private IsMovementAllowed _movementAllowed;

        public override void OnEnter()
        {
            _movementAllowed.Allowed = true;
        }
        public override void OnExit()
        {
            _movementAllowed.Allowed = false;
        }
    }
}
