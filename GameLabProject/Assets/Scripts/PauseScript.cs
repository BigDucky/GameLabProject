using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {

	public static bool isPause = false;
	public GameObject mainUI;
	public GameObject pauseMenuUI;
	public Button pauseButton;

	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape))
		{
			if (isPause)
			{
				Resume ();
				Debug.Log("Resume");
				return;
			} else
			{
				Pause ();
				Debug.Log ("Pause");
				return;
			}
		
		}
	}

	public void OnClick(){
		if (isPause)
		{
			Resume ();
		} else
		{
			Pause ();
		}
	}

	public void Resume(){
		pauseMenuUI.SetActive (false);
		mainUI.SetActive (true);
		Time.timeScale = 1f;
		isPause = false;
	}

	void Pause(){
		mainUI.SetActive (false);
		pauseMenuUI.SetActive (true);
		Time.timeScale = 0f;
		isPause = true;
	}

	public void LoadMenu(){
		Time.timeScale = 1f;
		SceneManager.LoadScene ("Menu");
	}


}