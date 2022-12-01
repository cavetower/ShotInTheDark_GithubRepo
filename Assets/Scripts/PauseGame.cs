using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseGame : MonoBehaviour
{
	
	private bool gamePaused = false;
	
	[SerializeField] private GameObject pausedFirstButton;
	
	[SerializeField]
	private GameObject pauseUI;
	private SceneReset sceneReset;
	
	[SerializeField] private InputManager inputManager;
	
	[SerializeField] private GameEvent pause;
	
	private void Start() 
	{
		pauseUI.SetActive(false);
		
		sceneReset = FindObjectOfType<SceneReset>();
		
		if(sceneReset == null)
		{
			Debug.LogWarning("NO SCENE RESET IN CURRENT LEVEL");
		}
		 	
	}
	
	
	public void DoPauseGame()
	{
		if(!gamePaused)
		{
			Time.timeScale = 0;
			gamePaused = true;
			pauseUI.SetActive(true);
			
			EventSystem.current.SetSelectedGameObject(null);
			EventSystem.current.SetSelectedGameObject(pausedFirstButton);
				
		}
		else
		{
			Time.timeScale = 1;
			gamePaused = false;
			pauseUI.SetActive(false);
		}
	}
	
	
	public bool GamePausedStatus()
	{
		return gamePaused;
	}
	
	
	public void UnpauseFromPauseMenu()
	{
		pause.Raise();
		inputManager.CheckGamePaused();
	}
	
	
	public void ReloadCurrentLevel()
	{
		if(GameManager.Instance.currentSceneIndex == 0)
		{
			QuitToMainMenu();
			return;
		}
		
		StopAllCoroutines();
		
		// PlayerController playerController = inputManager.GetPlayerController();
		// inputManager.ToggleActionMap(playerController.Player);
		
		UnpauseFromPauseMenu();
			
		if(sceneReset != null)
		{
			sceneReset.OnPlayerDeath();
		}
					
		SceneController.ReloadScene();
	}
	
	public void QuitToMainMenu()
	{
		StopAllCoroutines();
		Destroy(GameManager.Instance);
		Destroy(AudioManager.Instance);
		UnpauseFromPauseMenu();
		SceneController.LoadMenuScene();
	}
	
	
}
