using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseHappiness : MonoBehaviour {
    BuildingData houseSettings;

    public static float individualHappiness;


    // Use this for initialization

    void Start () {
        houseSettings = this.gameObject.GetComponent<BuildingInfo>().buildData;
        HouseIndiviualHappiness();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void HouseIndiviualHappiness() {
        Debug.Log("Waste Index " + PlayerInfo.wasteIndex);
        Debug.Log("polution Index " + PlayerInfo.polutionIndex);
        Debug.Log("taxin Index " + PlayerInfo.taxes);
        Debug.Log(" TotalCirc  " + PlayerInfo.totalCircularity);
        individualHappiness = 100 - (PlayerInfo.wasteIndex + PlayerInfo.polutionIndex + PlayerInfo.taxIndex) + PlayerInfo.totalCircularity;
    }

    public static void AddValues() {
        PlayerInfo.totalIndividualHappiness = PlayerInfo.totalIndividualHappiness + individualHappiness;
    }

}
