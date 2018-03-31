using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryProduction : MonoBehaviour {

    BuildingData factorySettings;
    float timeFactor;
    public static float productionPerTimeFrame;
    public static float polution;
    public static float waste;
    public static float recycableWaste;


	// Use this for initialization
	void Start () {
        factorySettings = this.gameObject.GetComponent<BuildingInfo>().buildData;
        timeFactor = Player.playerInfo.timeSpeed;
        polution = factorySettings.polution;
        waste = factorySettings.totalWaste;
        recycableWaste = factorySettings.recyclableWaste;
        ProductionPerTimeFrame();
    }

    void ProductionPerTimeFrame() {
       productionPerTimeFrame = (factorySettings.production * timeFactor) * (40 / 4);
    }


    public static void  Addvalues() {
        PlayerInfo.totalProductionPerTimeF += productionPerTimeFrame;
        PlayerInfo.totalPol += polution;
        PlayerInfo.totalWaste += waste;
        PlayerInfo.recyclableWaste += recycableWaste;
    }

}
