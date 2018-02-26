using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TileManager : MonoBehaviour {

    public GameObject tile;
    public int mapLength, mapWidth;
    public Material tileMaterial;

    [HideInInspector]
    public List<GameObject> tileList = new List<GameObject>();
    [HideInInspector]
    public Transform mapPos;

    // Use this for initialization
    void Start () {
        SpawnTile();
	}

    /// <summary>
    /// Gives it the propper name and adds them to the list + material
    /// </summary>
    void TileSetup(Material material, string name,int widthNR,int lengthNR,GameObject tile) {
        tile.name = "tileNR" + widthNR + lengthNR;
        tileList.Add(tile);
        tile.transform.SetParent(mapPos);
        tile.tag = "Tile";
        tile.layer = 8;
        if(tileMaterial == null) {
            Debug.Log("No Material Inserted (Default Material is Applied)");
        }
        else {
            tile.gameObject.GetComponent<Renderer>().material = material;
        }
    }


    /// <summary>
    /// Spawns the tile in a square, and adds things to the tiles
    /// </summary>
    void SpawnTile(){
        if (tile == null) {
            Debug.Log("No Tile Prefab Inserted");
        }
        else {
            for (int i = 0; i < mapWidth; i++) {
                for (int j = 0; j < mapLength; j++) {
                    GameObject tileNr = Instantiate(tile, new Vector3(mapPos.position.x + 1 * j, 0, mapPos.position.z + 1 * i), Quaternion.identity,this.transform.parent);
                    TileSetup(tileMaterial, "tileNR", i, j, tileNr);
                }
            }
        }
    }
}
