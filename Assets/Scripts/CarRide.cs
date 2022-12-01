using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRide : MonoBehaviour, IShootable
{
	private AudioManager audioManager;

	private AudioSource audioSource;

	private Animator anim;
	
	private Rigidbody rb;
	
	//[SerializeField] private CameraController cameraController;
	
	[SerializeField] private InputManager inputManager;
	
	//[SerializeField] private Transform cameraTarget;

	private bool triggered=false;
	
	private void Awake() 
	{
		anim = GetComponent<Animator>();
		audioManager = AudioManager.Instance;
		audioSource = GetComponent<AudioSource>();
	}
	public void ShotReaction()
	{
		
		audioManager.Play("BulletHitMetal", true);

		audioSource.Play();
		
		if(triggered==false)
		{
		triggered=true;
		audioManager.Play("StartTruck", false);
		audioManager.Play("RevTruck", false);
		//PlayerController playerController = inputManager.GetPlayerController();
		//inputManager.ToggleActionMap(playerController.Interaction);
		anim.SetTrigger("CarShot");
		//cameraController.LookAtTransform(cameraTarget, .5f, true);
		}
	
		
	}
}
