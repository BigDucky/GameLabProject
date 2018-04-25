using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecycleProcess : MonoBehaviour {

    BuildingData RecycleData;
    public static float recycleFactor;


    // Use this for initialization
    void Start () {

        RecycleData = this.GetComponent<BuildingInfo>().buildData;
        recycleFactor = RecycleData.recycleFactor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
