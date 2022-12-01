using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public static class FadeMixerGroup
{
	public static IEnumerator StartFade(AudioMixer audioMixer, string exposedParam, float duration, float targetVolume, float delayStart)
	{
		
		yield return new WaitForSeconds(delayStart);
		
		float currentTime = 0;
		float currentVol;
		audioMixer.GetFloat(exposedParam, out currentVol);
		//currentVol = Mathf.Pow(10, currentVol / 20);
		//float targetValue = Mathf.Clamp(targetVolume, 0.0001f, 1);
		while (currentTime < duration)
		{
			currentTime += Time.deltaTime;
			float newVol = Mathf.Lerp(currentVol, targetVolume, currentTime / duration);
			audioMixer.SetFloat(exposedParam, newVol);
			yield return null;
		}
		
		audioMixer.SetFloat(exposedParam, targetVolume);
		
		yield break;
	}
}
