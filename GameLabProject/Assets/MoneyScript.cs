using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour {

    public static Transform moneyText;
    public int moneyPrice = 100;

    private void Start()
    {
        moneyText = this.gameObject.transform.Find("Text");
    }
    public static void MoneyAnimation(float moneyGain)
    {
        moneyText.GetComponent<Text>().text = "" + moneyGain;
    }

}
