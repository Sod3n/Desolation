using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Desolation.StatePattern
{
    [CustomEditor(typeof(PlayAnimation))]
    [CanEditMultipleObjects]
    public class PlayAnimationEditor : Editor
    {
        SerializedProperty _clip;
        SerializedProperty _useDefaultDuration;
        SerializedProperty _clipDuration;

        void OnEnable()
        {
            _clip = serializedObject.FindProperty("_clip");
            _useDefaultDuration = serializedObject.FindProperty("_useDefaultDuration");
            _clipDuration = serializedObject.FindProperty("_clipDuration");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            EditorGUILayout.PropertyField(_clip);
            EditorGUILayout.PropertyField(_useDefaultDuration);

            bool useDefaultDuration = _useDefaultDuration.boolValue;
            var clip = (AnimationClip)_clip.boxedValue;


            if (!useDefaultDuration)
            {
                EditorGUILayout.PropertyField(_clipDuration);
                EditorGUI.BeginDisabledGroup(true);
                EditorGUILayout.PrefixLabel("Default clip duration");
                EditorGUILayout.FloatField(clip.length);
                EditorGUI.EndDisabledGroup();
            }
            else
            {
                _clipDuration.floatValue = clip.length;
            }
            
            serializedObject.ApplyModifiedProperties();
        }
    }
}
