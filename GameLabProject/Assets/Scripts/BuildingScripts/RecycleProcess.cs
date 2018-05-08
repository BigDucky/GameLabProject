using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleProcess : MonoBehaviour {
    private int timePassed;

    BuildingData recycleData;
    public static float recycleFactor;

    public bool materialInPlace;
    public bool processing;

    public float totalRecycleMat;


    // Use this for initialization
    void Start () {

        recycleData = this.GetComponent<BuildingInfo>().buildData;
        recycleFactor = recycleData.recycleFactor;
	}
	
	// Update is called once per frame
	void Update () {
        if (!TutorialManager.inTutorial) {
            if (materialInPlace) {
                timePassed++;
                processing = true;
                if (timePassed == recycleData.recycleSpeed) {
                    timePassed = 0;
                    ProduceNewMaterial ();
                    materialInPlace = false;
                    processing = false;
                }
            }
        }
    }

    void ProduceNewMaterial() {
        GameObject newRawMat = Instantiate(recycleData.newRawMaterial);
        newRawMat.transform.position = this.transform.position;
        newRawMat.transform.position = new Vector3(newRawMat.transform.position.x, 2, newRawMat.transform.position.z);
        newRawMat.AddComponent<MaterialInfoContainer>().ratMatGain = totalRecycleMat * (recycleData.recycleFactor / 100);

        //PlayerInfo.totalRawMat += PlayerInfo.totalRecycleWaste;
    }
}
