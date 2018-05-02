using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterFFX : MonoBehaviour {
    private static float speed = 0.05f;
    public static string fullTxt;
    private static string currentTxt = "";

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static IEnumerator ShowTXt(Text text, string fullTxt) {
        for (int i = 0; i < fullTxt.Length; i++) {
            currentTxt = fullTxt.Substring(0, i);
            text.text = currentTxt;
            yield return new WaitForSeconds(speed);
        }
    }
}
