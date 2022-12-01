using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
	
	[SerializeField] private Camera cam;
	[SerializeField] private float xRotation = 0; 
	
	[SerializeField] private FloatVariable xSensitivity, ySensitivity;	
	[SerializeField] CameraController cameraController;
	
	private void Start() 
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
	}
	
	private void Update()
	{
		Cursor.visible = false;
	}
	
	public void ProcessLook(Vector2 input, float aimingLookModifer)
	{
		
		if(cameraController.cameraHasTakenOver)
		{
			xRotation = cam.transform.rotation.x;
			return;
		}
		
		
		float lookX = input.x;
		float lookY = input.y;	
	
		xRotation -= (lookY * Time.deltaTime) * (ySensitivity.value * aimingLookModifer);
		xRotation = Mathf.Clamp(xRotation, -60f, 60f);
 		
		cam.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
		
		transform.Rotate(Vector3.up * (lookX * Time.deltaTime) * (xSensitivity.value * aimingLookModifer));
	}
	
	public void SetXRotation(float xRotationOverride)
	{
		xRotation = 0f; 
		xRotation = xRotationOverride;
	}
	
	public void SetLookSensitivity(float xSensitivity, float ySensitivity)
	{
		this.xSensitivity.value = xSensitivity;
		this.ySensitivity.value = ySensitivity;
	}
	


	
}
