using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {
    public static int tutorialStep;
    public TextData dialogData;

    public static bool inTutorial = true;
    public static bool gameStart = false;

	// Use this for initialization
	void Start () {
        TutorialSetup();

    }
    
    // Update is called once per frame
    void Update () {
        switch (tutorialStep) {

            case 0:
                TutorialSetup();
                break;
            case 1:
                Step1();
                break;
            case 2:
                Step2();
                break;
            case 3:
                Step3();
                break;
            case 4:
                EndTutorial();
                inTutorial = false;
                break;

            default:
                break;
        }

        if (inTutorial == false && gameStart == false) {
            if (Input.GetMouseButtonDown(0)) {
                UiManager.dialogUII.gameObject.SetActive(false);
                gameStart = true;
            }
        }

        if (tutorialStep == 0) {
            if (Input.GetMouseButtonDown(0)) {
                TutorialLevelUp();
            }
        }

        CurrentTutorial();
    }

    public void CurrentTutorial() {

    }

    void EndTutorial() {
        for (int i = 0; i < 5; i++) {
            UiManager.EnableButtons(i);
        }
        UiManager.ChangeText(dialogData.text[7]);
    }

    void TutorialSetup() {
        tutorialStep = 0;
        UiManager.DisableAllButtons();
        UiManager.ChangeText(dialogData.text[0]);      
    }

    public static void TutorialLevelUp() {
        tutorialStep++;
    }

    void Step1() {
        UiManager.EnableButtons(0);
        UiManager.ChangeText(dialogData.text[1]);
    }

    void Step2() {
        UiManager.DisableAllButtons();       
        UiManager.ChangeText(dialogData.text[2]);
        UiManager.EnableButtons(1);
    }

    void Step3() {
        UiManager.DisableAllButtons();
        UiManager.ChangeText(dialogData.text[3]);
        UiManager.EnableButtons(2);
    }
}
