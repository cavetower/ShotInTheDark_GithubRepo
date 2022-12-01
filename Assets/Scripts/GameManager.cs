using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

public class GameManager : MonoBehaviour
{
	
	private AudioManager audioManager;
	
	public static GameManager Instance {get; private set;}
	
	public bool cutsceneHappening { get; private set;}
	
	private SceneReset sceneReset;
	
	public int currentSceneIndex {get; private set;}
	
	private PlayerUI playerUI;
	
	private InputManager inputManager;
	
	public static bool firstCutSceneFinished {get; private set;}
	
	public static bool gunTutorialFinished {get; private set;}
	
	public GroundType groundType {get; private set;}
	[SerializeField] private AudioMixer audioMixer; 
	
	private void Awake() 
	{
		if(Instance != null && Instance != this)
		{
			Destroy(this);
		}
		else
		{
			Instance = this;
		}
	}
	
	private void Start() 
	{
		
		if(audioManager == null)
		{
			audioManager = FindObjectOfType<AudioManager>();
		}
		
		if(audioMixer == null)
		{
			audioMixer = FindObjectOfType<AudioMixer>();
		}
		
						
		if(playerUI == null)
		{
			playerUI = FindObjectOfType<PlayerUI>();
		}	
		
		sceneReset = FindObjectOfType<SceneReset>();
		
		if(sceneReset != null)
		{
			sceneReset.ResetScene();
		}
		else
		{
			Debug.LogWarning("THERE IS NO SCENE RESET IN THE SCENE");
		}		
		
		SetCurrentSceneIndex();
	}
	
	public void CutSceneHappening(bool isCutsceneHappening)
	{
		cutsceneHappening = isCutsceneHappening;
	}
	
	
	public void SetCurrentSceneIndex()
	{
		currentSceneIndex = SceneController.GetCurrentScene();
		
		switch(currentSceneIndex)
		{
			case 0:
				SetUpMainMenu();
				groundType = GroundType.Dirt;
				break;
			case 1:
				StartLevelOne();
				groundType = GroundType.Carpet;
				break;
			case 2:
				StartLevelOneAlt();
				groundType = GroundType.Carpet;
				break;	
			case 3:
				StartLevelTwo();
				groundType = GroundType.Carpet;
				break;	
			case 4:
				StartLevelThree();
				groundType = GroundType.Carpet;
				break;	
			case 5:
				StartLevelFour();
				groundType = GroundType.Stone;
				break;		
			case 6:
				StartLevelFive();
				groundType = GroundType.Wood;
				break;	
								
		}
		
	}
	
	
	
	
	//Called when player hits start from menu.
	public void StartNewGame()
	{
		PlayerController playerController = inputManager.GetPlayerController();
		inputManager.ToggleActionMap(playerController.Interaction);
		StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "Music_Volume", 5f, -10f, 0f));
		audioManager.Play("StartButton", false);
		playerUI.DoFadeInPlayerUI(10f, 12f);
		StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "AmbientSound_Volume", 5f, 10f, 8f));
		audioManager.Play("VO_OpeningAudio", false);
		
	}
	
	
	
	
	public void SetUpMainMenu()
	{
		playerUI.EnableRealPlayerUI(false);
		
		if(inputManager == null)
		{
			inputManager = FindObjectOfType<InputManager>();
		}
		
		PlayerController playerController = inputManager.GetPlayerController();
		inputManager.ToggleActionMap(playerController.MenuScreen);
	
		firstCutSceneFinished = false;
		
	}
	
	public void StartLevelOne()
	{
		playerUI.EnableRealPlayerUI(false);
		AudioManager.Instance.Play("VO_Dump", false);
	}
	
	
	public void StartLevelOneAlt()
	{
		playerUI.EnableRealPlayerUI(true);
		playerUI.DoFadeInPlayerUI(5f, 0f);
		
		if(gunTutorialFinished)
		{
			return;
		}
		else
		{
			FindObjectOfType<GunshotTutorial>().StartTutorial();	
		}
	}
	
	public void StartLevelTwo()
	{
		playerUI.EnableRealPlayerUI(true);
		playerUI.DoFadeInPlayerUI(5f, 0f);
	}
	
	public void StartLevelThree()
	{
		playerUI.EnableRealPlayerUI(true);
		playerUI.DoFadeInPlayerUI(5f, 0f);
	}
	
	public void StartLevelFour()
	{
		playerUI.EnableRealPlayerUI(true);
		playerUI.DoFadeInPlayerUI(5f, 0f);
	}
	
	public void StartLevelFive()
	{
		playerUI.EnableRealPlayerUI(true);
		playerUI.DoFadeInPlayerUI(5f, 0f);
		
	}
	
	
	
	public void ForceLoadNextScene()
	{
		SceneController.NextScene();
	}
	
	
	//Allows movement after initial cutscene.
	public void StartMovement()
	{
		if(inputManager != null)
		{
			PlayerController playerController = inputManager.GetPlayerController();
			inputManager.ToggleActionMap(playerController.Player);
		}
		
		if(currentSceneIndex == 0)
		{
			FindObjectOfType<MoveTutorial>().StartTutorial();
		}
		
		firstCutSceneFinished = true;	
		
		
	}
	
	
	
	public void ChangeGroundType(GroundType groundTypeToChangeTo)
	{
		this.groundType = groundTypeToChangeTo;
		
		var footsteps = FindObjectOfType<Footsteps>();
		if(footsteps != null)
		{
			footsteps.SetFootstepGroundType();
		}
	}
	

	
	public void GunTutorialFinishedStatus(bool isFinished)
	{
		gunTutorialFinished = isFinished;
	}
	
	
	public enum GroundType
	{
		Dirt,
		Carpet,
		Wood,
		Stone
	};
	

	
}
