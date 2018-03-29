using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {

	bool isPause;

	public void OnButtonClick()
	{
		if (isPause = false)
		{
			isPause = true;
			Time.timeScale = 0;
			// Display pause menu/screen
		} else
		{
			isPause = true;
			Time.timeScale = 1;
			// Disable pause menu/screen
		}
	}
}
