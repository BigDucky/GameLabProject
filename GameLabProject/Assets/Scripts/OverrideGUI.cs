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
    public static List<string> FactorieVariables;
    public static List<string> RecycleVariables;

    // static bool showInEditor = false;

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
        data.tech = GUILayout.Toggle(data.tech, "Tech");
        repeat();
        Display();
    }

     void repeat() {
        Debug.Log("11111");
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
        else if(data.tech == true) {
            DisplayTechSettings();
        }
    }

    public void DisplayRecycleSettings() {

        data.recycleFactor = EditorGUILayout.FloatField("RecycleFactor", data.recycleFactor);
        data.newRawMaterial = (GameObject)EditorGUILayout.ObjectField("NewMaterial", data.newRawMaterial, typeof(GameObject), false);
        data.recycleGarbage = (GameObject)EditorGUILayout.ObjectField("Waste", data.recycleGarbage, typeof(GameObject), false);


    }

    public void DisplayFactorySettings() {


        data.efficientcyPercentage = EditorGUILayout.FloatField("EfficientcyPercenage % ", data.efficientcyPercentage);
        data.production = EditorGUILayout.FloatField("Production",data.production);
        data.wasteProduction = EditorGUILayout.FloatField("WasetProduction",data.wasteProduction);
        data.recyclableWasteProduction = EditorGUILayout.FloatField("RecycableWasteProduction",data.recyclableWasteProduction);
        data.moneyFactory = EditorGUILayout.FloatField("MoneyFacktor", data.moneyFactory);


        data.product = (GameObject)EditorGUILayout.ObjectField("Product", data.product, typeof(GameObject), false);
        data.recycleWaste = (GameObject)EditorGUILayout.ObjectField("RecycableWaste", data.recycleWaste, typeof(GameObject), false);
        data.nonRecycleWaste = (GameObject)EditorGUILayout.ObjectField("NonRecycable", data.nonRecycleWaste, typeof(GameObject), false);
    }

    public void DisplayMineSettings() {
        data.rawMaterial = (GameObject)EditorGUILayout.ObjectField("RawMaterial", data.rawMaterial, typeof(GameObject), false);
    }

    public void DisplayGarbageSettings() {
        data.G_Cap = EditorGUILayout.FloatField("Garbage Cappacity", data.G_Cap);
    }
    public void DisplayHouseSettings() {

        data.productWaste = (GameObject)EditorGUILayout.ObjectField("ProductWase", data.productWaste, typeof(GameObject), false);
        data.productRecycleWaste = (GameObject)EditorGUILayout.ObjectField("ProductRecycable", data.productRecycleWaste, typeof(GameObject), false);
        data.money = (GameObject)EditorGUILayout.ObjectField("'Product", data.money, typeof(GameObject), false);
    }

    public void DisplayTechSettings() {
        data.techPercentage = EditorGUILayout.FloatField("TechPercentage", data.techPercentage);
    }


}
#endif