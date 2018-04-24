using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour {
    public static float circularity;

    public static float totalMoney;
    public static float totalWaste;
    public static float totalRecycleWaste;
    public static float totalRawMat;
    public static float totalRawMatUsed;

    public static float totalWasteCap;

    public static float amountOfFactories;
    public static float amountOfRecycleFactories;
    public static float amountOfGarbageDisposal;

    // Use this for initialization
    void Start () {
        StartGameSettings();
	}

    void StartGameSettings() {
        totalMoney = Player.playerInfo.totalMoney;
        totalWaste = Player.playerInfo.totalWaste;
        totalRecycleWaste = Player.playerInfo.totalRecycleWaste;
        totalRawMat = Player.playerInfo.RawMaterialReserve;
        totalRawMatUsed = Player.playerInfo.totalRawMatUsed;

        amountOfFactories = 1;
        amountOfGarbageDisposal = 1;
        amountOfRecycleFactories = 1;
    }
	// Update is called once per frame

	public static void  UpdateMoneyCost(float cost){
		totalMoney = totalMoney - cost;
	}


}
