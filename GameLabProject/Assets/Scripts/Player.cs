using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public bool isPlacing = false;
    private List<GameObject> buildingList = new List<GameObject>();
    public RaycastHit hit;
    public GameLogic gameLogic;
    private GameObject tempBuilding;
    private int BuildingType;
	// Use this for initialization
	void Start () {
        buildingList = gameLogic.Obuildings;
	}
	
	// Update is called once per frame
	void Update () {
        if(isPlacing) {
            PlayerInteractions(BuildingType);
            tempBuilding.transform.position = Input.mousePosition;
        }
	}

    /// <summary>
    /// Checks which tile is clicked
    /// </summary>
    /// 
    void PlayerInteractions(int buildingType) {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit, 100f)) {
                PlaceBuilding(buildingType);
                isPlacing = false;
            }
        }
    }

    void PlaceBuilding(int buildingType) {
        Instantiate(buildingList[buildingType], hit.transform.position, Quaternion.identity);
    }

    public void SelectBuilding(int type) {
        isPlacing = true;
        BuildingType = type;
        tempBuilding = buildingList[type];
        Instantiate(tempBuilding);
    }

}
