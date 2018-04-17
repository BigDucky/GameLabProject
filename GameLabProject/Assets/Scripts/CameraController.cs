using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public Camera mainCamera;
	[Range (0, 10)]
	public float speed = 5f;
	[Range (0, 360)]
	public int turnAngle = 90;

    float xAxisValue;
    float zAxisValue;

    private void Start() {
         xAxisValue = Input.GetAxisRaw("Horizontal");
         zAxisValue = Input.GetAxisRaw("Vertical");
    }




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
		if(Input.GetKey(KeyCode.D))
		{
			transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.A))
		{
			transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.S))
		{
			transform.Translate(new Vector3(0,-speed * Time.deltaTime,0));
		}
		if(Input.GetKey(KeyCode.W))
		{
			transform.Translate(new Vector3(0,speed * Time.deltaTime,0));
		}



		mainCamera.transform.Translate(new Vector3(xAxisValue, 0.0f, zAxisValue));

		if (Input.GetKeyDown ("r")) {
			StartCoroutine (RotateMe (Vector3.up * turnAngle, 0.7f));
		}
		if (Input.GetKeyDown ("q")) {
			StartCoroutine (RotateMe (Vector3.up * -(turnAngle), 0.7f));
		}

        if ( Input.GetAxis("Mouse ScrollWheel") > 0f) {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z+ 0.2f);
        }
        else if ( Input.GetAxis("Mouse ScrollWheel")< 0) {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z -0.2f);
        }
	}
}