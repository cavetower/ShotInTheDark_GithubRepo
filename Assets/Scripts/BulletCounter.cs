using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BulletCounter : MonoBehaviour
{
	
	private int numberOfBullets;
	
	private int startingBulletAmount = 6;
	
	[SerializeField] private RevolverUI revolverUI;
	

	[SerializeField] private TextMeshProUGUI bulletCount;
	
	private SaveLastShot saveLastShot;
	
	
	private void Start() 
	{
		if(GameManager.Instance.currentSceneIndex == 6)
		{
			saveLastShot = FindObjectOfType<SaveLastShot>();
			
			if(saveLastShot == null)
			{
				Debug.LogWarning("SAVE LAST SHOT NOT ATTACHED TO BULLET COUNTER.");
			}
		}
		
		numberOfBullets = startingBulletAmount;
		
		bulletCount.text = "BULLETS: " + numberOfBullets;	
	}
	
	public void ShotFired()
	{
		numberOfBullets -= 1;
	
		revolverUI.SetBulletsRevolverUI(numberOfBullets);
		
		if(saveLastShot != null)
		{
			saveLastShot.CheckForOneBullet(numberOfBullets);
		}
		
		bulletCount.text = "BULLETS: " + numberOfBullets;	
	}
	
	public bool AreShotsRemaing()
	{
		if(numberOfBullets > 0)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
	
}
