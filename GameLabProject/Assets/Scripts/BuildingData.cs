using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Data")]
public class BuildingData : ScriptableObject {


    [Range (0,5)]
    public int width;
    [Range (0,5)]
    public int length;
    public float buildingCost;

    //Factory Propperties F = FACTORY
    public float production;

    public float wasteProduction;

    public float recyclableWasteProduction;

    //Garbage Properties
    public float G_Cap;

    //Facility Poperties FA = FACILITY
    public float recycleFactor;


    [HideInInspector]
    public float placementFixX;
    [HideInInspector]
    public float placementFixY;
    [HideInInspector]
    public bool even;
}

