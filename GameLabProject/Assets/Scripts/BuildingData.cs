using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Data")]
public class BuildingData : ScriptableObject {

    // CheckBoxes for the type of building 
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

    // width and height for the building
    [Range (0,5)]
    public int width;
    [Range (0,5)]
    public int length;

    // overall values for every building
    public float buildingCost;
    public float collectTime;

    //Factory Propperties

        // GameObjects that the factory produces
    [HideInInspector]
    public GameObject product;
    [HideInInspector]
    public GameObject nonRecycleWaste;
    [HideInInspector]
    public GameObject recycleWaste;

        // Values that is needed for the factory
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

        // Values that is needed for the Garbage
    [HideInInspector]
    public float G_Cap;

    //Facility Poperties

        // GameObjects that the recycle facility produces
    [HideInInspector]
    public float recycleFactor;
    [HideInInspector]
    public GameObject newRawMaterial;
    [HideInInspector]
    public GameObject recycleGarbage;

    //MINE PROPERTIES

        // GameObjects that the recycle mine produces
    [HideInInspector]
    public GameObject rawMaterial;

    //House Properties

     // GameObjects that the house produces
    [HideInInspector]
    public GameObject productWaste;
    [HideInInspector]
    public GameObject productRecycleWaste;
    [HideInInspector]
    public GameObject money;


    //TECH PROPERTIES

    [HideInInspector]
    public float techPercentage;


    //PLACEMENT FIXES 

    [HideInInspector]
    public float placementFixX;
    [HideInInspector]
    public float placementFixY;
    [HideInInspector]
    public bool even;
}

