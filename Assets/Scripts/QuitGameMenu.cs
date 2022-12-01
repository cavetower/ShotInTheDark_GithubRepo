using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class QuitGameMenu : MonoBehaviour
{
	
	[SerializeField] private GameObject quitCanvas;
	[SerializeField] private GameObject noButton;
	
	private bool isQuitMenuActive;
	
	
	private void Start() 
	{
		quitCanvas.SetActive(false);	
	}
	
	public void BringUpQuitMenu()
	{
		if(!isQuitMenuActive)
		{
			isQuitMenuActive = true;
			quitCanvas.SetActive(true);
			
			EventSystem.current.SetSelectedGameObject(null);
			EventSystem.current.SetSelectedGameObject(noButton);	
		}
		else
		{
			CloseQuitMenu();
		}
	}
	
	public void CloseQuitMenu()
	{
		isQuitMenuActive = false;
		quitCanvas.SetActive(false);
	}
	
	public void QuitGame()
	{
		Debug.LogWarning("THIS QUIT THE GAME!");
		Application.Quit(); 
	}
	
}
