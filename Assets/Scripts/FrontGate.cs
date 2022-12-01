using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class FrontGate : BaseInteractable
{
	[SerializeField] private Animator anim;
	[SerializeField] private Transform cameraTarget;
	
	[SerializeField] private InputManager inputManager;
	
	[SerializeField] private PlayableDirector gateCutScene;
	
	private PlayerController playerController;
	[SerializeField] private PlayerLook playerLook;
	
	[SerializeField] private Transform playerTransform;
	
	[SerializeField] private Transform buttonTransform;
	
	[SerializeField] private InteractionTutorial interactionTutorial;
	

	public override void Awake() 
	{
		base.Awake();
	}

	protected override void Interaction()
	{
		
		OpenGateCutScene();
	}
	
	
	private void LateUpdate() 
	{
		
	}
	
	protected override void CameraLookAtInteraction(Transform cameraLookPoint)
	{
		cameraController.LookAtTransform(cameraLookPoint, 3f, false);
	}

	private void OpenGateCutScene()
	{
		interactionTutorial.interactedWithButton = true; 
		
		playerController = inputManager.GetPlayerController();
		inputManager.ToggleActionMap(playerController.Interaction);
		
		GameManager.Instance.CutSceneHappening(true);
		
		StartCoroutine(DelayPlayScene());
	}
	
	
	public void GateCutSceneFinished()
	{
		if(playerController != null)
		{
			playerTransform.eulerAngles = new Vector3(0f, 18.39f, 0f);
			inputManager.ToggleActionMap(playerController.Player);
			Destroy(this);	
		}
	}
	
	private IEnumerator DelayPlayScene()
	{
		yield return new WaitForSeconds(.1f);

		gateCutScene.Play();
		playerLook.SetXRotation(-17.572f);
	}
}
