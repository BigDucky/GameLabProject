using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineProcess : MonoBehaviour {
    private int timePassed;
    BuildingData mineData;
    public bool on = false;
    // Use this for initialization
    void Start () {
        mineData = this.gameObject.GetComponent<BuildingInfo>().buildData;
	}
	
	// Update is called once per frame
	void Update () {
        if (!TutorialManager.inTutorial) {
            if(on) {
                timePassed++;
                if (timePassed == mineData.mineTime) {
                    timePassed = 0;
                    ProduceRawMaterial();
                    on = false;
                    PlayerInfo.totalRawMat -= PlayerInfo.totalRawMatUsed;
                }
            }
        }
    }

    void ProduceRawMaterial() {
        GameObject rawMaterial = Instantiate(mineData.rawMaterial);
        rawMaterial.transform.position = this.transform.position;
        rawMaterial.transform.position = new Vector3(rawMaterial.transform.position.x, 2, rawMaterial.transform.position.z);

    }
}
