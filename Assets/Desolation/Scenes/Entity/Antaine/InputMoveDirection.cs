using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Desolation.StatePattern;
using Zenject;

namespace Desolation.Entity.Antaine
{
    public class InputMoveDirection : Direction
    {
        [Inject] private Controlls _controlls;

        private void Update()
        {
            _value = _controlls.GameMap.MoveVector.ReadValue<Vector2>().normalized;
            _value.z = _value.y;
            _value.y = 0;
        }
    }
}
