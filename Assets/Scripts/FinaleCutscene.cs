using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Audio;

public class FinaleCutscene : MonoBehaviour
{

	[SerializeField] private PlayableDirector timeLine;
	[SerializeField] private InputManager inputManager;
	
	[SerializeField] private GunshotLight gunshotLight;
	
	
	[SerializeField] private AudioMixer audioMixer;
	
	public bool finalCutsceneTriggered = false;
	
	
	private void Awake()
	{
		StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "Music_Volume", 1f, 0f, 0f));
	}
	

 
	private void OnTriggerEnter(Collider other) 
	{
		//GameManager.Instance.CutSceneHappening(true);
		if (finalCutsceneTriggered==false)
		{
		finalCutsceneTriggered=true;
		
		gunshotLight.SetCanShoot(true);
		
		timeLine.Play();
		StartCoroutine(LockPlayerControls());
		}  
	}
	IEnumerator LockPlayerControls()
		{
			PlayerController playerController = inputManager.GetPlayerController();
			inputManager.ToggleActionMap(playerController.Interaction);

			yield return new WaitForSeconds (9f);

			inputManager.ToggleActionMap(playerController.Player);
		}
}
