using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class FadeMusic : MonoBehaviour
{

	[SerializeField] private AudioMixer audioMixer;
	[SerializeField] private string mixerToFade;
	
	[SerializeField] private float duration, targetVolume, delayStart;



	public void FadeMusicMixer()
	{
		StartCoroutine(FadeMixerGroup.StartFade(audioMixer, mixerToFade, duration, targetVolume, delayStart));
	}

}
