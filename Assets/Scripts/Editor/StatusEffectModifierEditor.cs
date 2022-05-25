using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(StringSelection))]
public class StringSelectionDrawer : PropertyDrawer
{
    private int selectedIndex;

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        StringSelection selection = attribute as StringSelection;

        Debug.Log(selection.stringsList);
        selectedIndex = EditorGUI.Popup(position, selectedIndex, new string[] { "a ", "eee"});

        //property.stringValue = selection.stringsList[selectedIndex];
    }
}

