using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenPianoHandler : MonoBehaviour
{
	[SerializeField] private CutSceneSO topTableCutscene;
	
	[SerializeField] private GameObject piano;
	[SerializeField] private GameObject brokenPiano;
	
	
	private void Start() 
	{
		if(!topTableCutscene.hasScenePlayedYet)
		{
			piano.SetActive(true);
			brokenPiano.SetActive(false);
		}
		else
		{
			piano.SetActive(false);
			brokenPiano.SetActive(true);
		}	
	}
	
	
	
	
}
