using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    public bool isPlacing = false;
    private List<GameObject> buildingList = new List<GameObject>();
    public RaycastHit hit;
	// Use this for initialization
	void Start () {
        buildingList = GameLogic.Obuildings;
	}
	
	// Update is called once per frame
	void Update () {
        PlayerInteractions();

	}

    /// <summary>
    /// Checks which tile is clicked
    /// </summary>
    void PlayerInteractions() {
        if (Input.GetMouseButton(0)) {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit, 100f)) {
                PlaceBuilding();
            }
        }
    }

    void PlaceBuilding() {
        Instantiate(buildingList[0], hit.transform.position, Quaternion.identity);
    }

}
