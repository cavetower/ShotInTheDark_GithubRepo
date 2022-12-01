using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	[SerializeField] float zoomCamFOV = 45;
	[SerializeField] float defaultCamFOV = 60;
	[SerializeField] float smooth = 5;
	[SerializeField] bool sights = false;
	
	private Camera cam;
	
	private Quaternion rotationGoal;
	
	private Vector3 lookDirection;
	
	public bool cameraHasTakenOver {get; private set;}

	[SerializeField] private Transform playerTransform;
	[SerializeField] private PlayerLook playerLook;
	
	[SerializeField] private PlayerInteractor playerInteractor;
	
	private bool isCameraDoneLooking;
	
	float startingPlayerYRotation;
	float startingCamXRotation;
	float differencePlayerRotation;
	float differenceCamRotation;
	
	
	private void Awake()
	{
		cam = GetComponent<Camera>();
		cameraHasTakenOver = false;
	}

	void Update() 
	{
		if(sights == true)
			{
				cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoomCamFOV, Time.deltaTime * smooth);
			}
		else
			{
				cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, defaultCamFOV, Time.deltaTime * smooth);
			}	
	}

	public void CameraZoom()
	{
		sights = true;
	}
	public void CameraReturn()
	{
		sights = false;
	}
	
	public void LookAtTransform(Transform target, float timeToLook, bool automaticallyEnd)
	{
		isCameraDoneLooking = false;
		
		cameraHasTakenOver = true;
		
		startingCamXRotation = cam.transform.eulerAngles.x;
		
		lookDirection = (target.position - cam.transform.position).normalized;
		rotationGoal = Quaternion.LookRotation(lookDirection);
		StartCoroutine(DoLookCamera(rotationGoal, false, timeToLook, automaticallyEnd));
	}
	
	private IEnumerator DoLookCamera(Quaternion rotationGoal, bool isReturn, float timeToLook, bool automaticallyEnd)
	{
		float time = 0;
		float rotationSpeed = 0.03f;
		
		startingPlayerYRotation = playerTransform.eulerAngles.y;
		
		while (time < timeToLook)
		{
			cam.transform.rotation = Quaternion.Slerp(cam.transform.rotation, rotationGoal, rotationSpeed);
			time += Time.deltaTime;
			
			yield return null;
		}
		
		yield return new WaitForSeconds(.1f); 
		
		//Sets player Y transform to the correct spot.
		differencePlayerRotation = startingPlayerYRotation - (startingPlayerYRotation - cam.transform.eulerAngles.y);
		
		differenceCamRotation = startingCamXRotation - (startingCamXRotation - cam.transform.eulerAngles.x);		
		
		differencePlayerRotation = rotationGoal.eulerAngles.y;
		

		playerLook.SetXRotation(differenceCamRotation);
		
		isCameraDoneLooking = true;
	
		
		if(automaticallyEnd)
		{
			playerInteractor.EndInteraction();
		}
	
	}
	
	public void RegainCameraControl()
	{	
		playerTransform.eulerAngles = new Vector3(0f, differencePlayerRotation, 0f);
		cameraHasTakenOver = false;
	}
	
	public bool CheckIsCameraDoneLooking()
	{
		return isCameraDoneLooking;
	}
	
}

