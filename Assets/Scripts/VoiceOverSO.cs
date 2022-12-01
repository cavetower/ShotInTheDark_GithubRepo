using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/VoiceOver")]
public class VoiceOverSO : ScriptableObject
{
	public bool hasPlayedYet;
	
	
	//Resets only on initial load.
	private void OnEnable() 
	{
		hasPlayedYet = false;	
	}
	
}
