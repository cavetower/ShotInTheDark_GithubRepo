using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
	public GameObject loadingScreen;
	
	private bool sceneCurrentlyLoading;
	
	private void Awake() 
	{
		loadingScreen.SetActive(false);	
	}
	
	public void LoadScene()
	{
		int sceneID = (SceneController.GetCurrentScene() + 1);
		
		if(!sceneCurrentlyLoading)
		{
			StartCoroutine(LoadSceneAsync(sceneID));	
		}
	}
	
	
	
	IEnumerator LoadSceneAsync(int sceneID)
	{
		sceneCurrentlyLoading = true;
		
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
		
		loadingScreen.SetActive(true);
		
		while(!operation.isDone)
		{
			
			yield return null;		
		}
	}
	
	
	
	
	
}
