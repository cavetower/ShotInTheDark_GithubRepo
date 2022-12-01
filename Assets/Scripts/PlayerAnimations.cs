using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
	private Animator anim;
	
	private PlayerMovement playerMovement;
	
	private CharacterController controller;
	
	private InputManager inputManager;
	
	private bool isAiming = false;
	
	[SerializeField]
	private BulletCounter bulletCounter;
	
	[SerializeField]
	private GunshotLight gunshotLight;
	
	private void Awake() 
	{
		anim = GetComponent<Animator>();	
		playerMovement = GetComponent<PlayerMovement>();
		controller = GetComponent<CharacterController>();
		inputManager = GetComponent<InputManager>();
	}
	
	private void Update() 
	{
		IsMovingAnimation();
	}
	
	
	public void PressedAim()
	{
		if(!isAiming)
		{
			anim.SetBool("IsAiming", true);	
			isAiming = true;
		}
	}
	
	public void ReleaseAim()
	{
		if(isAiming)
		{
			anim.SetBool("IsAiming", false);
			isAiming = false;
		}
	}
	
	public void ShotFiredAnimation()
	{
		if(isAiming)
		{
			anim.SetTrigger("AimShotFired");
		}
		else
		{
			anim.SetTrigger("IdleShotFired");
		}
	}
	
	private void IsMovingAnimation()
	{
		if(playerMovement.IsMoving())
		{
			anim.SetBool("IsMoving", true);
		}
		else
		{
			anim.SetBool("IsMoving", false);
		}
	}
	
	public void IsJumpingAnimation()
	{
		if(controller.isGrounded && !inputManager.IsAimingCheck())
		{
			anim.SetTrigger("Jump");
		}
	}
	

}
