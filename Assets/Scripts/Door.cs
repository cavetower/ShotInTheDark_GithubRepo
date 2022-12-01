using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : BaseInteractable
{
	
	private Animator anim;
	
	[SerializeField] private Transform cameraTarget;
	
	[SerializeField] private bool isDoorLocked;

	private AudioManager audioManager;
	
	public bool doorOpened {get; private set;}


	public override void Awake() 
	{
		base.Awake();
		anim = GetComponent<Animator>();
		doorOpened = false;	
		audioManager = AudioManager.Instance;
	}
	
	protected override void Interaction()
	{
		
		//Camera Controller inherited from BaseInteractable
		CameraLookAtInteraction(cameraTarget);
		
		if(isDoorLocked==true)
		{
			anim.SetTrigger("OpenLockedDoor");
		}
		else
		{
			anim.SetTrigger("OpenDoor");
		}
		
		doorOpened = true;
	}

	protected override void CameraLookAtInteraction(Transform cameraLookPoint)
	{
		cameraController.LookAtTransform(cameraLookPoint, 1.5f, true);
	}

	public void UnlockSound()
	{
		audioManager.Play("Unlock", true);
	}

	public void DoorSound()
	{
		audioManager.Play("DoorOpen", true);
	}
}
