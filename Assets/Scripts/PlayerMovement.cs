using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	
	private CharacterController controller;
	private Vector3 playerVelocity;
	private Vector3 lastDirection;
	
	private InputManager inputManager;
	public bool isGrounded {get; private set;}
	private float gravity = -9.8f;
	
	[SerializeField]
	private float speed = 5f;

	public float jumpHeight = 3f;
	
	[SerializeField] private float airFriction = .15f;
	
	private bool isMoving;
	
	void Start()
	{
		controller = GetComponent<CharacterController>();
		inputManager = GetComponent<InputManager>();
		
		isGrounded = true;
	}
	
	void Update()
	{
		isGrounded = controller.isGrounded;
		
	}
	
	public void ProcessMove(Vector2 input, float aimingWalkModifier)
	{
		
		Vector3 moveDirection = Vector3.zero;
		
		moveDirection.x = input.x;
		moveDirection.z = input.y;
		
		if(isGrounded)
		{
			controller.slopeLimit = 45f;
			lastDirection.z = moveDirection.z;
		}
		else
		{
			moveDirection.z = (lastDirection.z * .8f) + (input.y * airFriction);
			moveDirection.x = moveDirection.x * .4f;
			controller.slopeLimit = 90f;
		}
	
		controller.Move(transform.TransformDirection(moveDirection) * (speed * aimingWalkModifier) * Time.deltaTime);
		playerVelocity.y += gravity * Time.deltaTime;
		
		if(isGrounded && playerVelocity.y < 0)
		{
			playerVelocity.y = -2f; 
		}
		
		controller.Move(playerVelocity * Time.deltaTime);
		
		//run check to see if character is moving.
		CheckMoving(moveDirection);
	}
	
	public void Jump()
	{
		if(isGrounded && !inputManager.IsAimingCheck())
		{
			
			playerVelocity.y = Mathf.Sqrt(jumpHeight * -3f * gravity);
			StartCoroutine(PlayJumpLandingSound());
		}
	}
	
	private void CheckMoving(Vector3 movement)
	{
		float minSpeedCheck = 0.1f;
		
		if(Mathf.Abs(movement.x) > minSpeedCheck || Mathf.Abs(movement.z) > minSpeedCheck)
		{
			isMoving = true;
		}
		else
		{
			isMoving = false;
		}
	}
	
	public bool IsMoving()
	{
		return isMoving;
	}
	
	
	public IEnumerator PlayJumpLandingSound()
	{
		
		yield return new WaitForSeconds(.1f);
		

	}
}
