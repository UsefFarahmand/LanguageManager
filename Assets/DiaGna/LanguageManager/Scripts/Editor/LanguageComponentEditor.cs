using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace DiaGna.Freamwork.Language.Editors
{
#if UNITY_EDITOR
    public abstract class LanguageComponentEditor : Editor
    {
        private SerializedProperty m_KeyProperty;

        private void OnEnable()
        {
            // Link the properties
            m_KeyProperty = serializedObject.FindProperty("Key");
        }

        public override void OnInspectorGUI()
        {
            // Load the real class values into the serialized copy
            serializedObject.Update();

            var dictionaries = LanguageManager.ReadLanguageAsset("WordDictionary");
            var list = new List<string>();
            foreach (var dictionary in dictionaries)
            {
                foreach (var word in dictionary.words)
                {
                    list.Add(word.id);
                }
            }

            int index = Mathf.Max(0, Array.IndexOf(list.ToArray(), m_KeyProperty.stringValue));
            index = EditorGUILayout.Popup("Key", index, list.ToArray());
            m_KeyProperty.stringValue = list[index];

            // Write back changed values and evtl mark as dirty and handle undo/redo
            serializedObject.ApplyModifiedProperties();
        }
    }
#endif
}