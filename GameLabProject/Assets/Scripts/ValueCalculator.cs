using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueCalculator : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        PlayerInfo.totalCircularity = (PlayerInfo.recyclableWaste / PlayerInfo.totalWaste) * 100 ; //*100 = precentage
        PlayerInfo.wasteIndex = 10 / PlayerInfo.totalWaste;
        PlayerInfo.polutionIndex = (PlayerInfo.totalPopulation / 2)/100;
        PlayerInfo.taxIndex = (PlayerInfo.wasteIndex + PlayerInfo.polutionIndex) / 2 * PlayerInfo.taxes / 100;
        PlayerInfo.totalHappiness = Mathf.RoundToInt(PlayerInfo.totalIndividualHappiness / PlayerInfo.amountOfHouses);// PlayerInfo.amountOfHouses);
        
    }
}
