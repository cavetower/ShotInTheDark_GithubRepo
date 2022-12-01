using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoiceSounds : MonoBehaviour
{
	
	private AudioManager audioManager;
	private PlayerMovement playerMovement;
	
	private void Awake() 
	{
		playerMovement = GetComponent<PlayerMovement>();
	}
	
	private void Start() 
	{
		audioManager = AudioManager.Instance;
	}
	
	
	
	public void PlayJumpSound()
	{
		int jumpIndex = Random.Range(1, 7);
		
		audioManager.Play("Jump" + jumpIndex, false);
		

	}

}
