using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class NextLevelTrigger : MonoBehaviour
{
	[SerializeField] private Door door;
	
	[SerializeField] private LoadingScreen loadingScreen;
	
	[SerializeField] private GameObject killZone;
	void Start()
	{
		if(door == null)
		{
			Debug.LogWarning("THERE IS NO DOOR ATTACHED TO NEXT LEVEL TRIGGER.");
		}
	}
	
	private void OnTriggerEnter(Collider other) 
	{
		if(other.GetComponent<CharacterController>() != null)
		{
			if(door != null)
			{
				if(door.doorOpened)
				{
					if(killZone != null)
					{
						killZone.SetActive(false);
					}
					loadingScreen.LoadScene();
				}
				else
				{
					Debug.Log("Door is not open yet");
				}
			}
			else
			{
				if(killZone != null)
					{
						killZone.SetActive(false);
					}
				loadingScreen.LoadScene();
			}
		}	
	}
	
	
}
