using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public bool isPlacing = false;
    private List<GameObject> buildingList = new List<GameObject>();

    private GameObject tempBuilding;
    private int buildingWidth;
    private int buildingLength;
    private int BuildingType;

    Collider[] hitColliders;

    public RaycastHit hit;
    public GameLogic gameLogic;

    private Vector3 mousPos;
    private bool canBuild = true;

    public TileManager tileManager;

    public Light testlight;

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
    /// Checks which tile is clicked and places thje building on the riht pos
    /// </summary>
    /// 
    void PlayerInteractions(int buildingType) {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit, 100f,1 << LayerMask.NameToLayer("Tile"))) {
                Debug.Log("Tile Selected = " + hit.collider.name);
                if(hit.collider.tag != "Tile") {
                    //Invalid 
                    //Message that it is not on a tile
                    return;
                }
                else {
                    BuildCheck();
                    if(!canBuild) {
                        Debug.Log("CANT BUILD JEZUS CHRIST");
                        Invoke("BuildingTimer", 0.1f);
                        testlight.color = Color.red;
                    }
                    else {
                        buildingWidth = tempBuilding.GetComponent<BuildingInfo>().buildData.width;
                        buildingLength = tempBuilding.GetComponent<BuildingInfo>().buildData.length;
                        PlaceBuilding(buildingType);
                        TileManager.DisableTile(buildingWidth, buildingLength, hit.collider.gameObject, tileManager.disabledTile, tileManager.mapWidth, tileManager.mapLength);
                        Destroy(tempBuilding);
                        isPlacing = false;
                    }
                }
            }
        }
        else {
            if(tempBuilding.GetComponent<BuildingInfo>().buildData.even) {
                MoveTempBuilding(hit, tempBuilding.GetComponent<BuildingInfo>().buildData.even);
            }
            MoveTempBuilding(hit, tempBuilding.GetComponent<BuildingInfo>().buildData.even);
        }
        
    }

    void BuildingTimer() {
        canBuild = true;
        testlight.color = Color.white;
    }

    void BuildCheck() {
         hitColliders = Physics.OverlapBox(tempBuilding.transform.position, tempBuilding.transform.localScale, Quaternion.identity);
        for (int i = 0; i < TileManager.disabledTilesList.Count; i++) {
            for (int j = 0; j < hitColliders.Length; j++) {
                if(hitColliders[j].name == TileManager.disabledTilesList[i].name) {
                    canBuild = false;
                }
            }
        }
    }

    //Moves the temporary building to the mouse position.
    void MoveTempBuilding(RaycastHit hit, bool even ) {
        if(even) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f, 1 << LayerMask.NameToLayer("Tile"))) {
                tempBuilding.transform.position.Set(hit.collider.transform.position.x,hit.collider.transform.position.y, hit.collider.transform.position.z);
            }
        }
        else {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f, 1 << LayerMask.NameToLayer("Tile"))) {
                tempBuilding.transform.position = new Vector3(hit.collider.transform.position.x, 0, hit.collider.transform.position.z);
            }
        }
     
    }

    //Instantiate the building on the mouse position
    void PlaceBuilding(int buildingType) {
            Instantiate(buildingList[buildingType], hit.transform.position, Quaternion.identity); 
    }

    //Selecting stage where it determites which building is selected ( also makes the temp building for visualization ) 
    public void SelectBuilding(int type) {
        Destroy(tempBuilding);
        isPlacing = true;
        BuildingType = type;
        tempBuilding = buildingList[type];
        TempBuilding();
    }

    public void TempBuilding() {
        tempBuilding = Instantiate(tempBuilding, new Vector3(0, 0, 0), Quaternion.identity);

    }

}
