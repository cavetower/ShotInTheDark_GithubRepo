using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTutorial : TutorialBaseClass
{
	
	[SerializeField] PlayerMovement playerMovement;
	
	

	public override void CheckForTutorialCompleteStatus()
	{
		//The state needs to complete tutorial.
		if(playerMovement.IsMoving())
		{
			tutorialActive = false;
			thisTutorialComplete = true;
			StartCoroutine(TutorialTextFader(1f,0f, 3f));
		}
	}
	
	
}
