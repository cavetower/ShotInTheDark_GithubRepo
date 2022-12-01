using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Collider))]
public class FallSounds : MonoBehaviour
{
	[SerializeField] Sound [] fallSounds;
	bool isScreaming=false;
	
	
	private void Awake()
	{
		foreach(Sound s in fallSounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.outputAudioMixerGroup = s.audioMixerGroup;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;
		}
	}
	
	private void OnTriggerEnter(Collider other) 
	{
		if(other.GetComponent<CharacterController>() != null && isScreaming==false)
		{
			isScreaming=true;
			int soundToPlay = Random.Range(0, fallSounds.Length);
			
			fallSounds[soundToPlay].source.Play();

		}
	}
}
