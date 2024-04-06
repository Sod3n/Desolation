using UnityEngine;

namespace Desolation.Scripts.Entity.Model
{
    public class Key : MonoBehaviour
    {
        [SerializeField] private string _value;
        public string Value
        {
            get => _value;
        }
    }
}