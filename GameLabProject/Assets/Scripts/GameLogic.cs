using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings",menuName = "Settings")]
public class GameLogic : ScriptableObject {
	public float startMoney;
    public List<GameObject> Obuildings = new List<GameObject>();
}
