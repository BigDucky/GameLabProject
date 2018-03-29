using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitButton: MonoBehaviour {

	public void onClick()
	{
			QuitGame ();
	}

	public void QuitGame()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
}