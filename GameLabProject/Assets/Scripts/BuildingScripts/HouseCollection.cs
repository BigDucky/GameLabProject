using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseCollection : MonoBehaviour {
    public bool materialInPlace;
    private int timePassed;
    public bool processing;

    public float totalMatToProcess;
    public float moneyFactor;
   
    BuildingData houseSettings;
    public GameObject techSettings;
	// Use this for initialization
	void Start () {
        houseSettings = this.gameObject.GetComponent<BuildingInfo>().buildData;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (!TutorialManager.inTutorial) {
            if (materialInPlace) {
                timePassed++;
                processing = true;
                if (timePassed == houseSettings.collectTime) {
                    techSettings = GameObject.FindGameObjectWithTag("Tech");
                    timePassed = 0;
                    ProduceWaste();
                    ProduceRecycle();
                    ProduceMoney();
                    materialInPlace = false;
                    processing = false;
                }
            }
        }
    }

    void ProduceWaste() {
        GameObject waste = Instantiate(houseSettings.productWaste);
        waste.gameObject.transform.position = this.transform.position;
        waste.transform.position = new Vector3(waste.transform.position.x  *0.9f, 2, waste.transform.position.z);
        float wastePercentage = techSettings.GetComponent<BuildingInfo>().buildData.techPercentage;
        waste.AddComponent<MaterialInfoContainer>();
        waste.GetComponent<MaterialInfoContainer>().productWaste = totalMatToProcess * (1 - (wastePercentage / 100));
    }

    void ProduceRecycle() {
        GameObject recycle = Instantiate(houseSettings.productRecycleWaste);
        recycle.gameObject.transform.position = this.transform.position;
        recycle.transform.position = new Vector3(recycle.transform.position.x * 1.1f, 2, recycle.transform.position.z);
        float recyclePercentage = techSettings.GetComponent<BuildingInfo>().buildData.techPercentage;
        recycle.AddComponent<MaterialInfoContainer>().productRecycle = totalMatToProcess * (recyclePercentage / 100);
    }

    void ProduceMoney() {
        GameObject money = Instantiate(houseSettings.money);
        money.transform.position = this.transform.position;
        money.transform.position = new Vector3(money.transform.position.x, 2, money.transform.position.z);
        money.AddComponent<MaterialInfoContainer>().moneyGain = moneyFactor;
        //ADD MONEY 
    }
}
