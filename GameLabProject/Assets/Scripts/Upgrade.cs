using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour {

    int currentUpgrade = 0;
    public List<BuildingData> upgrades = new List<BuildingData>();
    public GameObject toBeUpgraded;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void LevelUpBuilding() {
        currentUpgrade++;
        toBeUpgraded.gameObject.GetComponent<BuildingInfo>().buildData = upgrades[currentUpgrade];
    }
}
