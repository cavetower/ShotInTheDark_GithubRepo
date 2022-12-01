using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTutorial : TutorialBaseClass
{
	public bool jumpTutorialComplete;
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

	
	public override void CheckForTutorialCompleteStatus()
	{
		if(jumpTutorialComplete)
		{
			tutorialActive = false;
			thisTutorialComplete = true;
			StartCoroutine(TutorialTextFader(1f,0f, 3f));
		}
	}
	
}
