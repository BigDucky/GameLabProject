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
    [HideInInspector]
    public bool house;
    [HideInInspector]
    public bool tech;


    public int level;

    [Range (0,5)]
    public int width;
    [Range (0,5)]
    public int length;


    public float buildingCost;
    public float collectTime;


    //Factory Propperties F = FACTORY
    [HideInInspector]
    public GameObject product;
    [HideInInspector]
    public GameObject nonRecycleWaste;
    [HideInInspector]
    public GameObject recycleWaste;

    [HideInInspector]
    public float moneyFactory;
    [HideInInspector]
    public float production;
    [HideInInspector]
    public float wasteProduction;
    [HideInInspector]
    public float recyclableWasteProduction;
    [HideInInspector]
    public float efficientcyPercentage;

    //Garbage Properties
    [HideInInspector]
    public float G_Cap;

    //Facility Poperties
    [HideInInspector]
    public float recycleFactor;
    [HideInInspector]
    public GameObject newRawMaterial;
    [HideInInspector]
    public GameObject recycleGarbage;

    //Mine Properties
    [HideInInspector]
    public GameObject rawMaterial;

    //House Properties
    [HideInInspector]
    public GameObject productWaste;
    [HideInInspector]
    public GameObject productRecycleWaste;
    [HideInInspector]
    public GameObject money;


    //Tech Poperties
    [HideInInspector]
    public float techPercentage;

    [HideInInspector]
    public float placementFixX;
    [HideInInspector]
    public float placementFixY;
    [HideInInspector]
    public bool even;
}

