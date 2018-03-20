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
	public int yellowCost;
	GameLogic gamelogic;

	// Use this for initialization
	void Start () {
		totalMoney = 2;
		totalIncome = 0;
		totalPol = 0;
	}
	
	// Update is called once per frame
	void Update () {
		UpdateText ();
		Debug.Log (totalIncome);
	}


	void UpdateText(){
		totalMoney = totalMoney + totalIncome*Time.deltaTime*0.1f;
		totalMonetTxt.text = ""+ System.Math.Round(totalMoney + totalIncome * Time.deltaTime * 0.1f,1);
		totalPolTxt.text = "" + totalPol;
	}
	public static void  UpdateMoney(float cost, float income){
		totalMoney = totalMoney - cost;
		totalIncome = totalIncome + income;

		//totalMoney = totalMoney + cost * Time.deltaTime * 0.10f;
	}

	public static void UpdatePolution(float polation){
		totalPol += polation;

	}
}
