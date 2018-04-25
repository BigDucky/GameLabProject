using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryProduction : MonoBehaviour {

    BuildingData factorySettings;
    public static float addedWaste;
    public static float recycleWaste;
    public static float production;



    // Use this for initialization
    void Start() {
        factorySettings = this.gameObject.GetComponent<BuildingInfo>().buildData;
        addedWaste = factorySettings.wasteProduction;
        recycleWaste = factorySettings.recyclableWasteProduction;
        production = factorySettings.production;

    }

    public static void AddValues() {
        PlayerInfo.totalWaste += addedWaste;
        PlayerInfo.totalRecycleWaste += recycleWaste;
        PlayerInfo.totalRawMatUsed += production;
    }

}
