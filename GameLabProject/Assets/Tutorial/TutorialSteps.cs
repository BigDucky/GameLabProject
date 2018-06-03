using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TutorialStep", menuName = "Tutorial")]
public class TutorialSteps : ScriptableObject {

    public string ACTION;
    public Sprite talker;

    public bool disableAllButtons;
    

    [TextArea(15, 20)]
    public string text;


    [HideInInspector]
    public bool conditionsMet;

    [TextArea(5, 5)]
    

    public string THESE_ARE_THE_ACTIONS = "CLICK -- BUILDBUTTON -- BUILD";
}
