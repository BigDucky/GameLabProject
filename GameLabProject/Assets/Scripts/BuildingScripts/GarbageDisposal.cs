using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageDisposal : MonoBehaviour {

    BuildingData garbageDisposalSettings;
    public static float wasteCap;
    public float newWaste;
    public float currentWaste;
    Transform garbageHeap;
    float maxHeapHeight = 0.017f;
    float minHeapHeight = -0.34f;
    float differenceHeight;

    

	// Use this for initialization
	void Start () {
        garbageDisposalSettings = this.gameObject.GetComponent<BuildingInfo>().buildData;
        wasteCap = garbageDisposalSettings.G_Cap;
        garbageHeap = this.gameObject.transform.GetChild(0).GetChild(1);
        differenceHeight = maxHeapHeight - minHeapHeight;
        Debug.Log(garbageHeap.gameObject.name);

	}
	
	// Update is called once per frame
	void Update () {
        if(newWaste > currentWaste) {
            for (int i = 0; i < newWaste; i++) {
                garbageHeap.transform.position = new Vector3(garbageHeap.position.x, garbageHeap.position.y + (differenceHeight / wasteCap), garbageHeap.position.z);
                currentWaste = newWaste;
            }
        }
        Debug.Log("Differ" + differenceHeight);
        Debug.Log("waste cap " + wasteCap);

    }
}
