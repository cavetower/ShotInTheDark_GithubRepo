using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
	private PlayerController playerController;
	
	private PlayerInput playerInput;
	private InputAction move;
	private InputAction look;
	private PlayerMovement playerMovement;
	private PlayerLook playerLook;
	
	[SerializeField]
	private float aimWalkSpeed = 0.4f;
	
	[SerializeField]
	private float aimShootSpeed = 0.6f;
	
	[SerializeField] private CameraController cameraController;
	
	
	[SerializeField] private PauseGame pauseGame;
	[SerializeField] private GameEvent shoot;
	[SerializeField] private GameEvent pause;
	[SerializeField] private GameEvent aim;
	[SerializeField] private GameEvent stopAim;
	[SerializeField] private GameEvent jump;
	[SerializeField] private GameEvent interact;
	[SerializeField] private GameEvent cancelInteraction;
	[SerializeField] private GameEvent startGame; 
	[SerializeField] private GameEvent quitGame;
	
	
	private void Awake() 
	{
		playerController = new PlayerController();	
		playerMovement = GetComponent<PlayerMovement>();
		playerLook = GetComponent<PlayerLook>();
		
		
	}
	
	private void FixedUpdate() 
	{
		if(!IsAimingCheck())
		{
			playerMovement.ProcessMove(move.ReadValue<Vector2>(), 1f);			
		}
		else
		{
			playerMovement.ProcessMove(move.ReadValue<Vector2>(), aimWalkSpeed);
		}
	}
	
	private void LateUpdate() 
	{
		
		if(cameraController.cameraHasTakenOver || GameManager.Instance.cutsceneHappening)
		{
			return;
		}
		
		if(!IsAimingCheck())
		{
			playerLook.ProcessLook(look.ReadValue<Vector2>(), 1f);	
			
		}
		else
		{
			playerLook.ProcessLook(look.ReadValue<Vector2>(), aimShootSpeed);	
		}
	}
	
	private void OnEnable() 
	{
		move = playerController.Player.Move;
		move.Enable();
		
		look = playerController.Player.Look;
		look.Enable();
		
		playerController.Player.Jump.performed += DoJump;
		playerController.Player.Jump.Enable();
		
		playerController.Player.Aim.performed += DoAim;
		playerController.Player.Aim.canceled += StopAim;
		playerController.Player.Aim.Enable();
		
		playerController.Player.Shoot.performed += DoShoot;
		playerController.Player.Shoot.Enable();
		
		playerController.Player.Pause.started += DoPause;
		playerController.Player.Pause.Enable();
		
		playerController.PauseScreen.Pause.started += DoPause;
		//playerController.PauseScreen.Pause.Enable();
		
		playerController.Player.Interact.performed += DoInteract;
		playerController.Player.Interact.Enable();
		
		
		playerController.PauseScreen.Select.performed += DoPauseScreenSelect;
		playerController.PauseScreen.Select.Enable();
		
		playerController.Interaction.Cancel.performed += DoCancelInteraction;
		playerController.Interaction.Cancel.Enable();
		
		playerController.MenuScreen.StartGame.performed += DoStartGame;
		playerController.MenuScreen.StartGame.Enable();		
		
		playerController.MenuScreen.Quit.performed += DoQuitGame;
		playerController.MenuScreen.Quit.Enable();	
		
		playerController.PauseScreen.Disable();
		playerController.Interaction.Disable();
		playerController.MenuScreen.Disable();
		
	}
	
	private void OnDisable() 
	{
		move.Disable();
		
		playerController.Player.Jump.Disable();
		playerController.Player.Aim.Disable();
		playerController.Player.Shoot.Disable();
		playerController.Player.Pause.Disable();
		playerController.PauseScreen.Pause.Disable();
		playerController.Player.Interact.Disable();
		playerController.PauseScreen.Select.Disable();
		playerController.Interaction.Cancel.Disable();
		playerController.MenuScreen.StartGame.Disable();
		playerController.MenuScreen.Quit.Disable();
		
	}
	
	public Vector2 GetPlayerMovement()
	{
		return move.ReadValue<Vector2>();
	}
	
	public Vector2 GetPlayerLook()
	{
		return playerController.Player.Look.ReadValue<Vector2>();
	}
	
	private void DoJump(InputAction.CallbackContext obj)
	{
		jump.Raise();
		playerMovement.Jump();
	}
	
	private void DoAim(InputAction.CallbackContext obj)
	{
		aim.Raise();
	}
	
	private void StopAim(InputAction.CallbackContext obj)
	{
		stopAim.Raise();
	}
	
	private void DoShoot(InputAction.CallbackContext obj)
	{
		shoot.Raise();	
		
		//Gamepad.current.SetMotorSpeeds(0.2f, 0.2f);
	}
	
	private void DoPause(InputAction.CallbackContext obj)
	{
		pause.Raise();
		CheckGamePaused();
	}
	
	private void DoInteract(InputAction.CallbackContext obj)
	{
		interact.Raise();
	}
	
	private void DoPauseScreenSelect(InputAction.CallbackContext obj)
	{
		Debug.Log("Pause Screen Select");
	}
	
	private void DoCancelInteraction(InputAction.CallbackContext obj)
	{
		cancelInteraction.Raise();
	}
	
	private void DoStartGame(InputAction.CallbackContext obj)
	{
		CheckInputType();
		startGame.Raise();
	}
	
	private void DoQuitGame(InputAction.CallbackContext obj)
	{
		quitGame.Raise();
	}
	
	
	public void CheckGamePaused()
	{
		if(pauseGame.GamePausedStatus())
		{
			ToggleActionMap(playerController.PauseScreen);
		}
		else
		{
			ToggleActionMap(playerController.Player);
		}
	}
	
	public bool IsAimingCheck()
	{
		if(playerController.Player.Aim.IsPressed())
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
	public void ToggleActionMap(InputActionMap actionMap)
	{
		if(actionMap.enabled)
		{
			return;	
		}
		
		playerController.Disable();
		actionMap.Enable();
	}
	
	public PlayerController GetPlayerController()
	{
		return playerController;
	}
	

	private void CheckInputType()
	{	
		if(Gamepad.current != null && Gamepad.current.startButton.wasPressedThisFrame)
		{
			ControllerType.SetControllerTypeToKeyboard(false);
			Debug.Log("Gampad used to press start");
			playerLook.SetLookSensitivity(100f, 100f);
		}
		else if(Keyboard.current.enterKey.wasPressedThisFrame)
		{
			ControllerType.SetControllerTypeToKeyboard(true);
			Debug.Log("Keyboard used to press start");
			playerLook.SetLookSensitivity(30f, 30f);
		}
		else
		{
			Debug.LogError("NO CONTROLLER WAS ASSIGNED. DEFAULTING TO KEYBOARD.");
			ControllerType.SetControllerTypeToKeyboard(true);
		}
		
		
	}	
}
