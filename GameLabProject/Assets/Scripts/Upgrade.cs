using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour {

    public static int currentUpgrade;
    public static GameObject toBeUpgraded;
    public UpgradeManager upgradeManager;
    public static BuildingData buildData;
    public bool clicked;


    public int lol;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

        Debug.Log(currentUpgrade);
	}

    public void LevelUp( ) {
        currentUpgrade++;
        LevelUpBuilding();

        Debug.Log(lol);

    }

    public void EnableTechOption(GameObject tech) {
        toBeUpgraded = tech;
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
            case "Tech":
                toBeUpgraded.gameObject.GetComponent<BuildingInfo>().buildData = upgradeData.techUpgrades[currentUpgrade];
                GameObject.Find("UIManager").GetComponent<UiManager>().levelTechUp();

                return;

            default:
                break;
        }
       UiManager.UpdateHighlightText(toBeUpgraded.GetComponent<BuildingInfo>().buildData, UiManager.highlightPanel, null);
    }
}
