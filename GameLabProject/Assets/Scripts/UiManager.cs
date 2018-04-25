using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

    public GameObject buildPanel;
    public static List<Transform> allButtons = new List<Transform>();

    public static Transform dialogTxt;
    public GameObject dialogUI;
    public static GameObject dialogUII;


    public Canvas buildCanvas;
    public Canvas UIinterface;
    public Canvas mainCanvas;
    public Canvas pauseCanvas;

    public Text totalMoneyTxt;
    public Text totalPolTxt;
    public Text circularity;
    public Text rawMaterialTxt;

    void Start() {

        for (int i = 0; i < buildPanel.transform.childCount; i++) {
            allButtons.Add(buildPanel.transform.GetChild(i));
        }

        dialogTxt = dialogUI.transform.GetChild(1);
        dialogUII = dialogUI;
        //pauseCanvas.gameObject.SetActive(false);
        buildCanvas.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update() {
        UpdateText();       
    }

    public void DisableCurrentCanvas(Canvas currentCanvas) {
        currentCanvas.gameObject.SetActive(false);
    }

    void UpdateText() {
         totalMoneyTxt.text = "" + System.Math.Round(PlayerInfo.totalMoney);// +// PlayerInfo.totalIncome * Time.deltaTime * 0.1f, 1);
         totalPolTxt.text = "" + PlayerInfo.totalWaste ;
         circularity.text = "" + PlayerInfo.circularity;
         rawMaterialTxt.text = "" + PlayerInfo.totalRawMat;
    }

    public void OpenCanvas(Canvas toBeOpenedCanvas) {
       /// if(TutorialManager.tutorialStep == 0) {
       //     TutorialManager.TutorialLevelUp();
      //  }
        if(toBeOpenedCanvas.gameObject.activeSelf == true) {
            toBeOpenedCanvas.gameObject.SetActive(false);
        }
        else {
            toBeOpenedCanvas.gameObject.SetActive(true);
        }       
    }

    public static void DisableAllButtons() {
        for (int i = 0; i <UiManager.allButtons.Count; i++) {
            allButtons[i].gameObject.GetComponent<Button>().interactable = false;
        }
    }

    public static void EnableButtons(int buttonInList) {
        allButtons[buttonInList].gameObject.GetComponent<Button>().interactable = true;
    }

    public static void ChangeText(string text) {
        dialogTxt.GetComponent<Text>().text = text;
    }

    public static void CloseDialog() {
        dialogUII.gameObject.SetActive(false);

    }
}
