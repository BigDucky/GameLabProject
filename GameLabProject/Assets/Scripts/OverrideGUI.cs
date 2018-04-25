/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR 
using UnityEditor;
#endif 

#if UNITY_EDITOR
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
        data.factory = GUILayout.Toggle(data.factory, "Factory");
        data.housing = GUILayout.Toggle(data.housing, "Housing");
		data.garbage = GUILayout.Toggle(data.garbage, "Garbage");
		data.facility = GUILayout.Toggle (data.facility, "Facility");

        Display();
    }

    public void Display() {
        if(data.factory == true) {
            DisplayFactorySettings();
        }
        else if(data.housing == true) {
            DisplayHousingSettings();
        }
        else if(data.garbage == true) {
            DisplayGarbageSettings();
        }
        else if (data.facility == true) {
            DisplayFacilitySettings();
        }
    }


    public void DisplayFactorySettings() {
        data.production = EditorGUILayout.FloatField("Production",data.production);
        data.polution = EditorGUILayout.FloatField("Polution",data.polution);
        data.totalWaste = EditorGUILayout.FloatField("TotalWaste",data.totalWaste);
        data.recyclableWaste = EditorGUILayout.FloatField("RycyclableWaste", data.recyclableWaste);
    }

    public void DisplayHousingSettings() {
        data.houseCap = EditorGUILayout.FloatField("House Cappacity", data.houseCap);
    }

    public void DisplayGarbageSettings() {
        data.G_Cap = EditorGUILayout.FloatField("Garbage Cappacity", data.G_Cap);
        data.G_AOE = EditorGUILayout.FloatField("Area of effect", data.G_AOE);
    }

    public void DisplayFacilitySettings() {
        data.FA_Employees = EditorGUILayout.FloatField("Employees Needed", data.FA_Employees);
    }

}*/
//#endif