using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryProduction : MonoBehaviour {

    BuildingData factorySettings;
    public static float addedWaste;
    public static float recycleWaste;
    public static float production;

    public bool processing;
 
    private int timePassed;
    public bool materialInPlace;



    // Use this for initialization
    void Start() {
        factorySettings = this.gameObject.GetComponent<BuildingInfo>().buildData;
        addedWaste = factorySettings.wasteProduction;
        recycleWaste = factorySettings.recyclableWasteProduction;
        production = factorySettings.production;
    }

    private void Update() {
        if (!TutorialManager.inTutorial) {
            if(materialInPlace) {
                processing = true;
                timePassed++;
                if (timePassed == factorySettings.productionSpeed) {
                    timePassed = 0;
                    if (materialInPlace) {
                        ProduceWaste();
                        ProduceMoney();
                        ProduceRecycleWaste();
                        materialInPlace = false;
                        processing = false;
                    }
                }
            }
        }
    }

    void ProduceMoney() {
        GameObject money = Instantiate(factorySettings.product);
        money.transform.position = this.transform.position;
        money.transform.position = new Vector3(money.transform.position.x, 2, money.transform.position.z);

    }
    void ProduceWaste() {
        GameObject nonRecycleWaste = Instantiate(factorySettings.nonRecycleWaste);
        nonRecycleWaste.transform.position = this.transform.position;
        nonRecycleWaste.transform.position = new Vector3(nonRecycleWaste.transform.position.x *1.1f, 2, nonRecycleWaste.transform.position.z);
       // PlayerInfo.totalRawMat = (PlayerInfo.totalRawMat - PlayerInfo.totalRawMatUsed) + PlayerInfo.circularity;
    }

    void ProduceRecycleWaste() {
        GameObject recycleWaste = Instantiate(factorySettings.recycleWaste);
        recycleWaste.transform.position = this.transform.position;
        recycleWaste.transform.position = new Vector3(recycleWaste.transform.position.x  *0.9f, 2, recycleWaste.transform.position.z);
    }

    public static void AddValues() {
        PlayerInfo.totalWaste += addedWaste;
        PlayerInfo.totalRecycleWaste += recycleWaste;
        PlayerInfo.totalRawMatUsed += production;
    }

}
