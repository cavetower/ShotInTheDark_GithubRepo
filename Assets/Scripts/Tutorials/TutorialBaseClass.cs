using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public  abstract class TutorialBaseClass : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI tutorialTextDisplay;
	
	[field: TextArea]
	[SerializeField] private string keyboardtTutorialText;
	[field: TextArea]
	[SerializeField] private string controllerTutorialText;
	
	protected bool thisTutorialComplete = false;
	protected bool tutorialActive = false;
	
	
	
	private void Update()
	{
		if(tutorialActive)
		{
			CheckForTutorialCompleteStatus();
		}
	}
		

	public virtual void StartTutorial()
	{
		if(!thisTutorialComplete)
		{
			
			tutorialTextDisplay.alpha = 0f;

			if(ControllerType.isUsingKeyboard)
			{
				tutorialTextDisplay.text = keyboardtTutorialText;	
			}
			else
			{
				tutorialTextDisplay.text = controllerTutorialText;
			}
			
			StartCoroutine(TutorialTextFader(0f, 1f, 2f));
			tutorialActive = true;
			
			
		}
		else
		{
			Debug.Log("Tutorial is complete.");
		}
	}
	
	protected IEnumerator TutorialTextFader(float startAlpha, float endAlpha, float fadeTime)
	{
		float time = 0f;
		
		float fadeInTime = fadeTime;
		
		while (time < fadeInTime)
		{
			tutorialTextDisplay.alpha = Mathf.Lerp(startAlpha, endAlpha, time / fadeInTime);
			time += Time.deltaTime;
			yield return null;
		}
		
		tutorialTextDisplay.alpha = endAlpha;
		
	}
	
	public abstract void CheckForTutorialCompleteStatus();
	
	
}
