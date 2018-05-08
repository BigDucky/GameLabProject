using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseScript : MonoBehaviour {

	bool isPause = false;
	public Button pauseButton;

	void Update(){
		
		Debug.Log (isPause);

		}

	public void PauseGame(){

		if (isPause) {
			Time.timeScale = 1;
			Debug.Log("Paused!");
			isPause = !isPause;
		}
		else if (!isPause){
			Time.timeScale = 0;
			Debug.Log("Unpaused!");
			isPause = !isPause;

		}
			
		//if(Input.GetButtonDown(KeyCode(pauseButton)))
	//	{ 
			/*//if (isPause = false)
			{
				
				Time.timeScale = 0;
				// Display pause menu/screen
				Debug.Log("Paused!");
			isPause =! isPause;
		} else if(isPause)
			{
			isPause =! isPause;
				
				Time.timeScale = 1;
				// Disable pause menu/screen
				Debug.Log("Unpaused!");
			}*/
		//}
	}
}