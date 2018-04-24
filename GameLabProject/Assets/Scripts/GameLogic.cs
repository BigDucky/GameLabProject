using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings",menuName = "Settings")]
public class GameLogic : ScriptableObject {
    public float timeSpeedInSeconds;
    public int RawMaterialReserve;
    public float totalMoney;
    public float totalWaste;
    public float totalRecycleWaste;
    public float totalRawMatUsed;
    public List<GameObject> Obuildings = new List<GameObject>();
}
