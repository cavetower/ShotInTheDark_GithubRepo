using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTutorial : TutorialBaseClass
{
	
	public bool interactedWithButton;
	
	[SerializeField] private VoiceOverSO gateStuck;
	
	private void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.TryGetComponent(out CharacterController characterController))
		{
			if(!tutorialActive)
			{
				StartTutorial();		
			}
		}
	}
	
	// private void OnTriggerExit(Collider other) 
	// {
	// 	if(other.gameObject.TryGetComponent(out CharacterController characterController))
	// 	{
	// 		if(tutorialActive)
	// 		{
	// 			StartCoroutine(TutorialTextFader(1f,0f, 1f));		
	// 		}
	// 	}
	// }

	public override void CheckForTutorialCompleteStatus()
	{
		if(interactedWithButton)
		{
			StopAllCoroutines();
			//Stop OneShotVoiceOver from playing.
			gateStuck.hasPlayedYet = true;
			
			tutorialActive = false;
			thisTutorialComplete = true;
			StartCoroutine(TutorialTextFader(1f,0f, .1f));
		}
	}
}
