using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunshotTutorial : TutorialBaseClass
{
	[SerializeField] private Light greenDoorLight;
	
	protected bool hasShot = false;
	
	[SerializeField] private CameraController cameraController;
	
	[SerializeField] private Transform cameraLookTarget;
	
	[SerializeField] private AudioSource doorAudio;
	
	[SerializeField] private InputManager inputManager;
	
	[SerializeField] private PlayerMovement playerMovement;
	
	
	
	
	private void Start()
	{
		if(GameManager.gunTutorialFinished)
		{
			greenDoorLight.intensity = 60f;
		}
		else
		{
			greenDoorLight.intensity = 0f;
		}
	}
	
	public override void StartTutorial()
	{
		PlayerController playerController = inputManager.GetPlayerController();
		inputManager.ToggleActionMap(playerController.Interaction);
		StartCoroutine(ShootTutorialTimed());
	}
	public override void CheckForTutorialCompleteStatus()
	{
		if(hasShot)
		{
			if(playerMovement.isGrounded)
			{
				StopAllCoroutines();
				tutorialActive = false;
				thisTutorialComplete = true;
				StartCoroutine(TutorialTextFader(1f,0f, 3f));
				GameManager.Instance.GunTutorialFinishedStatus(true);
				StartCoroutine(GunshotTutorialComplete());	
			}
			
		}
	}
	
	public IEnumerator ShootTutorialTimed()
	{
		yield return new WaitForSeconds(2f);
		AudioManager.Instance.Play("VO_Lighter", false);
		yield return new WaitForSeconds(2f);
		base.StartTutorial();
		PlayerController playerController = inputManager.GetPlayerController();
		inputManager.ToggleActionMap(playerController.Player);
		
	}
	
	public void HasShoot()
	{
		hasShot = true;
	}
	
	public IEnumerator GunshotTutorialComplete()
	{
		PlayerController playerController = inputManager.GetPlayerController();
		inputManager.ToggleActionMap(playerController.Interaction);
		
		yield return new WaitForSeconds(1.5f);
		AudioManager.Instance.Play("VO_WillWork", false);
		
		doorAudio.Play();
		
		yield return new WaitForSeconds(1f);
		
		cameraController.LookAtTransform(cameraLookTarget, 5f, true);
		
		
		float time = 0;
		
		float duration = 3f;
		
		while (time < duration)
		{
			greenDoorLight.intensity = Mathf.Lerp(0f, 60f, time / duration);
			time += Time.deltaTime;
			yield return null;
		}
		
		AudioManager.Instance.Play("VO_GreenDoor", false);

	}

}
