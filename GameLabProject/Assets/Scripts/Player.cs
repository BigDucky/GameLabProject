using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public bool isPlacing = false;
    private List<GameObject> buildingList = new List<GameObject>();

    private GameObject tempBuilding;
   // private int buildingWidth;
    //private int buildingLength;
    private int BuildingType;

    Collider[] hitColliders;

    public RaycastHit hit;
    public GameLogic gameLogic;

    private Vector3 mousPos;
    private bool canBuild = true;

    public Transform buildingOwned;

    public TileManager tileManager;

    public Light testlight;

    GameObject tempthingie; // Delete maybe

    public float currentRotation;
    private bool rotated = false;

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
                //Debug.Log("Tile Selected = " + hit.collider.name);
                if(hit.collider.tag != "Tile") {
                    //Invalid 
                    //Message that it is not on a tile                
                }
                else {                  
                    BuildCheck();
                    if(!canBuild) {
                        Invoke("BuildingTimer", 1f);
                        testlight.color = Color.red;
                    }
                    else {
						UpdateGrid (buildingType);
						//Updates the amount of Cash
						PlayerInfo.UpdateMoney (tempBuilding.GetComponent<BuildingInfo>().buildData.buildingCost, tempBuilding.GetComponent<BuildingInfo>().buildData.income);
						if (buildingType != 0) {
							PlayerInfo.UpdatePolution (tempBuilding.GetComponent<BuildingInfo> ().buildData.polution);
						} else {
							
							PlayerInfo.UpdatePolution (-tempBuilding.GetComponent<BuildingInfo> ().buildData.polution);
							//PlayerInfo.totalMoney = PlayerInfo.totalMoney + tempBuilding.GetComponent<BuildingInfo> ().buildData.polution;
						}
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.E)){
            RotateBuilding();
        }
        else {
            if (tempBuilding.GetComponent<BuildingInfo>().buildData.even) {
                MoveTempBuilding(hit, tempBuilding.GetComponent<BuildingInfo>().buildData.even);
                Debug.Log("123");
            }
            else {
                MoveTempBuilding(hit, tempBuilding.GetComponent<BuildingInfo>().buildData.even);

            }
        }       
    }

    void RotateBuilding() {
        if(isPlacing) {
            tempBuilding.transform.Rotate(0, +90, 0);
            currentRotation = tempBuilding.transform.eulerAngles.y;
            rotated = !rotated;
        }
    }

	void BuildingTimer() {
        canBuild = true;
        testlight.color = Color.white;
    }

	void UpdateGrid(int buildingType){
		//buildingWidth = tempBuilding.GetComponent<BuildingInfo>().buildData.width;
		//buildingLength = tempBuilding.GetComponent<BuildingInfo>().buildData.length;
		PlaceBuilding(buildingType);
        TileManager.NewDisabledTiles(hitColliders,tileManager.disabledTile);
        //Updates the used up tiles
       /* if (!rotated) {
            TileManager.DisableTile(buildingWidth, buildingLength, hit.collider.gameObject, tileManager.disabledTile, tileManager.mapWidth, tileManager.mapLength);
        }
        else {
            TileManager.DisableTile(buildingLength, buildingWidth, hit.collider.gameObject, tileManager.disabledTile, tileManager.mapWidth, tileManager.mapLength);
        }*/
        Destroy(tempBuilding);
        currentRotation = 0;
        rotated = false;
        isPlacing = false;
	}

    void BuildCheck() {
        if (rotated) {
            hitColliders = Physics.OverlapBox(tempBuilding.transform.position, new Vector3(tempBuilding.GetComponent<BuildingInfo>().buildData.length * 0.3f, 1, tempBuilding.GetComponent<BuildingInfo>().buildData.width * 0.3f), Quaternion.identity);
        }
        else {
            hitColliders = Physics.OverlapBox(tempBuilding.transform.position, new Vector3(tempBuilding.GetComponent<BuildingInfo>().buildData.width * 0.3f, 1, tempBuilding.GetComponent<BuildingInfo>().buildData.length * 0.3f), Quaternion.identity);
        }
        tempthingie = tempBuilding;
        if (PlayerInfo.totalMoney < tempBuilding.GetComponent<BuildingInfo> ().buildData.buildingCost) {
			canBuild = false;
		} else {			
			for (int j = 0; j < hitColliders.Length; j++) {
				for (int i = 0; i < TileManager.disabledTilesList.Count; i++) {              
					if (hitColliders [j].name == TileManager.disabledTilesList [i].name) {
						canBuild = false;
					}
				}
			}
		}
    }

    //Moves the temporary building to the mouse position.
    void MoveTempBuilding(RaycastHit hit, bool even ) {
        if(even) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f, 1 << LayerMask.NameToLayer("Tile"))) {
                if (rotated) {
                    tempBuilding.transform.position = new Vector3(hit.collider.transform.position.x + tempBuilding.GetComponent<BuildingInfo>().placementFixX, 0, hit.collider.transform.position.z + tempBuilding.GetComponent<BuildingInfo>().placementFixY);
                }
                else {
                    tempBuilding.transform.position = new Vector3(hit.collider.transform.position.x + tempBuilding.GetComponent<BuildingInfo>().placementFixY, 0, hit.collider.transform.position.z + tempBuilding.GetComponent<BuildingInfo>().placementFixX);
                }
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
        //0.105f = heigth fix
        if (!tempBuilding.GetComponent<BuildingInfo>().buildData.even) {
            GameObject placedBuilding = Instantiate(buildingList[buildingType], new Vector3(hit.transform.position.x, hit.transform.position.y + 0.105f, hit.transform.position.z), Quaternion.Euler(0, currentRotation, 0));
            placedBuilding.transform.SetParent(buildingOwned);
        }
        else {
            if (rotated) {
                GameObject placedBuilding = Instantiate(buildingList[buildingType], new Vector3(hit.transform.position.x + tempBuilding.GetComponent<BuildingInfo>().placementFixX, hit.transform.position.y + 0.105f,
                    hit.transform.position.z + tempBuilding.GetComponent<BuildingInfo>().placementFixY), 
                    Quaternion.Euler(0, currentRotation, 0));
                placedBuilding.transform.SetParent(buildingOwned);
            }
            else {
                GameObject placedBuilding = Instantiate(buildingList[buildingType], new Vector3(hit.transform.position.x + tempBuilding.GetComponent<BuildingInfo>().placementFixY, hit.transform.position.y + 0.105f, hit.transform.position.z + tempBuilding.GetComponent<BuildingInfo>().placementFixX), Quaternion.Euler(0, currentRotation, 0));
                placedBuilding.transform.SetParent(buildingOwned);
            }
        }
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
