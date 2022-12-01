using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
	
	private AudioManager audioManager;
	private PlayerMovement playerMovement;
	
	private string groundTypeName;
	
	private void Awake() 
	{
		playerMovement = GetComponent<PlayerMovement>();
		
	}
	
	private void Start()
	{
		audioManager = AudioManager.Instance;
		
		SetFootstepGroundType();
		
	}
	
	
	
	public void PlayFootstepSound()
	{
		int footstepIndex = Random.Range(1, 6);
		
		if(playerMovement.isGrounded)
		{
			audioManager.Play(groundTypeName + "_Footstep" + footstepIndex, true);
		}

	}
	
	
	public void SetFootstepGroundType()
	{
		groundTypeName = GameManager.Instance.groundType.ToString();
	}

}
