using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Desolation.StatePattern
{
    public class Direction : MonoBehaviour
    {
        [SerializeField] protected Vector3 _value;

        public Vector3 Value => _value;
    }
}
