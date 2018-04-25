using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryProduction : MonoBehaviour {

    BuildingData factorySettings;
    public static float addedWaste;
    public static float recycleWaste;
    public static float production;
    GameObject money;
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
            timePassed++;
            if (timePassed == 300) {
                timePassed = 0;
                if(materialInPlace) {
                    ProduceMoney();

                    materialInPlace = false;
                }
            }
        }
    }

    void ProduceMoney() {
        money = Instantiate(factorySettings.product);
        money.transform.position = this.transform.position;
        money.transform.position = new Vector3(money.transform.position.x, 2, money.transform.position.z);
    }
    void ProduceWaste() {

    }

    public static void AddValues() {
        PlayerInfo.totalWaste += addedWaste;
        PlayerInfo.totalRecycleWaste += recycleWaste;
        PlayerInfo.totalRawMatUsed += production;
    }

}
