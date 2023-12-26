using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Skills
{
    public class MakeDamage : IComponent.IFixedTickable, IInitializable
    {
        
        private Transform _transform;
        private DamageBox _damageZone;

        protected Settings _settings;

        private Collider[] _colliders = new Collider[10];

        public bool IsDone { get; set; } = true;

        public MakeDamage(Transform transform, Settings settings)
        {
            _transform = transform;
            _settings = settings;
        }

        public void Initialize()
        {
            _damageZone = new DamageBox(_settings.DamageZone);
        }

        public virtual void FixedTick()
        {
            DamageAllInDamageZone(_settings.DamageScale);
        }

        protected void DamageAllInDamageZone(float damageScale)
        {
            var center = _transform.position;
            center += _damageZone.Center.x * _transform.forward;
            center += _damageZone.Center.y * _transform.forward;
            center += _damageZone.Center.z * _transform.forward;

            Physics.OverlapBoxNonAlloc(center, _damageZone.Extents, _colliders, _transform.rotation);

            DrawBox(center, _transform.rotation, _damageZone.Extents * 2, Color.green);

            if (_colliders is null) return;

            foreach (var collider in _colliders)
            {
                if (collider is null) continue;

                if (collider.transform == _transform) continue;

                Debug.Log("Damage " + collider.name + " with damage scale: " + damageScale);
            }
        }
        public void DrawBox(Vector3 pos, Quaternion rot, Vector3 scale, Color c)
        {
            // create matrix
            Matrix4x4 m = new Matrix4x4();
            m.SetTRS(pos, rot, scale);

            var point1 = m.MultiplyPoint(new Vector3(-0.5f, -0.5f, 0.5f));
            var point2 = m.MultiplyPoint(new Vector3(0.5f, -0.5f, 0.5f));
            var point3 = m.MultiplyPoint(new Vector3(0.5f, -0.5f, -0.5f));
            var point4 = m.MultiplyPoint(new Vector3(-0.5f, -0.5f, -0.5f));

            var point5 = m.MultiplyPoint(new Vector3(-0.5f, 0.5f, 0.5f));
            var point6 = m.MultiplyPoint(new Vector3(0.5f, 0.5f, 0.5f));
            var point7 = m.MultiplyPoint(new Vector3(0.5f, 0.5f, -0.5f));
            var point8 = m.MultiplyPoint(new Vector3(-0.5f, 0.5f, -0.5f));

            Debug.DrawLine(point1, point2, c);
            Debug.DrawLine(point2, point3, c);
            Debug.DrawLine(point3, point4, c);
            Debug.DrawLine(point4, point1, c);

            Debug.DrawLine(point5, point6, c);
            Debug.DrawLine(point6, point7, c);
            Debug.DrawLine(point7, point8, c);
            Debug.DrawLine(point8, point5, c);

            Debug.DrawLine(point1, point5, c);
            Debug.DrawLine(point2, point6, c);
            Debug.DrawLine(point3, point7, c);
            Debug.DrawLine(point4, point8, c);
        }

        

        [Serializable]
        public class Settings
        {
            public float DamageScale;

            public BoxCollider DamageZone;
        }

        public class DamageBox
        {
            public Vector3 Center { get; set; }
            public Vector3 Size { get; set; }
            public Vector3 Extents { get => Size / 2; }

            public DamageBox(BoxCollider boxCollider)
            {
                Center = boxCollider.center;
                Size = boxCollider.size;
            }
        }
    }
}
