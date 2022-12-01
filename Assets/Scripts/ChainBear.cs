using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainBear : MonoBehaviour, IShootable

{
	private AudioManager audioManager;

	private Animator anim;
	
	private Rigidbody rb;

	private bool beenShot=false;
	
	[SerializeField] private CameraController cameraController;
	
	[SerializeField] private InputManager inputManager;
	
	[SerializeField] private Transform cameraTarget;

	//[SerializeField] private ParticleSystem particleSystem;
	
	private void Awake() 
	{
		anim = GetComponent<Animator>();
		audioManager = AudioManager.Instance;
		//particleSystem = GetComponent<ParticleSystem>();
	}



	public void ShotReaction()
	{
		audioManager.Play("BulletHitMetal", true);

		if(beenShot==false)
		{
		beenShot=true;
		PlayerController playerController = inputManager.GetPlayerController();
		inputManager.ToggleActionMap(playerController.Interaction);
		
		cameraController.LookAtTransform(cameraTarget, 2f, true);
	
		anim.SetTrigger("ChainShot");
		//particleSystem.Play();
		}
	}
	public void BearShotSound()
	{
		audioManager.Play("BearTumble", false);
		audioManager.Play("BearCrack", false);
	}

	public void BearImpactSound()
	{
		audioManager.Play("BearImpact", false);
	}

	public void PramRollSound()
	{
		audioManager.Play("PramRoll", false);
	}
	
}
