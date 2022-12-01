using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SammysBow : BaseInteractable
{
    [SerializeField] private Transform cameraTarget;

	public override void Awake() 
	{
		base.Awake();
	}
    protected override void Interaction()
	{
		AudioManager.Instance.Play("ThisIsSammys", false);
		//Camera Controller inherited from BaseInteractable
		CameraLookAtInteraction(cameraTarget);
		
	}
    protected override void CameraLookAtInteraction(Transform cameraLookPoint)
	{
		cameraController.LookAtTransform(cameraLookPoint, 2f, true);
	}


}
