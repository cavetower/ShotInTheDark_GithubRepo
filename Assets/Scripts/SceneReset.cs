using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneReset : MonoBehaviour
{
	[SerializeField] private Light lighterLight;
	[SerializeField] private Light ambientPlayerLight;
	[SerializeField] private ParticleSystem lighterFlame;
	public void ResetScene()
	{
		StartCoroutine(TurnOnLight());
	}
	
	private IEnumerator TurnOnLight()
	{
		lighterFlame.Play();
		yield return new WaitForSeconds(.5f);
		AudioManager.Instance.Play("Lighter", false);
		
		float time = 0;
		
		float duration = 3f;
		
		while (time < duration)
		{
			lighterLight.intensity = Mathf.Lerp(0f, 0.2f, time / duration);
			ambientPlayerLight.intensity = Mathf.Lerp(0f, 0.1f, time / duration);
			time += Time.deltaTime;
			yield return null;
		}
		
	}
	
	public void OnPlayerDeath()
	{
		lighterFlame.Stop();
		ambientPlayerLight.intensity = 0f;
		lighterLight.intensity = 0f;
	}
   
   
}
