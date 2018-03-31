using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseHappiness : MonoBehaviour {
    BuildingData houseSettings;

    public static float individualHappiness;


    // Use this for initialization

    void Start () {
        houseSettings = this.gameObject.GetComponent<BuildingInfo>().buildData;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void HouseIndiviualHappiness() {
        individualHappiness = 100 - (PlayerInfo.wasteIndex + PlayerInfo.polutionIndex + PlayerInfo.taxIndex) + PlayerInfo.totalCircularity;
    }

    public static void AddValues() {

    }

}
