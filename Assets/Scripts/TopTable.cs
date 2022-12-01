using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TopTable : MonoBehaviour
{
	bool playerOnTopTable = false;
	
	[SerializeField] private Transform cameraTarget;
	[SerializeField] private PlayableDirector timeLine;
	[SerializeField] private BulletCounter bulletCounter;
	[SerializeField] private InputManager inputManager;
	[SerializeField] private CameraController cameraController;
	
	[SerializeField] private CutSceneSO tableTopCutScene;
	
	[SerializeField] private Animator animator;
	
	private void OnTriggerStay(Collider other) 
	{
		if(other.gameObject.TryGetComponent(out CharacterController characterController))
		{
			playerOnTopTable = true;
		}
	}
	
	private void OnTriggerExit(Collider other) 
	{
		playerOnTopTable = false;	
	}
	
	
	//Triggered by the shoot event.
	public void TopTableCutScene()
	{
		if(tableTopCutScene.hasScenePlayedYet)
		{
			Destroy(this);
			return;
		}
		
		if(playerOnTopTable && bulletCounter.AreShotsRemaing())
		{	
			if(inputManager.IsAimingCheck())
			{
				AudioManager.Instance.Play("Gunshot", false);
			}	
				
			PlayerController playerController = inputManager.GetPlayerController();
			inputManager.ToggleActionMap(playerController.Interaction);


			//Where to look plugged into the camera target variable.
			cameraController.LookAtTransform(cameraTarget, 2f, true);
			
			
			//Call method or write logic here.
			
			timeLine.Play();
			
			tableTopCutScene.hasScenePlayedYet = true;
			StartCoroutine(ResetShootAnimation());
		}
	}
	
	private IEnumerator ResetShootAnimation()
	{
		yield return new WaitForSeconds(2f);
		animator.ResetTrigger("AimShotFired");
	}	
	
}
