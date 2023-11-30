using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Entity.Skills
{
    public abstract class SkillSequenceInstaller<T> : SkillInstaller<T> where T : SkillSequence
    {
        public Settings SkillSequnceSettings;

        /// <summary>
        /// Install skills from list that sets in inspector to subContainer.
        /// </summary>
        /// <param name="subContainer"></param>
        protected void InstallSkills(DiContainer subContainer)
        {
            foreach (var skill in SkillSequnceSettings.Skills)
            {
                subContainer
                    .Bind<ISkill>()
                    .FromSubContainerResolve()
                    .ByMethod(skill.SilentInstall)
                    .AsCached();
            }
        }

        [Serializable]
        public class Settings
        {
            public List<SkillInstaller> Skills;
        }
    }
}
