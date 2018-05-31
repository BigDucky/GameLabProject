using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TileManager : MonoBehaviour {

    public List<Material> tileSetMaterial = new List<Material>();
    public GameObject tilePrefab;

    public int mapLength, mapWidth;
    public Material disabledTile;
    public Material transparenttile;

    private float height = 0.105f;

    public float maxRocksize = 30;
    public float minRockkSize = 25;


    [HideInInspector]
    public static List<GameObject> tileList = new List<GameObject>();
    [HideInInspector]
    public static List<GameObject> disabledTilesList = new List<GameObject>();

    public Transform mapPos;
    public Transform disabledPos;
    public List<GameObject> totalrocks = new List<GameObject>();
    public List<GameObject> totalTrees = new List<GameObject>();

    // Use this for initialization
    void Start () {
        SpawnTile();
    }

    void Update() {
    }

    /// <summary>
    /// Gives it the propper name and adds them to the list + material
    /// </summary>
    void TileSetup(string name,int widthNR,int lengthNR,GameObject tile) {
        tile.name = "tileNR=" + "W:" + widthNR + "L:"+ lengthNR;
        tileList.Add(tile);
        tile.transform.SetParent(mapPos);
        tile.tag = "Tile";
        tile.layer = 8;
        if(tileSetMaterial == null) {
            Debug.Log("No Material Inserted (Default Material is Applied)");
        }
        else {
            int randomizer = Random.Range(0, 3);
            tile.gameObject.GetComponent<Renderer>().material = tileSetMaterial[randomizer];
        }
    }

    public static void NewDisabledTiles(Collider[] hitcollider, Material disabled, int buildingType) {
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
                    TileSetup("tileNR", i, j, tileNr);
                    SpawnRocks(tileNr);
                    SpawnTrees(tileNr);
                }
            }
        }
    }

    void SpawnTrees(GameObject tileNr) {
        if(Random.Range(0,25) == 1) {
            GameObject tree = Instantiate(totalTrees[Random.Range(0, 3)], new Vector3(tileNr.transform.position.x + Random.Range(0, 1), tileNr.transform.position.y, tileNr.transform.position.z), Quaternion.identity);
            tree.transform.rotation = Quaternion.Euler(tree.transform.rotation.x, Random.Range(0, 360), tree.transform.rotation.z);
        }
    }

    void SpawnRocks(GameObject tileNr) {
        if (Random.Range(0, 50) == 1) {
            GameObject rock = Instantiate(totalrocks[Random.Range(0, 13)], new Vector3(tileNr.transform.position.x + Random.Range(0, 1), tileNr.transform.position.y, tileNr.transform.position.z), Quaternion.Euler(Random.Range(0, 360), Random.Range(0, 360), Random.Range(0, 360)));
            rock.transform.SetParent(this.gameObject.transform);
            rock.transform.localScale = new Vector3(Random.Range(minRockkSize, maxRocksize), Random.Range(minRockkSize, maxRocksize), Random.Range(minRockkSize, maxRocksize));
            rock.AddComponent<BoxCollider>();
            rock.AddComponent<MaterialCollision>();
            rock.AddComponent<Rigidbody>().isKinematic = true;
            rock.transform.tag = "Environmental";

        }
    }
}
