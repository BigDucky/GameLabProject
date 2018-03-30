using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour {

	public Text totalMonetTxt;
	public Text totalPolTxt;

	public static float totalMoney;
	public static float totalIncome;
	public static float totalPol;
    public static float taxes;
    public static float populationGrowth;


	// Use this for initialization
	void Start () {
		totalMoney = Player.playerInfo.startMoney;
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
