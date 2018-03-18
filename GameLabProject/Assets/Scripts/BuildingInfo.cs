using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfo : MonoBehaviour {

    public BuildingData buildData;
    public bool even;
    public float placementFixX;
    public float placementFixY;

    private void Start() {
        EvenFix();
    }

    void EvenFix() {

        if (buildData.length != 1) {
            if (buildData.length % 2 == 0) {
                placementFixX = buildData.length * 0.25f;
            }
            else if (buildData.length % 2 != 0) {
                placementFixX = 0;
            }
        }
        
        if(buildData.width != 1) {
            if (buildData.width % 2 == 0) {
                placementFixY = buildData.width *  0.25f;
            }
            else if (buildData.width % 2 != 0) {
                placementFixY = 0;
            }
        }

    }
    

}
