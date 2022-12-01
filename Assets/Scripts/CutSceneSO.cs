using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Scriptable Objects/CutScene")]
public class CutSceneSO : ScriptableObject
{
	public bool hasScenePlayedYet;
	
	
	//Resets only on initial load.
	private void OnEnable() 
	{
		hasScenePlayedYet = false;	
	}
	
}
