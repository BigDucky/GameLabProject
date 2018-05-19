using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessHandle : MonoBehaviour {
    BuildingData buildingSettings;

    public bool materialInPlace;
    public bool processing;
    private int timePassed;

    Transform thisTransform;

    // recycle
    [HideInInspector]
    public float totalRecycleMat;

    // housings
    [HideInInspector]
    public float totalMatToProcess;
    [HideInInspector]
    public float moneyFactor;
    [HideInInspector]
    public GameObject techSettings;

    //Factory

    // Use this for initialization
    void Start () {
        buildingSettings = this.gameObject.GetComponent<BuildingInfo>().buildData;
        thisTransform = this.gameObject.transform;
	}

    // Update is called once per frame
    void Update() {
        if (!TutorialManager.inTutorial) {
            if (materialInPlace) {
                if(this.gameObject.tag == "Product" && timePassed == 0) {
                    GameObject money = Instantiate(buildingSettings.money);

                    //Settings for money
                    money.transform.position = this.transform.position;
                    money.transform.position = new Vector3(money.transform.position.x, 2, money.transform.position.z);
                    money.AddComponent<MaterialInfoContainer>().moneyGain = moneyFactor;
                }
                ProgressBar.progressBarSettings(thisTransform, buildingSettings.collectTime);
                ProgressBar.EnableProgressBar(thisTransform, timePassed);
                processing = true;
                timePassed++;                             
                if(timePassed > 0 && timePassed == buildingSettings.collectTime) {
                    timePassed = 0;
                    ProduceItems();
                    materialInPlace = false;
                    processing = false;
                    ProgressBar.DisableProgressBar(thisTransform);
                }

            }
        }
    }

    void ProduceItems() {
        if (buildingSettings.factory) {
            FactoryItems();
        }
        else if (buildingSettings.recycle) {
            RecycleFacilityItems();
        }
        else if (buildingSettings.house) {
            HouseItems();
        }
        else if(buildingSettings.mine) {
            MineItems();
        }
    }

    void FactoryItems() {
        GameObject nonRecycleWaste = Instantiate(buildingSettings.nonRecycleWaste);
        GameObject product = Instantiate(buildingSettings.product);
        GameObject recycleWaste = Instantiate(buildingSettings.recycleWaste);

        //Settings for nonRecycleWaste
        nonRecycleWaste.transform.position = this.transform.position;
        nonRecycleWaste.transform.position = new Vector3(nonRecycleWaste.transform.position.x * 1.1f, 2, nonRecycleWaste.transform.position.z);
        nonRecycleWaste.AddComponent<MaterialInfoContainer>().productWaste = buildingSettings.wasteProduction;

        //Settings for Product
        product.transform.position = this.transform.position;
        product.transform.position = new Vector3(product.transform.position.x, 2, product.transform.position.z);
        product.AddComponent<MaterialInfoContainer>().moneyGain = buildingSettings.moneyFactory;
        product.GetComponent<MaterialInfoContainer>().totalMaterial = buildingSettings.production * (buildingSettings.efficientcyPercentage / 100);

        //Settings for Recycle Waste
        recycleWaste.transform.position = this.transform.position;
        recycleWaste.transform.position = new Vector3(recycleWaste.transform.position.x * 0.9f, 2, recycleWaste.transform.position.z);
        recycleWaste.AddComponent<MaterialInfoContainer>().productRecycle = buildingSettings.recyclableWasteProduction;
    }

    void RecycleFacilityItems() {
        GameObject newRawMat = Instantiate(buildingSettings.newRawMaterial);

        newRawMat.transform.position = this.transform.position;
        newRawMat.transform.position = new Vector3(newRawMat.transform.position.x, 2, newRawMat.transform.position.z);
        newRawMat.AddComponent<MaterialInfoContainer>().ratMatGain = totalRecycleMat * (buildingSettings.recycleFactor / 100);
    }

    void HouseItems() {
        techSettings = GameObject.FindGameObjectWithTag("Tech");

        GameObject waste = Instantiate(buildingSettings.productWaste);
        GameObject recycle = Instantiate(buildingSettings.productRecycleWaste);
       

        //Settings for Waste
        waste.gameObject.transform.position = this.transform.position;
        waste.transform.position = new Vector3(waste.transform.position.x * 0.9f, 2, waste.transform.position.z);
        float wastePercenage = techSettings.GetComponent<BuildingInfo>().buildData.techPercentage;
        waste.AddComponent<MaterialInfoContainer>().productWaste = totalMatToProcess * (1 - (wastePercenage / 100));

        //Setting for recycle waste
        recycle.gameObject.transform.position = this.transform.position;
        recycle.transform.position = new Vector3(recycle.transform.position.x * 1.1f, 2, recycle.transform.position.z);
        float recyclePercentage = techSettings.GetComponent<BuildingInfo>().buildData.techPercentage;
        recycle.AddComponent<MaterialInfoContainer>().productRecycle = totalMatToProcess * (recyclePercentage / 100);

    }

    void MineItems() {
        PlayerInfo.totalRawMat -= PlayerInfo.totalRawMatUsed;
        GameObject rawMaterial = Instantiate(buildingSettings.rawMaterial);

        rawMaterial.transform.position = this.transform.position;
        rawMaterial.transform.position = new Vector3(rawMaterial.transform.position.x, 2, rawMaterial.transform.position.z);
    }
}
