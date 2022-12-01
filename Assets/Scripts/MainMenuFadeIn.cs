using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuFadeIn : MonoBehaviour
{
	[SerializeField] private Image fadeCanvas; 
	
	private Color fadeSet;
	
	
	private void Awake() 
	{
		fadeSet.a = 1f;
		fadeCanvas.color = fadeSet;
	}
	
	private void OnEnable() 
	{
		StartCoroutine(FadeInMainMenu(3f, .5f));
	}
	
	
	
	public IEnumerator FadeInMainMenu(float fadeInTime, float delayTime)
	{	
		yield return new WaitForSeconds(delayTime);
		float time = 0;
		
		while (time < fadeInTime)
		{
			Color fadeColor = fadeCanvas.color;
			fadeColor.a = Mathf.Lerp(1f, 0f, time / fadeInTime);
			fadeCanvas.color = fadeColor;
			time += Time.deltaTime;
			yield return null;
		}
	}
	
}
