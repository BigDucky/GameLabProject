using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "UpgradeData", menuName = "UpgradeData")]
public class UpgradeManager : ScriptableObject {

    public List<BuildingData> factoryUpgrades;
    public List<BuildingData> techUpgrades;
    public List<BuildingData> garbageUpgrades;
    public List<BuildingData> recycleUpgrades;

}
