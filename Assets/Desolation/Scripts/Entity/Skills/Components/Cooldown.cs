using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Skills
{
    public class Cooldown : ISkillComponent.IUseable
    {
        private float _value;
        private LazyInject<ISkill> _owner;

        public Cooldown(float value, LazyInject<ISkill> owner)
        {
            _value = value;
            _owner = owner;
        }

        public bool IsDone => true;
        private UniTask _task;

        public void Use()
        {
            if (!_task.Status.IsCompleted())
            {
                _owner.Value.Break();
                return;
            }

            _task = UniTask.WaitForSeconds(_value);
        }
    }
}
