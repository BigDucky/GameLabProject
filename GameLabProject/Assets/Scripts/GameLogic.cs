using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings",menuName = "Settings")]
public class GameLogic : ScriptableObject {
    public List<GameObject> buildings = new List<GameObject>();
    public static List<GameObject> Obuildings = new List<GameObject>(); // Accesable for every script
	// Use this for initialization
	void Start () {
        Obuildings = buildings;
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log(buildings);
        Debug.Log(Obuildings);
    }
}
