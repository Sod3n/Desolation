using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Skills
{
    public abstract class SkillInstaller: ScriptableObjectInstaller
    {
        /// <summary>
        /// Must add skill of type T to subContainer. 
        /// Also this is place where all skill components will be binded to skill.
        /// </summary>
        /// <param name="subContainer"></param>
        public abstract void SilentInstall(DiContainer subContainer);
    }

    /// <summary>
    /// Bind skill of type T to Container from silent istall sub container.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class SkillInstaller<T> : SkillInstaller where T : ISkill
    {
        public override void InstallBindings()
        {
            Container
                .Bind<T>()
                .FromSubContainerResolve()
                .ByMethod(SilentInstall)
                .AsSingle();
        }
    }
}
