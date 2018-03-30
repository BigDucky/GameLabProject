using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Data")]
public class BuildingData : ScriptableObject {

    [HideInInspector]
    public bool factory;
    [HideInInspector]
    public bool garbage;
    [HideInInspector]
    public bool housing;
    [HideInInspector]
    public bool facility;

    [Range (0,5)]
    public int width;
    [Range (0,5)]
    public int length;
    public float buildingCost;

    //Factory Propperties
    [HideInInspector]
    public float F_Employess;
    [HideInInspector]
    public float F_AOE;
    [HideInInspector]
    public float production;
    [HideInInspector]
    public float polution;
    [HideInInspector]
    public float totalWaste;
    [HideInInspector]
    public float recyclableWaste;

    //Housing Properties
    [HideInInspector]
    public float houseCap;

    //Garbage Properties
    [HideInInspector]
    public float G_Cap;
    [HideInInspector]
    public float G_AOE;
    
    //Facility Poperties
    [HideInInspector]
    public float FA_Employees;

    [HideInInspector]
    public float placementFixX;
    [HideInInspector]
    public float placementFixY;
    [HideInInspector]
    public bool even;
}

