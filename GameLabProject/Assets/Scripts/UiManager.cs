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

    public List<GameObject> buildOptions;

    public static GameObject highlightPanel;
    public static GameObject upgradeManager;

    public Text totalMoneyTxt;
    public Text totalPolTxt;
    public Text circularity;
    public Text rawMaterialTxt;

    public static string fullTxt;
    public static bool startTxt;

    public List<Button> totalButtons;
    public static List<Button> StotalButtons;

    int index;
    public Text timer;
    float time;
    float minute;
    float hour;
    float day;
    int month = 1;
    int year = 2018;
    List<int> diffMonths = new List<int>();


    Coroutine co;
   
    void Start() {
        highlightPanel = GameObject.Find("HighLightPanel");
        upgradeManager = GameObject.Find("UpgradeManager");
        highlightPanel.gameObject.SetActive(false);

        for (int i = 0; i < totalButtons.Count; i++) {
            StotalButtons[i] = totalButtons[i];
        }

        dialogTxt = dialogUI.transform.GetChild(0) ;
        dialogUII = dialogUI;
        //pauseCanvas.gameObject.SetActive(false);
        int[] dates = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
        diffMonths.AddRange(dates);

    }

    // Update is called once per frame
    void Update() {
        UpdateText();
        runTimer();

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

    public void runTimer() {
        time += Mathf.RoundToInt(Time.deltaTime * 50);
        day = Mathf.RoundToInt(time / 24);
        if (day > diffMonths[index]) {
            time = 0;
            month++;
            if(index == 12) {
                index = 0;
            }
            index++;
        }

        if (month > 12) {
            year++;
            month = 1;
        }

        timer.text = "" + day + "/" + month + "/" + year;
    }

    public static void UpdateHighlightText(BuildingData buildData, GameObject highLightpanel, GameObject selectedObject) {
        
        highLightpanel.gameObject.SetActive(true);
        Transform text = highLightpanel.transform.Find("Stats");
        Transform title = highLightpanel.transform.Find("Title");
        Upgrade.currentUpgrade = buildData.level-1;
        if (selectedObject !=null) {          
            Upgrade.buildData = buildData;
            Upgrade.toBeUpgraded = selectedObject;
        }     
        string buildingName = buildData.name;
        title.GetComponent<Text>().text = buildData.name;
        TextSelection(buildData, text.GetComponent<Text>());
    }

    public static void TextSelection(BuildingData buildData, Text text) {
        UpgradeManager upgradeData = upgradeManager.GetComponent<Upgrade>().upgradeManager;
        for (int i = 0; i < 6; i++) {
            if (buildData.name == "Factory " + i) {
                if (i < 5) {
                    text.text = "Upgrade Level: " + (buildData.level + 1) + "   || Upgrade Cost:" + upgradeData.factoryUpgrades[Upgrade.currentUpgrade + 1].buildingCost + "\n" +
                    "Efficientcy: " + buildData.efficientcyPercentage + " %" + "\n" +
                    "Waste:" + buildData.wasteProduction + "\n" +
                    "Recycleble Waste:" + buildData.recyclableWasteProduction + "\n" +
                    "Money Factor:" + buildData.moneyFactory;
                }
                else {
                    text.text = "Fully Upgraded";
                }             
            }
            else if(buildData.name == "Garbage " + i) {
                if (i < 5) {
                    text.text = "Upgrade Level: " + (buildData.level + 1) + "   || Upgrade Cost:" + upgradeData.garbageUpgrades[Upgrade.currentUpgrade + 1].buildingCost + "\n" +
                    "Garbage Capacity:" + buildData.G_Cap + "\n" +
                    "Total Garbage Capacity:" + PlayerInfo.totalWasteCap;
                    
                }
                else {
                    text.text = "Fully Upgraded";
                }            
            }
            else if(buildData.name == "House " + i) {
                text.text = "Tech / recycle factor :" + buildData.techPercentage;
            }
            else if (buildData.name == "Recycle " + i) {
                if (i < 5) {
                    text.text = "Upgrade Level: " + (buildData.level + 1) + "   || Upgrade Cost:" + upgradeData.recycleUpgrades[Upgrade.currentUpgrade + 1].buildingCost + "\n" +
                    "Recycleble of total :" + buildData.recycleFactor + "\n" +
                    " Wasted: " + (100 - buildData.recycleFactor);

                }
                else {
                    text.text = "Fully Upgraded";
                }
                
            }
        }
    }

    public void DisableCurrentCanvas(Canvas currentCanvas) {
        currentCanvas.gameObject.SetActive(false);
    }

    void UpdateText() {
         totalMoneyTxt.GetComponent<Text>().text = "" + System.Math.Round(PlayerInfo.totalMoney);// +// PlayerInfo.totalIncome * Time.deltaTime * 0.1f, 1);
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

    public static void DisableAllButtons( ) {
        
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
