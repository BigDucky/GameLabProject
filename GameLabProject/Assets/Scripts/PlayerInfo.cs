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


	// Use this for initialization
	void Start () {
		totalMoney = Player.playerInfo.startMoney;
        totalCircularity = Player.playerInfo.recycable;
        totalPopulation = Player.playerInfo.population;
        totalHappiness = Player.playerInfo.hapiness;
        totalPol = Player.playerInfo.polution;
        taxes = Player.playerInfo.taxes;
        
	}
	
	// Update is called once per frame
	void Update () {
		UpdateValues ();
	}

	void UpdateValues(){
		//totalMoney = totalMoney + totalIncome*Time.deltaTime* gamelogic.timeSpeed;
	}

	public static void  UpdateMoneyCost(float cost){
		totalMoney = totalMoney - cost;
	}


}
