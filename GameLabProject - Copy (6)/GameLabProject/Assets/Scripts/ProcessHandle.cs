﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProcessHandle : MonoBehaviour {
    BuildingData buildingSettings;

    public bool materialInPlace;
    [HideInInspector]
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
        if(this.gameObject.tag == "Product") {
            techSettings = GameObject.FindGameObjectWithTag("Tech");
            this.gameObject.GetComponent<BuildingInfo>().buildData.techPercentage = techSettings.GetComponent<BuildingInfo>().buildData.techPercentage;
        }
	}

    public void EnableProcessHandler() {
        materialInPlace = true;
    }

    // Update is called once per frame
    void Update() {
        //if (!TutorialManager.inTutorial) {
            if (materialInPlace) {
                buildingSettings = this.gameObject.GetComponent<BuildingInfo>().buildData;

            if (this.gameObject.tag == "Product" && timePassed == 0) {
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
                    if (timePassed > 0 && timePassed == buildingSettings.collectTime)
                    {
                        timePassed = 0;
                        ProduceItems();
                        materialInPlace = false;
                        processing = false;
                        ProgressBar.DisableProgressBar(thisTransform);
                    }
              
         //   }
                
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
        nonRecycleWaste.transform.position = new Vector3(nonRecycleWaste.transform.position.x + 2f, 2, nonRecycleWaste.transform.position.z);
        nonRecycleWaste.AddComponent<MaterialInfoContainer>().productWaste = buildingSettings.wasteProduction;

        //Settings for Product
        product.transform.position = this.transform.position;
        product.transform.position = new Vector3(product.transform.position.x, 2, product.transform.position.z);
        product.AddComponent<MaterialInfoContainer>().moneyGain = buildingSettings.moneyFactory;
        product.GetComponent<MaterialInfoContainer>().totalMaterial = buildingSettings.production * (buildingSettings.efficientcyPercentage / 100);

        //Settings for Recycle Waste
        recycleWaste.transform.position = this.transform.position;
        recycleWaste.transform.position = new Vector3(recycleWaste.transform.position.x - 2f, 2, recycleWaste.transform.position.z);
        recycleWaste.AddComponent<MaterialInfoContainer>().productRecycle = buildingSettings.recyclableWasteProduction;

        if (this.GetComponent<BuildingInfo>().buildData.efficientcyPercentage == 100) {
            Destroy(nonRecycleWaste);
            Destroy(recycleWaste);
        }

    }

    void RecycleFacilityItems() {
        GameObject newRawMat = Instantiate(buildingSettings.newRawMaterial);
        GameObject waste = Instantiate(buildingSettings.recycleGarbage);

        //Settings for New Raw Material
        newRawMat.transform.position = this.transform.position;
        newRawMat.transform.position = new Vector3(newRawMat.transform.position.x * 1.1f,2, newRawMat.transform.position.z);
        newRawMat.AddComponent<MaterialInfoContainer>().ratMatGain = totalRecycleMat * (buildingSettings.recycleFactor / 100);

        //settings for Waste
        waste.transform.position = this.transform.position;
        waste.transform.position = new Vector3(newRawMat.transform.position.x * 0.9f,2, newRawMat.transform.position.z);
        waste.AddComponent<MaterialInfoContainer>().productWaste = totalRecycleMat- (totalRecycleMat * (buildingSettings.recycleFactor / 100));

        if(waste.GetComponent<MaterialInfoContainer>().productWaste == 0) {
            Destroy(waste);
        }
    }

    void HouseItems() {

        techSettings = GameObject.FindGameObjectWithTag("Tech");
        this.gameObject.GetComponent<BuildingInfo>().buildData.techPercentage = techSettings.GetComponent<BuildingInfo>().buildData.techPercentage;

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

        if(waste.GetComponent<MaterialInfoContainer>().productWaste == 0) {
            Destroy(waste);
        }
    }

    void MineItems() {
        PlayerInfo.totalRawMat -= PlayerInfo.totalRawMatUsed;
        GameObject rawMaterial = Instantiate(buildingSettings.rawMaterial);

        rawMaterial.transform.position = this.transform.position;
        rawMaterial.transform.position = new Vector3(rawMaterial.transform.position.x, 2, rawMaterial.transform.position.z);
    }
}
