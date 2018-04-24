using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageDisposal : MonoBehaviour {

    BuildingData garbageDisposalSettings;
    public static float wasteCap;
    public int newWaste;
    public int currentWaste;
    Transform garbageHeap;
    float maxHeapHeight = 0.017f;
    float minHeapHeight = -0.34f;
    float differenceHeight;
    float garbageHeightPosition;
    Vector3 garbagePos;
    

	// Use this for initialization
	void Start () {
        garbageDisposalSettings = this.gameObject.GetComponent<BuildingInfo>().buildData;
        wasteCap = garbageDisposalSettings.G_Cap;
        garbageHeap = this.gameObject.transform.GetChild(7);
        differenceHeight = maxHeapHeight - minHeapHeight;
        garbageHeightPosition = garbageHeap.transform.position.y;
       
    }
	
	// Update is called once per frame
	void Update () {
        newWaste =Mathf.RoundToInt( PlayerInfo.totalWaste / PlayerInfo.amountOfGarbageDisposal);
    
        if(newWaste > currentWaste) {
            int diffe = newWaste - currentWaste;
            garbageHeightPosition = garbageHeap.position.y + (differenceHeight / wasteCap) * diffe;
        }
        if(newWaste < currentWaste) {
            int diffe = currentWaste - newWaste;
            garbageHeightPosition = garbageHeap.position.y - (differenceHeight / wasteCap) * diffe;
        }
       
        garbageHeap.transform.position = new Vector3 (garbageHeap.position.x, garbageHeightPosition, garbageHeap.position.z);

        currentWaste = Mathf.Clamp (newWaste,0,100);

    }

    public static void AddValues() {
        PlayerInfo.totalWasteCap += wasteCap;
    }
}
