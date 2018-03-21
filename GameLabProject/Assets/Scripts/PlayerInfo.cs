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

	GameLogic gamelogic;

	// Use this for initialization
	void Start () {
		totalMoney = 50;
		totalIncome = 0;
		totalPol = 0;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateValues ();
	}

	void UpdateValues(){
		totalMoney = totalMoney + totalIncome*Time.deltaTime*0.1f;
	}

	public static void  UpdateMoneyCost(float cost){
		totalMoney = totalMoney - cost;
	}

	public static void UpdatePolution(float polation){
		totalPol += polation;
	}

    public static void UpdateTotalProduction(float production) {

    }

}
