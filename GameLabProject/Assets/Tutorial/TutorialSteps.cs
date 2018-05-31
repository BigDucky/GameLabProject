using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "TutorialStep", menuName = "Tutorial")]
public class TutorialSteps : ScriptableObject {

    public bool click;
    public bool buildButtonClick;
    public Sprite talker;
    [TextArea(15, 20)]
    public string text;
}
