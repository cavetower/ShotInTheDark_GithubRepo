using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallDeath : MonoBehaviour
{
	private AudioManager audioManager;
	[SerializeField] private SceneReset sceneReset;

	private void Start() 
	{
		audioManager = AudioManager.Instance;
	}
	
	private void OnTriggerEnter(Collider other) 
	{
		if(other.GetComponent<CharacterController>() != null)
		{
			audioManager.Play("FallImpact", true);

			StopAllCoroutines();
			
			if(sceneReset != null)
			{
				sceneReset.OnPlayerDeath();
			}
						
			SceneController.ReloadScene();
		}
	}

}
