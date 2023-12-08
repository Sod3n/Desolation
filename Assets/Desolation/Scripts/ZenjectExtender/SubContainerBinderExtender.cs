using ModestTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using Zenject;
using Zenject.Internal;

namespace ZenjectExtender
{
    public static class SubContainerBinderExtender
    {
        public static NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder ByNewGameObjectScriptableInstaller
            (this SubContainerBinder subContainerBinder, ScriptableObjectInstaller installer)
        {
            var _subIdentifier = subContainerBinder.GetFieldValue<object>("_subIdentifier");
            var _resolveAll = subContainerBinder.GetFieldValue<bool>("_resolveAll");
            var _bindInfo = subContainerBinder.GetFieldValue<BindInfo>("_bindInfo");

            var installerType = installer.GetType();

            Assert.That(installerType.DerivesFrom<ScriptableObjectInstallerBase>(),
                "Invalid installer type given during bind command.  " +
                "Expected type '{0}' to derive from 'ScriptableObjectInstaller<>'", installerType);

            var gameObjectInfo = new GameObjectCreationParameters();


            var sub = new SubContainerPrefabBindingFinalizer(
                _bindInfo, _subIdentifier, _resolveAll,
                (container) => new SubContainerCreatorByNewGameObjectScriptableInstaller(
                    container, gameObjectInfo, installerType, installer));
            subContainerBinder.SetFieldValue<IBindingFinalizer>("SubFinalizer", sub);
            

            return new NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder(_bindInfo, gameObjectInfo);
        }

        public static T GetFieldValue<T>(this object obj, string name)
        {
            var field = obj
                .GetType()
                .GetField(name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            return (T)field?.GetValue(obj);
        }

        public static void SetFieldValue<T>(this object obj, string name, T value)
        {
            obj.GetType()
                .GetProperty(name, BindingFlags.NonPublic | BindingFlags.Instance)
                .SetMethod
                .Invoke(obj, new object[] { value });
        }
    }

    [NoReflectionBaking]
    public class SubContainerCreatorByNewGameObjectScriptableInstaller : SubContainerCreatorByNewGameObjectDynamicContext
    {
        readonly ScriptableObjectInstaller _installer;

        public SubContainerCreatorByNewGameObjectScriptableInstaller(
            DiContainer container,
            GameObjectCreationParameters gameObjectBindInfo,
            Type installerType, ScriptableObjectInstaller installer)
            : base(container, gameObjectBindInfo)
        {
            _installer = installer;

            Assert.That(installerType.DerivesFrom<ScriptableObjectInstallerBase>(),
                "Invalid installer type given during bind command.  Expected type '{0}' to derive from 'Installer<>'", installerType);
        }

        protected override void AddInstallers(List<TypeValuePair> args, GameObjectContext context)
        {

            context.ScriptableObjectInstallers = new List<ScriptableObjectInstaller>()
            {
                _installer
            };

        }
    }

}
