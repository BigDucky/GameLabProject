using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour {
    public static int tutorialStep;
    public TextData dialogData;

    public static bool inTutorial = true;
    public static bool gameStart = false;
    public static bool levelUP;

    UiManager uimanager = new UiManager();


	// Use this for initialization
	void Start () {
        TutorialSetup();
    }
    
    // Update is called once per frame
    void Update () {
        if(levelUP) {
            switch (tutorialStep) {

                case 0:
                    TutorialSetup();
                    levelUP = false;
                    break;
                case 1:
                    //Step1();
                    levelUP = false;
                    break;
                case 4:
                    EndTutorial();
                    inTutorial = false;
                    levelUP = false;
                    break;

                default:
                    break;
            }
        }      
        if (inTutorial == false && gameStart == false) {
            if (Input.GetMouseButtonDown(0)) {
                UiManager.dialogUII.gameObject.SetActive(false);
                gameStart = true;
            }
        }

        CurrentTutorial();
    }

    public void CurrentTutorial() {

    }

    void EndTutorial() {
        for (int i = 0; i < uimanager.buildOptions.Count; i++) {
            uimanager.EnableButtons(i);
        }
        UiManager.ChangeText(dialogData.text[7]);
    }

    void TutorialSetup() {
        tutorialStep = 0;
        uimanager.DisableAllButtons();
        UiManager.ChangeText(dialogData.text[0]);      
    }

    public static void TutorialLevelUp() {
        tutorialStep++;
        levelUP = true;
    }

   // void Step1() {
     //   UiManager.EnableButtons(0);
    //    UiManager.ChangeText(dialogData.text[1]);
 //   }

}
