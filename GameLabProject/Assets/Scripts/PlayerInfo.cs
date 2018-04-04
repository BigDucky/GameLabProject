using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour {

    public static float totalMoney;
	public static float totalPol;
    public static float totalCircularity;
    public static float totalPopulation;
    public static float totalHappiness;
    public static float taxes;

    public static float totalProductionPerTimeF;
    public static float totalWaste;
    public static float recyclableWaste;
    public static float totalIndividualHappiness;


    public static float wasteIndex;
    public static float polutionIndex;
    public static float taxIndex;
    public static float aoeIndex = 5;


    public static int amountOfFactories;
    public static int amountOfHouses;


	// Use this for initialization
	void Start () {
		totalMoney = Player.playerInfo.startMoney;
        //totalCircularity = Player.playerInfo.;
        totalPopulation = Player.playerInfo.population;
        totalHappiness = Player.playerInfo.hapiness;
        totalPol = Player.playerInfo.polution;
        taxes = Player.playerInfo.taxes;
        totalWaste = Player.playerInfo.waste;
        recyclableWaste = Player.playerInfo.recycable;
        totalIndividualHappiness = Player.playerInfo.hapiness;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateValues ();
        Debug.Log(totalIndividualHappiness);
    }

    void UpdateValues(){
		//totalMoney = totalMoney + totalIncome*Time.deltaTime* gamelogic.timeSpeed;
	}

	public static void  UpdateMoneyCost(float cost){
		totalMoney = totalMoney - cost;
	}


}
