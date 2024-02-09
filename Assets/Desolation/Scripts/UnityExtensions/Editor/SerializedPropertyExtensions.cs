using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace UnityExtensions
{
    public static class SerializedPropertyExtensions
    {
        /*public static T GetSerializedValue<T>(this SerializedProperty property)
        {
            object @object = property.serializedObject.targetObject;
            string[] propertyNames = property.propertyPath.Split('.');

            // Clear the property path from "Array" and "data[i]".
            if (propertyNames.Length >= 3 && propertyNames[propertyNames.Length - 2] == "Array")
                propertyNames = propertyNames.Take(propertyNames.Length - 2).ToArray();

            // Get the last object of the property path.
            foreach (string path in propertyNames)
            {
                @object = @object.GetType()
                    .GetField(path, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .GetValue(@object);
            }

            if (@object.GetType().GetInterfaces().Contains(typeof(IList<T>)))
            {
                int propertyIndex = int.Parse(property.propertyPath[property.propertyPath.Length - 2].ToString());

                return ((IList<T>)@object)[propertyIndex];
            }
            else return (T)@object;
        }*/

        public static T GetPropertyValue<T>(this SerializedProperty property, string properyName)
        {
            object @object = property.boxedValue;
            
            if(@object == null) return default(T);

            return  (T)@object.GetType()
                    .GetField(properyName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .GetValue(@object);
        }

        public static void SetPropertyValu(this SerializedProperty property, string properyName, object value)
        {
            object @object = property.boxedValue;

            @object.GetType()
                    .GetField(properyName, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .SetValue(@object, value);
        }
    }
}
