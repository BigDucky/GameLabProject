using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Camera mainCamera;
	[Range (0, 10)]
	public float speed = 3f;

	float xAxisValue = Input.GetAxisRaw("Horizontal");
	float zAxisValue = Input.GetAxisRaw("Vertical");

	IEnumerator RotateMe(Vector3 byAngles, float inTime)
	{
		var fromAngle = transform.rotation;
		var toAngle = Quaternion.Euler (transform.eulerAngles + byAngles);
		for (var t = 0f; t < 1; t += Time.deltaTime/inTime) {
			transform.rotation = Quaternion.Slerp (fromAngle, toAngle, t);
			yield return null;			
		}
	}

	void Update()
	{
		if(Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(new Vector3(0,-speed * Time.deltaTime,0));
		}
		if(Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(new Vector3(0,speed * Time.deltaTime,0));
		}



		mainCamera.transform.Translate(new Vector3(xAxisValue, 0.0f, zAxisValue));

		if (Input.GetKeyDown ("r")) {
			StartCoroutine (RotateMe (Vector3.up * 90, 1f));
		}
		if (Input.GetKeyDown ("q")) {
			StartCoroutine (RotateMe (Vector3.up * -90, 1f));
		}
	}
}