using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour {

    public static int currentUpgrade;
    public static GameObject toBeUpgraded;
    public UpgradeManager upgradeManager;
    public static BuildingData buildData;
    public bool clicked;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}

    public void LevelUp( ) {
        currentUpgrade++;
        LevelUpBuilding();

    }

    public void LevelUpBuilding() {
        UpgradeManager upgradeData = UiManager.upgradeManager.GetComponent<Upgrade>().upgradeManager;
        switch (toBeUpgraded.gameObject.tag) {
            case "Factory":
                toBeUpgraded.gameObject.GetComponent<BuildingInfo>().buildData = upgradeData.factoryUpgrades[currentUpgrade];               
                break;
            case "Recycle":
                toBeUpgraded.gameObject.GetComponent<BuildingInfo>().buildData = upgradeData.recycleUpgrades[currentUpgrade];
                break;
            case "Garbage":
                toBeUpgraded.gameObject.GetComponent<BuildingInfo>().buildData = upgradeData.garbageUpgrades[currentUpgrade];
                break;

            default:
                break;
        }
       UiManager.UpdateHighlightText(toBeUpgraded.GetComponent<BuildingInfo>().buildData, UiManager.highlightPanel, null);
    }
}
