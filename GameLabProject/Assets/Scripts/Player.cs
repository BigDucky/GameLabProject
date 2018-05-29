using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
    public bool isPlacing = false;
    private List<GameObject> buildingList = new List<GameObject>();

    private GameObject tempBuilding;
    private BuildingData buildingData;

    private int BuildingType;

    Collider[] hitColliders;

    public RaycastHit hit;
    public GameLogic gameLogic;
    public static GameLogic playerInfo;

    public int index;
    public Text timer;
    public float time;
    public float minute;
    public float hour;
    public float day;
    public int month = 1;
    public int year = 2018;

    public List<int> diffMonths = new List<int>();

    private Vector3 mousPos;
    private bool canBuild = true;

    public Transform buildingOwned;

    public TileManager tileManager;

    public Light testlight;

    public float currentRotation;
    public bool rotated = false;

    public static bool deletingStage;
    public GameObject grabbedObject;
    bool grabbed;

    // Use this for initialization
    void Start () {
        buildingList = gameLogic.Obuildings;
        playerInfo = gameLogic;
        int[] dates = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        diffMonths.AddRange(dates);
    }

    // Update is called once per frame
    void Update () {

        runTimer();

        if(isPlacing) {
            PlayerInteractions(BuildingType);// waiting for player to do something
        }

        ObjectPlacement();

        HighlightBuilding();

        //Highlight stuff
        /*RaycastHit buildingHit;
        Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray2, out buildingHit, 100f, 1 << LayerMask.NameToLayer("Building"))) {
           Transform buildingTransform = buildingHit.collider.gameObject.GetComponent<Transform>();
           Transform halo =  buildingTransform.GetChild(1);
            halo.gameObject.SetActive(true);
        }*/


    }

    public void runTimer()
    {
        time += Mathf.RoundToInt(Time.deltaTime * 100);
        day = Mathf.RoundToInt(time/24);
        if(day > diffMonths[index])
        {
            time = 0;
            month++;
            index++;
        }

        if(month > 12)
        {
            year++;
            month = 1;
        }

        timer.text = "" + day + "/" + month + "/" + year;
    }

    void ObjectPlacement() { 
        if (Input.GetMouseButton(0)) {
            SelectObject();
        }
        else if (Input.GetMouseButtonUp(0) && grabbed) {
            PlaceObject();
        }
        else {
            grabbed = false;
            grabbedObject = null;
        }
        if (grabbedObject != null) {
            MoveObject();
        }
    }

    void HighlightBuilding() {

        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hitted;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitted, 100f, 1 << LayerMask.NameToLayer("Building"))) {
                if (!isPlacing) {
                    BuildingData selectedData = hitted.collider.gameObject.GetComponent<BuildingInfo>().buildData;
                    UiManager.UpdateHighlightText(selectedData, UiManager.highlightPanel, hitted.collider.gameObject);
                    // highlight 

                     //update UI 
                }
            }
        }
    }


    void SelectObject() {
        RaycastHit hitted;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hitted, 100f, 1 << LayerMask.NameToLayer("Object"))) {
            grabbedObject = hitted.collider.gameObject;
            if ( grabbedObject.gameObject.tag == "RawMaterial") {
                PlayerInfo.totalRawMat += grabbedObject.gameObject.GetComponent<MaterialInfoContainer>().ratMatGain;
                Destroy(grabbedObject);
            }
            else if(grabbedObject.gameObject.tag == "Money") {
                PlayerInfo.totalMoney += grabbedObject.gameObject.GetComponent<MaterialInfoContainer>().moneyGain * 1000;
                Destroy(grabbedObject);
            }
            else {
                grabbed = true;
                grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
            }
        }
    }

    void MoveObject() {
        if (grabbed) {
            RaycastHit hit;
            Ray ray2 = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray2, out hit, 100f, 1 << LayerMask.NameToLayer("Tile"))) {
                Vector3 newPos = new Vector3(hit.collider.transform.position.x, 0.5f, hit.collider.transform.position.z);
                grabbedObject.transform.position = Vector3.Lerp(grabbedObject.transform.position, newPos, 0.2f);               
            }
        }
    }

    void PlaceObject() {
        if (grabbedObject.gameObject.GetComponent<Rigidbody>()) {
            grabbedObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }

    /// <summary>
    /// Checks which tile is clicked and places thje building on the riht pos
    /// </summary>
    /// 
	void PlayerInteractions(int buildingType) {
        if (Input.GetMouseButtonDown(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f, 1 << LayerMask.NameToLayer("Tile"))) {
                //Debug.Log("Tile Selected = " + hit.collider.name);
                if (hit.collider.tag != "Tile") {
                    //Invalid 
                    //Message that it is not on a tile                
                }
                else {
                    BuildCheck();
                    if (!canBuild) {
                        Invoke("BuildingTimer", 1f);
                        testlight.color = Color.red;
                    }
                    else {
                        UpdateGrid(buildingType);
                    }
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.E)) {
            RotateBuilding();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && isPlacing) {
            Debug.Log("Pressed ESC");
            Destroy(tempBuilding);
            isPlacing = false;
        }

        else {
            MoveTempBuilding(/*hit,*/buildingData.even);
        }       
    }

    public void DeleteBuilding() {
        deletingStage = true;
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
		PlaceBuilding(buildingType);
        TileManager.NewDisabledTiles(hitColliders,tileManager.disabledTile,buildingType);
        Destroy(tempBuilding);
        currentRotation = 0;
        rotated = false;
        isPlacing = false;
	}

    void BuildCheck() {
        if (rotated) {
            hitColliders = Physics.OverlapBox(tempBuilding.transform.position, new Vector3(buildingData.length * 0.3f, 1, buildingData.width * 0.3f), Quaternion.identity);
        }
        else {
            hitColliders = Physics.OverlapBox(tempBuilding.transform.position, new Vector3(buildingData.width * 0.3f, 1, buildingData.length * 0.3f), Quaternion.identity);
        }
        if (PlayerInfo.totalMoney < buildingData.buildingCost) {
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
    void MoveTempBuilding( /*RaycastHit hit,*/ bool even ) {
        if(even) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100f, 1 << LayerMask.NameToLayer("Tile"))) {
                if (rotated) {
                    tempBuilding.transform.position = new Vector3(hit.collider.transform.position.x + buildingData.placementFixX, 0, hit.collider.transform.position.z + buildingData.placementFixY);
                }
                else {
                    tempBuilding.transform.position = new Vector3(hit.collider.transform.position.x + buildingData.placementFixY, 0, hit.collider.transform.position.z + buildingData.placementFixX);
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

         UpdatePlayerInfo(buildingType);


        //0.105f = heigth fix
        if (!tempBuilding.GetComponent<BuildingInfo>().buildData.even) {
            GameObject placedBuilding = Instantiate(buildingList[buildingType], new Vector3(hit.transform.position.x, hit.transform.position.y + 0.105f, hit.transform.position.z), Quaternion.Euler(0, currentRotation, 0));
            placedBuilding.transform.SetParent(buildingOwned);
        }
        else {
            if (rotated) {
                GameObject placedBuilding = Instantiate(buildingList[buildingType], new Vector3(hit.transform.position.x + buildingData.placementFixX, 
                hit.transform.position.y + 0.105f,
                hit.transform.position.z + buildingData.placementFixY), 
                Quaternion.Euler(0, currentRotation, 0));
                placedBuilding.transform.SetParent(buildingOwned);
            }
            else {
                GameObject placedBuilding = Instantiate(buildingList[buildingType], new Vector3(hit.transform.position.x + buildingData.placementFixY,
                hit.transform.position.y + 0.105f,
                hit.transform.position.z + buildingData.placementFixX),
                Quaternion.Euler(0, currentRotation, 0));
                placedBuilding.transform.SetParent(buildingOwned);
            }
        }
    }

    void UpdatePlayerInfo(int buildingType) {
        if(!TutorialManager.inTutorial) {
            PlayerInfo.UpdateMoneyCost(buildingData.buildingCost);

            switch (buildingType) {
                case 2:
                    PlayerInfo.amountOfRecycleFactories++;          
                    break;
                case 1:
                    PlayerInfo.amountOfGarbageDisposal++;
                    GarbageDisposal.AddValues();

                    break;
                default:
                    break;
            }
        }

    }

    //Selecting stage where it determites which building is selected ( also makes the temp building for visualization ) 
    public void SelectBuilding(int type) {
  		Destroy(tempBuilding);
        isPlacing = true;
        BuildingType = type;
        tempBuilding = buildingList[type];
        buildingData = tempBuilding.GetComponent<BuildingInfo>().buildData;
        TempBuilding();
    }

    public void TempBuilding() {
        tempBuilding = Instantiate(tempBuilding, new Vector3(0, 0, 0), Quaternion.identity);
    }


}
