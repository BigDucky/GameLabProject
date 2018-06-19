using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

	}

    public static void progressBarSettings(Transform transform, float maxValue) {
        Transform canvas = transform.GetChild(0);
        Transform slider = canvas.GetChild(0);
        slider.GetComponent<Slider>().maxValue = maxValue;
        canvas.transform.rotation = Quaternion.Euler(0, 0, 0);

    }
    public static void EnableProgressBar(Transform transform, int currentValue) {
        Transform canvas = transform.GetChild(0);
        Transform slider = canvas.GetChild(0);

        canvas.gameObject.SetActive(true);
        slider.gameObject.GetComponent<Slider>().value = currentValue;
    }

    public static void DisableProgressBar(Transform transform) {
        Transform canvas = transform.GetChild(0);
        canvas.gameObject.SetActive(false);

    }
}
