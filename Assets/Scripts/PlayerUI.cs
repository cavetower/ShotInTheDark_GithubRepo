using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
[SerializeField] public TextMeshProUGUI promptText;
[SerializeField] private Image playerUIFadeCanvas;

[SerializeField] private GameObject itemHolder;
[SerializeField] private GameObject bulletCounter;
	
	
	public void DoDisplayPromptText(string text)
	{
		promptText.text = text;
	}
	
	public void ClearPromptText()
	{
		promptText.text = null;
	}
	
	private void Awake() 
	{
		playerUIFadeCanvas.enabled = false;
		promptText.alpha = 0f;
	}
	
	
	public void DoFadeInPlayerUI(float fadeInTime, float delayTime)
	{
		playerUIFadeCanvas.enabled = true;
		StartCoroutine(FadeInPlayerUI(fadeInTime, delayTime));
	}
	
	
	public IEnumerator FadeInPlayerUI(float fadeInTime, float delayTime)
	{	
		yield return new WaitForSeconds(delayTime);
		float time = 0;
		
		while (time < fadeInTime)
		{
			Color fadeColor = playerUIFadeCanvas.color;
			fadeColor.a = Mathf.Lerp(1f, 0f, time / fadeInTime);
			playerUIFadeCanvas.color = fadeColor;
			time += Time.deltaTime;
			yield return null;
		}
		if(!GameManager.firstCutSceneFinished)
		{
			GameManager.Instance.StartMovement();
		}
	}
	
	
	public void EnableRealPlayerUI(bool isEnabled)
	{
		itemHolder.SetActive(isEnabled);
		bulletCounter.SetActive(isEnabled);
	}	
}
