using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Data")]
public class BuildingData : ScriptableObject {

    [HideInInspector]
    public bool factory;
    [HideInInspector]
    public bool recycleFacility;
    [HideInInspector]
    public bool housing;

    [Range (0,5)]
    public int width;
    [Range (0,5)]
    public int length;

    //Factory Propperties
    [HideInInspector]
    public float aoeSize;
    [HideInInspector]
    public float buildingCost;
    [HideInInspector]
    public float production;
    [HideInInspector]
    public float polution;
    [HideInInspector]
    public float waste;
    [HideInInspector]
    public float rawMaterialsNeeded;

    [HideInInspector]
    public float placementFixX;
    [HideInInspector]
    public float placementFixY;
    [HideInInspector]
    public bool even;
}

