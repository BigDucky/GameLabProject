using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSettings",menuName = "Settings")]
public class GameLogic : ScriptableObject {
    public float timeSpeed;
	public float startMoney;
    public float hapiness;
    public float population;
    public float taxes;
    public float recycable;
    public float polution;
    public List<GameObject> Obuildings = new List<GameObject>();
}
