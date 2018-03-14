using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BuildingData", menuName = "Data")]
public class BuildingData:ScriptableObject{
    public int width;
    public int length;
    public bool even;
	public float buildingCost;
	public float income;
	public float polution;
}
