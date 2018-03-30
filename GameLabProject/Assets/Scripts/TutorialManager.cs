using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {
    public static int tutorialStep;
    public TextData dialogData;

    public static bool inTutorial = true;

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
            default:
                break;
        }

        CurrentTutorial();
    }

    public void CurrentTutorial() {

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
        UiManager.EnableButtons(1);
        UiManager.ChangeText(dialogData.text[2]);
    }

    void Step3() {
        UiManager.DisableAllButtons();
        UiManager.EnableButtons(2);
        UiManager.ChangeText(dialogData.text[3]);
    }

    void Step4() {
        UiManager.DisableAllButtons();
        UiManager.EnableButtons(3);
        UiManager.ChangeText(dialogData.text[4]);
    }
}
