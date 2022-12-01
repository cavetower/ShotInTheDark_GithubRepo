 using System.Collections;
 using System.Collections.Generic;
 using UnityEngine;
 using UnityEngine.SceneManagement;

 public static class SceneController
 {
	public static void LoadMenuScene() 
	{
		SceneManager.LoadScene(0);
	}

	public static void NextScene() 
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public static void ReloadScene() 
	{
		
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);	

	}
	
	public static int GetCurrentScene()
	{
		return SceneManager.GetActiveScene().buildIndex;
	}
}