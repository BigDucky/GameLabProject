using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfo : MonoBehaviour {

    public BuildingData buildData;
   

    private void Start() {
        EvenFix();
        ContainsEven();
    }

    void EvenFix() {

        if (buildData.length != 1) {
            if (buildData.length % 2 == 0) {
                buildData.placementFixX = buildData.length * 0.25f;
            }
            else if (buildData.length % 2 != 0) {
                buildData.placementFixX = 0;
            }
        }
        
        if(buildData.width != 1) {
            if (buildData.width % 2 == 0) {
                buildData.placementFixY = buildData.width *  0.25f;
            }
            else if (buildData.width % 2 != 0) {
                buildData.placementFixY = 0;
            }
        }
    }

    void ContainsEven() {
        if(buildData.length %2 == 0 || buildData.width %2 == 0) {
            buildData.even = true;
        }
        else {
            buildData.even = false;
        }
    }
    

}
