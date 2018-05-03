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

	[Range (0, 5)]
	public float turnSpeedHorizontal = 2.0f;
	[Range (0, 5)]
	public float turnSpeedVertical = 2.0f;

	private float yaw = 0.0f;
	private float pitch = 0.0f;

	private float cameraRotationY = 0.0f;
	private float cameraRotationX = 47.163f;
	private float cameraRotationZ = 0.0f;

	public 	Vector3 cameraRotation;

    private void Start() {
         xAxisValue = Input.GetAxisRaw("Horizontal");
         zAxisValue = Input.GetAxisRaw("Vertical");
		cameraRotation = new Vector3 (cameraRotationX, cameraRotationY, cameraRotationZ);
	}

	/*
    IEnumerator RotateMe(Vector3 byAngles, float inTime)
	{
		var fromAngle = transform.rotation;
		var toAngle = Quaternion.Euler (transform.eulerAngles + byAngles);
		for (var t = 0f; t < 1; t += Time.deltaTime/inTime) {
			transform.rotation = Quaternion.Slerp (fromAngle, toAngle, t);
			yield return null;			
		}
	}
	*/

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

		if(Input.GetKey(KeyCode.Mouse2))
		{
			yaw += turnSpeedHorizontal * Input.GetAxis("Mouse X");
			pitch += turnSpeedVertical * Input.GetAxis("Mouse Y");

			transform.eulerAngles = new Vector3(pitch + 47.163f, yaw, cameraRotationZ);
		}
			
		mainCamera.transform.Translate(new Vector3(xAxisValue, 0.0f, zAxisValue));

		/*
		if (Input.GetKeyDown ("r")) {
			StartCoroutine (RotateMe (Vector3.up * turnAngle, 0.7f));
		}
		if (Input.GetKeyDown ("q")) {
			StartCoroutine (RotateMe (Vector3.up * -(turnAngle), 0.7f));
		}
		*/

        if ( Input.GetAxis("Mouse ScrollWheel") > 0f) {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.2f, transform.position.z+ 0.2f);
        }
        else if ( Input.GetAxis("Mouse ScrollWheel")< 0) {
            transform.position = new Vector3(transform.position.x, transform.position.y + 0.2f, transform.position.z -0.2f);
        }
	}
}