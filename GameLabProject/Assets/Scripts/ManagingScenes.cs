using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagingScenes : MonoBehaviour {

	public void changeTo(int sceneToChangeTo)
	{
		SceneManager.LoadScene(sceneToChangeTo);			
	}
}
