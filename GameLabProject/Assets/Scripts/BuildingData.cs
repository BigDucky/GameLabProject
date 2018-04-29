﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Data")]
public class BuildingData : ScriptableObject {


    [HideInInspector]
    public bool factory;
    [HideInInspector]
    public bool garbage;
    [HideInInspector]
    public bool recycle;
    [HideInInspector]
    public bool mine;

    [Range (0,5)]
    public int width;
    [Range (0,5)]
    public int length;

    public float buildingCost;


    //Factory Propperties F = FACTORY
    [HideInInspector]
    public GameObject product;
    [HideInInspector]
    public GameObject nonRecycleWaste;
    [HideInInspector]
    public GameObject recycleWaste;

    [HideInInspector]
    public float production;
    [HideInInspector]
    public float wasteProduction;
    [HideInInspector]
    public float recyclableWasteProduction;
    [HideInInspector]
    public float productionSpeed;

    //Garbage Properties
    [HideInInspector]
    public float G_Cap;

    //Facility Poperties
    [HideInInspector]
    public float recycleFactor;
    [HideInInspector]
    public float recycleSpeed;
    [HideInInspector]
    public GameObject newRawMaterial;

    //Mine Properties
    [HideInInspector]
    public GameObject rawMaterial;

    [HideInInspector]
    public float mineTime;




    [HideInInspector]
    public float placementFixX;
    [HideInInspector]
    public float placementFixY;
    [HideInInspector]
    public bool even;
}

