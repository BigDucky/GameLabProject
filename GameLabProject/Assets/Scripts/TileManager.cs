using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class TileManager : MonoBehaviour {

    public GameObject tilePrefab;
    public int mapLength, mapWidth;
    public Material tileMaterial;
    public Material disabledTile;

    private float height = 0.105f;


    [HideInInspector]
    public static List<GameObject> tileList = new List<GameObject>();
    [HideInInspector]
    public static List<GameObject> disabledTilesList = new List<GameObject>();

    public Transform mapPos;

    // Use this for initialization
    void Start () {
        SpawnTile();
    }

    void Update() {
    }

    /// <summary>
    /// Gives it the propper name and adds them to the list + material
    /// </summary>
    void TileSetup(Material material, string name,int widthNR,int lengthNR,GameObject tile) {
        tile.name = "tileNR=" + "W:" + widthNR + "L:"+ lengthNR;
        tileList.Add(tile);
        tile.transform.SetParent(mapPos);
        tile.tag = "Tile";
        tile.layer = 8;
        tile.gameObject.AddComponent<TileData>().xPos = widthNR;
        tile.gameObject.GetComponent<TileData>().yPos = lengthNR;
        if(tileMaterial == null) {
            Debug.Log("No Material Inserted (Default Material is Applied)");
        }
        else {
            tile.gameObject.GetComponent<Renderer>().material = material;
        }
    }
 
    /*public static void DisableTile(int width, int lenght,GameObject tile, Material disabled, int mapWidth, int mapLength) {

        int widthTile = (width - 1) / 2;
        int lenghtTile = (lenght - 1) / 2;
        for (int i = 0; i < TileManager.tileList.Count; i++) {
            if (TileManager.tileList[i].name == tile.name) {
                for (int w = 0; w < width; w++) {
                    for (int l = 0; l < lenght; l++) {
                        tileList[i - widthTile * w + lenghtTile* l* mapWidth].GetComponent<Renderer>().material = disabled;

                        // tileList[i - widthTile + w].GetComponent<Renderer>().material = disabled;
                        // tileList[i - widthTile + w - lenghtTile * mapLength].GetComponent<Renderer>().material = disabled;
                        TileManager.disabledTilesList.Add(tileList[i - widthTile + w + lenghtTile * l * mapWidth]);
                    }
                    
                    //TODO change material into a bool that is disabled;
                                       
                    //TileManager.disabledTilesList.Add(tileList[i - widthTile + w + lenghtTile * mapWidth]);
                   // TileManager.disabledTilesList.Add(tileList[i - widthTile + w]);
                    //TileManager.disabledTilesList.Add(tileList[i - widthTile + w - lenghtTile * mapLength]);                    

                }
            }
        }
    }*/

    public static void NewDisabledTiles(Collider[] hitcollider, Material disabled) {
        for (int i = 0; i < hitcollider.Length; i++) {
            if (hitcollider[i].gameObject.tag == "Tile") {
                GameObject disabledTile = new GameObject();
                disabledTile.name = hitcollider[i].name;
                disabledTilesList.Add(disabledTile);
            }          
        }
        for (int j = 0; j < TileManager.tileList.Count; j++) {
            for (int k = 0; k < disabledTilesList.Count; k++) {
                if (tileList[j].name == disabledTilesList[k].name) {
                    tileList[j].GetComponent<Renderer>().material = disabled;
                }
            }
        }
    }

    /// <summary>
    /// Spawns the tile in a square, and adds things to the tiles
    /// </summary>
    void SpawnTile(){
        if (tilePrefab == null) {
            Debug.Log("No Tile Prefab Inserted");
        }
        else {
            for (int i = 0; i < mapWidth; i++) {
                for (int j = 0; j < mapLength; j++) {
                    GameObject tileNr = Instantiate(tilePrefab, new Vector3(mapPos.position.x + 1 * j, -height, mapPos.position.z + 1 * i), Quaternion.identity,this.transform.parent);
                    TileSetup(tileMaterial, "tileNR", i, j, tileNr);
                }
            }
        }
    }
}
