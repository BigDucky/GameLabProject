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
        data.factory = GUILayout.Toggle(data.factory, "Factory");
        data.housing = GUILayout.Toggle(data.housing, "Housing");
        data.recycleFacility = GUILayout.Toggle(data.recycleFacility, "Recycle Factory");
        Display();
    }

    public void Display() {
        if(data.factory == true) {
            DisplayFactorySettings();
        }
        else if(data.housing == true) {

        }
        else if(data.recycleFacility == true) {
            DisplayRecycleFacilitySettings();
        }
    }

    public void DisplayFactorySettings() {
        data.aoeSize = EditorGUILayout.FloatField("AOESize",data.aoeSize);
        data.production = EditorGUILayout.FloatField("Production",data.production);
        data.polution = EditorGUILayout.FloatField("Polution",data.polution);
        data.waste = EditorGUILayout.FloatField("Waste",data.waste);
        data.rawMaterialsNeeded = EditorGUILayout.FloatField("Material Needed",data.rawMaterialsNeeded);
    }

    public void DisplayHousingSettings() {

    }

    public void DisplayRecycleFacilitySettings() {
        data.maxCapacity = EditorGUILayout.FloatField("Max Capacity", data.maxCapacity);
        data.rf_happinessIncrease = EditorGUILayout.FloatField("Max Happiness Increase", data.rf_happinessIncrease);
    }
}
