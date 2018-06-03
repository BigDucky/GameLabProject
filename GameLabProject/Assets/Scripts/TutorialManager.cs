﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {
    public static int tutorialStep;
    public TextData dialogData;

    public static bool inTutorial = false;
    public static bool gameStart = false;
    public static bool levelUP;

    public bool buildButtonClick;
    public static bool build;
    public static bool click;

    public bool waitingForPlayer;
    public string playerActionNeeded;
    public bool selectedBuilding;

    UiManager uimanager;

    public List<TutorialSteps> allSteps;

	// Use this for initialization
	void Start () {
        uimanager = GameObject.Find("UIManager").GetComponent<UiManager>();
        TutorialSetup();
    }
    
    // Update is called once per frame
    void Update () {
        if (waitingForPlayer) {
            nextCheckPoint(playerActionNeeded);
        }

        Debug.Log(build);

      /*  if (inTutorial == false && gameStart == false) {
            if (Input.GetMouseButtonDown(0)) {
                UiManager.dialogUII.gameObject.SetActive(false);
                gameStart = true;
            }
        }*/
    }

    public void EnableBuildCheck() {
        buildButtonClick = true;
        Invoke("ResetBool", 1);
    }

    public void EnableSelectedBuildckeck() {
        selectedBuilding = true;
        Invoke("ResetBool", 1);
    }

    void ResetBool() {
        buildButtonClick = false;
        selectedBuilding = false;
    }

    void EndTutorial() {
        for (int i = 0; i < uimanager.buildOptions.Count; i++) {
            uimanager.EnableButtons(i);
        }
        uimanager.ChangeText(dialogData.text[7]);
    }

    void TutorialSetup() {
        tutorialStep = 0;
        //uimanager.DisableAllButtons();
        uimanager.personImage.sprite = allSteps[tutorialStep].talker;
        uimanager.ChangeText(allSteps[tutorialStep].text);
        playerActionNeeded = allSteps[tutorialStep].ACTION;
        waitingForPlayer = true;
    }

    void nextTutorialStep() {
        tutorialStep++;
        uimanager.personImage.sprite = allSteps[tutorialStep].talker;
        uimanager.ChangeText(allSteps[tutorialStep].text);
        playerActionNeeded = allSteps[tutorialStep].ACTION;
        waitingForPlayer = true;
    }

    void nextCheckPoint(string type) {
        switch (type) {
            case "CLICK":
                if (Input.GetMouseButtonDown(0)) {               
                    waitingForPlayer = false;
                    nextTutorialStep();
                }
                break;
            case "BUILDBUTTON":
                if (buildButtonClick) {
                    waitingForPlayer = false;
                    nextTutorialStep();

                }
                break;
            case "SELECTBUILDING":
                if (selectedBuilding) {
                    waitingForPlayer = false;
                    nextTutorialStep();
                }
                break;
            case "BUILD":
                if (build) {
                    waitingForPlayer = false;
                    nextTutorialStep();
                }
            break;

            default:

                break;
        }
    }
   // void Step1() {
     //   UiManager.EnableButtons(0);
    //    UiManager.ChangeText(dialogData.text[1]);
 //   }

}
