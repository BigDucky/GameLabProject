using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour {

	public GameObject optionsMenu;
	public GameObject mainScreen;
	public static bool isOptionsMenu = false; 

	public void onClick()
	{
		if (isOptionsMenu)
		{
			closeOptions ();
		} else
		{
			openOptions ();
		}
	}

	public void openOptions()
	{
		optionsMenu.SetActive (true);
		mainScreen.SetActive (false);
		isOptionsMenu = true;
	}

	public void closeOptions()
	{
		mainScreen.SetActive (true);
		optionsMenu.SetActive (false);
		isOptionsMenu = false;
	}

}
