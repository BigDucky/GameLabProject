using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour {

	public GameObject optionsMenu;
	public GameObject mainScreen;
	public static bool isOptionsMenu = false; 

	// Update is called once per frame
	void Update () {
		onClick ();
	}

	void onClick()
	{
		if (isOptionsMenu)
		{
			closeOptions ();
		} else
		{
			openOptions ();
		}
	}

	void openOptions()
	{
		optionsMenu.SetActive (true);
		mainScreen.SetActive (false);
		isOptionsMenu = true;
	}

	void closeOptions()
	{
		mainScreen.SetActive (true);
		optionsMenu.SetActive (false);
		isOptionsMenu = false;
	}

}
