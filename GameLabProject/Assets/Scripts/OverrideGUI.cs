﻿using System.Collections;
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
        data.house = GUILayout.Toggle(data.house, "House");

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
        else if(data.house == true) {
            DisplayHouseSettings();
        }
    }

    public void DisplayRecycleSettings() {
        data.recycleFactor = EditorGUILayout.FloatField("RecycleFactor", data.recycleFactor);
        data.recycleSpeed = EditorGUILayout.FloatField("RecycleSpeed", data.recycleSpeed);
        data.newRawMaterial = (GameObject)EditorGUILayout.ObjectField("NewMaterial", data.newRawMaterial, typeof(GameObject), false);
        data.recycleGarbage = (GameObject)EditorGUILayout.ObjectField("Waste", data.recycleGarbage, typeof(GameObject), false);
    }

    public void DisplayFactorySettings() {
        data.efficientcyPercentage = EditorGUILayout.FloatField("EfficientcyPercenage % ", data.efficientcyPercentage);
        data.production = EditorGUILayout.FloatField("Production",data.production);
        data.wasteProduction = EditorGUILayout.FloatField("WasetProduction",data.wasteProduction);
        data.recyclableWasteProduction = EditorGUILayout.FloatField("RecycableWasteProduction",data.recyclableWasteProduction);
        data.productionSpeed = EditorGUILayout.FloatField("ProductionSpeed", data.productionSpeed);
        data.moneyFactory = EditorGUILayout.FloatField("MoneyFacktor", data.moneyFactory);


        data.product = (GameObject)EditorGUILayout.ObjectField("Product", data.product, typeof(GameObject), false);
        data.recycleWaste = (GameObject)EditorGUILayout.ObjectField("RecycableWaste", data.recycleWaste, typeof(GameObject), false);
        data.nonRecycleWaste = (GameObject)EditorGUILayout.ObjectField("NonRecycable", data.nonRecycleWaste, typeof(GameObject), false);
    }

    public void DisplayMineSettings() {
        data.mineTime = EditorGUILayout.FloatField("Mine Time", data.mineTime);
        data.rawMaterial = (GameObject)EditorGUILayout.ObjectField("RawMaterial", data.rawMaterial, typeof(GameObject), false);
    }

    public void DisplayGarbageSettings() {
        data.G_Cap = EditorGUILayout.FloatField("Garbage Cappacity", data.G_Cap);
    }
    public void DisplayHouseSettings() {
        data.productWaste = (GameObject)EditorGUILayout.ObjectField("ProductWase", data.productWaste, typeof(GameObject), false);
        data.productRecycleWaste = (GameObject)EditorGUILayout.ObjectField("ProductRecycable", data.productRecycleWaste, typeof(GameObject), false);
        data.collectTime = EditorGUILayout.FloatField("collectTIme", data.collectTime);
    }


}
#endif