using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

    public Canvas buildCanvas;
    public Canvas UIinterface;

    public Text totalMonetTxt;
    public Text totalPolTxt;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        UpdateText();
	}

    public void DisableCurrentCanvas(Canvas currentCanvas) {
        currentCanvas.gameObject.SetActive(false);
    }

    void UpdateText() {
        totalMonetTxt.text = "" + System.Math.Round(PlayerInfo.totalMoney + PlayerInfo.totalIncome * Time.deltaTime * 0.1f, 1);
        totalPolTxt.text = "" + PlayerInfo.totalPol;
    }

    public void OpenCanvas(Canvas toBeOpenedCanvas) {

        if(toBeOpenedCanvas.gameObject.activeSelf == true) {
            toBeOpenedCanvas.gameObject.SetActive(false);
        }
        else {
            toBeOpenedCanvas.gameObject.SetActive(true);
        }
        

    }
}
