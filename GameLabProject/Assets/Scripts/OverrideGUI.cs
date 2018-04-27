using System.Collections;
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
        data.recycle = GUILayout.Toggle(data.recycle, "'Recycle");
		data.garbage = GUILayout.Toggle(data.garbage, "Garbage");
		data.mine = GUILayout.Toggle (data.mine, "Mine");

        Display();
    }

    public void Display() {
        if(data.factory == true) {
            DisplayFactorySettings();
        }
        else if(data.recycle == true) {
            DisplayRecycleSettings();
        }
        else if(data.garbage == true) {
            DisplayGarbageSettings();
        }
        else if (data.mine == true) {
            DisplayMineSettings();
        }
    }

    public void DisplayRecycleSettings() {
        data.recycleFactor = EditorGUILayout.FloatField("RecycleFactor", data.recycleFactor);
    }

    public void DisplayFactorySettings() {
        data.production = EditorGUILayout.FloatField("Production",data.production);
        data.wasteProduction = EditorGUILayout.FloatField("WasetProduction",data.wasteProduction);
        data.recyclableWasteProduction = EditorGUILayout.FloatField("RecycableWasteProduction",data.recyclableWasteProduction);
    }

    public void DisplayMineSettings() {
        data.mineTime = EditorGUILayout.FloatField("Mine Time", data.mineTime);
    }

    public void DisplayGarbageSettings() {
        data.G_Cap = EditorGUILayout.FloatField("Garbage Cappacity", data.G_Cap);
    }


}
#endif