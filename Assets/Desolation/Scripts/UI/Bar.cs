using System;
using UnityEngine;
using UnityEngine.UI;

namespace Desolation.Scripts.UI
{
    public class Bar : MonoBehaviour
    { 
        private SlicedFilledImage _image;
        private float _maxValue;
        private float _currentValue;

        public float MaxValue
        {
            get => _maxValue;
            set
            {
                _maxValue = value;
                SetImageFill(_currentValue / _maxValue);
            }
        }

        public float CurrentValue
        {
            get => _currentValue;
            set
            {
                _currentValue = value;
                SetImageFill(_currentValue / _maxValue);
            }
        }

        private void SetImageFill(float fill)
        {
            _image.fillAmount = fill;
        }

        private void Awake()
        {
            _image = GetComponent<SlicedFilledImage>();
        }
    }
}