using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfo : MonoBehaviour {

    public string buildingName;
    public BuildingData buildData;

    private void Start() {
        EvenFix();
		//GameLogic.totalBuildings = 10;
    }

    void EvenFix() {

        if (buildData.length != 1) {
            if (buildData.length % 2 == 0) {
                buildData.even = true;
                buildData.placementFixX = (buildData.length * 0.25f) / (buildData.length/2) ;
            }
            else if (buildData.length % 2 != 0) {
                buildData.even = false;
                buildData.placementFixX = 0;
            }
        }
        
        if(buildData.width != 1) {
            if (buildData.width % 2 == 0) {
                buildData.even = true;
                buildData.placementFixY = (buildData.width *  0.25f) / (buildData.width/2) ;
            }
            else if (buildData.width % 2 != 0) {
                buildData.even = false;
                buildData.placementFixY = 0;
            }
        }
    }
}
