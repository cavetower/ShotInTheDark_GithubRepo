using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class OneShotVoiceOver : MonoBehaviour
{
	[SerializeField] private string audioToPlayName;
	
	[SerializeField] private VoiceOverSO thisVoiceOver;
	
	private void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.TryGetComponent(out CharacterController characterController))
		{
			if(!thisVoiceOver.hasPlayedYet)
			{
				AudioManager.Instance.Play(audioToPlayName, false);
				thisVoiceOver.hasPlayedYet = true;
			}
		}
	}
	
	
	
}
