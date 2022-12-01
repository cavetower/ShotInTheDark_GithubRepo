using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGameAfterCredits : MonoBehaviour
{
	private bool sceneCurrentlyLoading;
	
	[SerializeField] private GameObject loadingScreen;
	
	
	
	public void LoadScene()
	{
		int sceneID = 0;
		
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
