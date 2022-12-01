using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLastShot : MonoBehaviour
{
	[SerializeField] private BulletCounter bulletCounter;
	[SerializeField] private GunshotLight gunshotLight;
	
	[SerializeField] private FinaleCutscene finaleCutscene;
	
	public bool oneShotLeft = false;
	private bool activateVoiceOver = false;
	
	
	public void CheckForOneBullet(int numberOfBullets)
	{
		if(numberOfBullets == 1 && !finaleCutscene.finalCutsceneTriggered)
		{
			oneShotLeft = true;
			return;
		}
	}
	
	public void VoiceOverSaveLastShot()
	{
		if(oneShotLeft && !activateVoiceOver)
		{
			activateVoiceOver = true;
			return;
		}
		
		if(activateVoiceOver && !gunshotLight.canShoot)
		{
			AudioManager.Instance.Play("VO_KeepLastShot", false);
		}
	}
		
}
