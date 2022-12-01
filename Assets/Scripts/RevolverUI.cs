using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RevolverUI : MonoBehaviour
{
		
	private int bulletsLeft;
	
	[SerializeField] private GameObject [] bulletIcons;
	
	
	private void Start() 
	{
		foreach(GameObject bulletIcon in bulletIcons)
		{
			bulletIcon.SetActive(true);
		}	
	}
	
	public void SetBulletsRevolverUI(int numberOfBulletsRemaining)
	{
		if(bulletsLeft != numberOfBulletsRemaining)
		{
			bulletsLeft = numberOfBulletsRemaining;
			
			bulletIcons[bulletsLeft].SetActive(false);
		}
		
	}
}
