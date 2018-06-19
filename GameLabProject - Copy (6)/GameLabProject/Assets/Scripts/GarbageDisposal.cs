using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageDisposal : MonoBehaviour {

    BuildingData garbageDisposalSettings;
    public static float wasteCap;
    public float newWaste;
    public float currentWaste;
    Transform garbageHeap;
    Transform garbageHeapObject;
    float maxHeapHeight = 0.37f;
    float minHeapHeight = -3.13f;
    float differenceHeight;
    float garbageHeightPosition;
    Vector3 garbagePos;
    

	// Use this for initialization
	void Start () {
        garbageDisposalSettings = this.gameObject.GetComponent<BuildingInfo>().buildData;
        wasteCap = garbageDisposalSettings.G_Cap;
        garbageHeapObject = this.gameObject.transform.GetChild(0);
        garbageHeap = garbageHeapObject.gameObject.transform.GetChild(2);
        differenceHeight = maxHeapHeight - minHeapHeight;
        garbageHeightPosition = garbageHeap.transform.position.y;
    }

    // Update is called once per frame
    void Update () {
        newWaste = Mathf.RoundToInt(PlayerInfo.totalWaste / PlayerInfo.amountOfGarbageDisposal);

        if (newWaste > currentWaste) {
            float diffe = newWaste - currentWaste;
            garbageHeightPosition = garbageHeap.position.y + (differenceHeight / (wasteCap*10)) * diffe;
        }
        if(newWaste < currentWaste) {
            float diffe = currentWaste - newWaste;
            garbageHeightPosition = garbageHeap.position.y - (differenceHeight / (wasteCap*10)) * diffe;
        }      
       
        garbageHeap.transform.position = new Vector3 (garbageHeap.position.x, garbageHeightPosition, garbageHeap.position.z);

        currentWaste = Mathf.Clamp (newWaste,0,PlayerInfo.totalWasteCap);
    }

    public static void AddValues() {
        PlayerInfo.totalWasteCap += wasteCap;
    } 

    public void addWaste(int amount) {
        newWaste += amount;
    }
}
