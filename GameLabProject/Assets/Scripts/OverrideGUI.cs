using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(BuildingData))]
public class OverrideGUI : Editor {

    BuildingData data;

    static bool showInEditor = false;

    public void OnEnable() {
        data = (BuildingData)target;
        
    }

    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        serializedObject.Update();
        //EditorGUILayout.PropertyField();
        Display();
        data.factory = GUILayout.Toggle(data.factory, "Factory");
        data.housing = GUILayout.Toggle(data.housing, "Housing");
        data.recycleFacility = GUILayout.Toggle(data.recycleFacility, "Recycle Factory");

    }

    public void Display() {
        if(data.factory == true) {
            
        }
        else if(data.housing == true) {

        }
        else if(data.recycleFacility == true) {

        }
    }
}
