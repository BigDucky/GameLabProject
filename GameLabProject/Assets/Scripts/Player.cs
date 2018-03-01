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
    private Vector3 mousPos;
	// Use this for initialization
	void Start () {
        buildingList = gameLogic.Obuildings;
	}
	
	// Update is called once per frame
	void Update () {
        if(isPlacing) {
            PlayerInteractions(BuildingType);// waiting for player to do something
        }
       
	}

    /// <summary>
    /// Checks which tile is clicked
    /// </summary>
    /// 
    void PlayerInteractions(int buildingType) {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit, 100f,1 << LayerMask.NameToLayer("Tile"))) {
                Debug.Log(hit.collider.name);
                if(hit.collider.tag != "Tile") {
                    //Invalid 
                    //Message that it is not on a tile
                    return;
                }
                else {
                    PlaceBuilding(buildingType);
                    TileManager.DisableTile(tempBuilding.GetComponent<BuildingInfo>().buildData.width, tempBuilding.GetComponent<BuildingInfo>().buildData.length, hit.collider.gameObject);
                    Destroy(tempBuilding);                   
                    isPlacing = false;
                }
            }
        }
        else {
            MoveTempBuilding(hit);
        }
        
    }

    void MoveTempBuilding(RaycastHit hit) {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 100f, 1<< LayerMask.NameToLayer("Tile"))) {
            tempBuilding.transform.position = hit.collider.transform.position;
        }
    }

    void PlaceBuilding(int buildingType) {
        Instantiate(buildingList[buildingType], hit.transform.position, Quaternion.identity);
    }

    public void SelectBuilding(int type) {
        isPlacing = true;
        BuildingType = type;
        tempBuilding = buildingList[type];
        TempBuilding();
    }

    public void TempBuilding() {
        tempBuilding = Instantiate(tempBuilding, new Vector3(0, 0, 0), Quaternion.identity);
    }

}
