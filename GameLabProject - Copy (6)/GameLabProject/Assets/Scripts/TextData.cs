using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DialogData", menuName = "DialogData")]
public class TextData : ScriptableObject {
    [TextArea]
    public List<string> text = new List<string>();
}
