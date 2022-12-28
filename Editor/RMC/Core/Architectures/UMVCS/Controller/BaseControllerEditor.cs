using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using RMC.Core.Architectures.Umvcs.Controller;
using RMC.Core.Architectures.Umvcs.Model;
using RMC.Core.Architectures.Umvcs.Service;
using RMC.Core.Architectures.Umvcs.View;
using UnityEditor;


namespace RMC.Core.Architectures.Umvcs.Controller
{
	/// <summary>
	/// TODO: Add comment
	/// </summary>
	[CustomEditor (typeof (BaseController), true)]
	public class BaseControllerEditor : UnityEditor.Editor
	{
		public override void OnInspectorGUI()
		{
			serializedObject.Update();

			SerializedProperty serializedProperty = serializedObject.GetIterator();
			if (serializedProperty.NextVisible(true))
			{
				do
				{
					bool nullFound = false;
					if (serializedProperty.propertyType == SerializedPropertyType.ObjectReference)
					{
						List<Type> types =	new List<Type>() {
							typeof(NullModel),
							typeof(NullView),
							typeof(NullController),
							typeof(NullService) };

						foreach (Type type in types)
						{
							if (serializedProperty.type.Contains(type.Name))
							{
								nullFound = true;
								break;
							}
						}
					}
					
					if (!nullFound)
					{
						EditorGUILayout.PropertyField(serializedObject.FindProperty(serializedProperty.name), true);
					}
					
				}
				while (serializedProperty.NextVisible(false));
			}

			serializedObject.ApplyModifiedProperties();
		}
		public static string GetPropertyType(SerializedProperty property)
		{
			var type = property.type;
			var match = Regex.Match(type, @"PPtr<\$(.*?)>");
			if (match.Success)
				type = match.Groups[1].Value;
			return type;
		}

		public static Type GetPropertyObjectType(SerializedProperty property)
		{
			return typeof(UnityEngine.Object).Assembly.GetType("UnityEngine." + GetPropertyType(property));
		}
	}

}
