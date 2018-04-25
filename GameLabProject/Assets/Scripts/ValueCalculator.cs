using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueCalculator : MonoBehaviour {
   // private IEnumerator coroutine;

    private int timesPassedBy;

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    void Update() {

        PlayerInfo.circularity = PlayerInfo.totalRecycleWaste * RecycleProcess.recycleFactor;
        if (!TutorialManager.inTutorial) {
            timesPassedBy++;
            if(timesPassedBy == 600) {
                timesPassedBy = 0;
                MoneyIncome();
                RawMatUpdate();
            }
        }
        Debug.Log(PlayerInfo.totalRawMat);
    }

    void MoneyIncome() {
        PlayerInfo.totalMoney = PlayerInfo.totalMoney + PlayerInfo.totalRawMatUsed * 10;
    }
    void RawMatUpdate() {
        PlayerInfo.totalRawMat = (PlayerInfo.totalRawMat - PlayerInfo.totalRawMatUsed) + PlayerInfo.circularity;
    }

}
