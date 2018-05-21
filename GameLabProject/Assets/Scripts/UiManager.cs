using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UiManager : MonoBehaviour {

    public GameObject buildPanel;

    public static Transform dialogTxt;
    public GameObject dialogUI;
    public static GameObject dialogUII;

    public List<GameObject> buildOptions = new List<GameObject>();

    public static GameObject highlightPanel;

    public Text totalMoneyTxt;
    public Text totalPolTxt;
    public Text circularity;
    public Text rawMaterialTxt;

    public static string fullTxt;
    public static bool startTxt;

    Coroutine co;

    void Start() {
        highlightPanel = GameObject.Find("HighLightPanel");
        highlightPanel.gameObject.SetActive(false);

        dialogTxt = dialogUI.transform.GetChild(0) ;
        dialogUII = dialogUI;
        //pauseCanvas.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update() {
        UpdateText();

        if (startTxt) {
            if(co != null) {

                StopCoroutine(co);
                co = StartCoroutine(TypeWriterFFX.ShowTXt(dialogTxt.GetComponent<Text>(), fullTxt));
                startTxt = false;
            }
            else {
                co = StartCoroutine(TypeWriterFFX.ShowTXt(dialogTxt.GetComponent<Text>(), fullTxt));
                startTxt = false;
            }

        }
    }

    public static void UpdateHighlightText(BuildingData buildData, GameObject highLightpanel) {
        highLightpanel.gameObject.SetActive(true);
        Transform text = highLightpanel.transform.Find("Stats");
        Transform title = highLightpanel.transform.Find("Title");
        string buildingName = buildData.name;
        title.GetComponent<Text>().text = buildData.name;
        text.GetComponent<Text>().text = "All the buildings variables from " + buildData ;
    }

    public void DisableCurrentCanvas(Canvas currentCanvas) {
        currentCanvas.gameObject.SetActive(false);
    }

    void UpdateText() {
         totalMoneyTxt.text = "" + System.Math.Round(PlayerInfo.totalMoney);// +// PlayerInfo.totalIncome * Time.deltaTime * 0.1f, 1);
         totalPolTxt.text = "" + PlayerInfo.totalWaste  + "/" + PlayerInfo.totalWasteCap;
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

    public void DisableAllButtons() {
        for (int i = 0; i <buildOptions.Count; i++) {
            Transform button = buildOptions[i].gameObject.transform.Find("ClickPanel");
            button.GetComponent<Button>().interactable = false;
            Debug.Log("asdas");
        }
    }

    public  void EnableButtons(int buttonInList) {
        buildOptions[buttonInList].gameObject.GetComponent<Button>().interactable = true;
    }

    public static void ChangeText(string text) {
        // dialogTxt.GetComponent<Text>().text = text;       
        fullTxt = text;
        startTxt = true;
       
    }

    public static void CloseDialog() {
        dialogUII.gameObject.SetActive(false);
    }
}
