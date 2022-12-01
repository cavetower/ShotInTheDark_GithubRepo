using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunshotLight : MonoBehaviour
{
	[SerializeField]
	private Light gunshotLight;
	
	[SerializeField]
	private Light fadeLight;
	
	[SerializeField]
	private float blastBrightness = 500f;
	
	[SerializeField]
	private float fadeFromValue = 100f;
	
	[SerializeField] 
	private float fadeFromTime = 2f;
	
	[SerializeField]
	private float shootDelayAmount = 1.15f;
	
	[SerializeField]
	private ParticleSystem muzzleFlash;
	
	public bool canShoot {get; private set;}

	
	[SerializeField]
	private BulletCounter bulletCounter;
	
	[SerializeField] private PlayerAnimations playerAnimations;
	
	private SaveLastShot saveLastShot;

	private void Awake() 
	{
		canShoot = true;	
	}
	
	
	private void Start()
	{
		if(GameManager.Instance.currentSceneIndex == 6)
		{
			saveLastShot = FindObjectOfType<SaveLastShot>();
			if(saveLastShot == null)
			{
				Debug.LogWarning("SAVE LAST SHOT NOT ATTACHED TO GUNSHOT LIGHT.");
			}
		}
	}
	
	public void LightUpScene()
	{
		if(canShoot && bulletCounter.AreShotsRemaing())
		{
			
			playerAnimations.ShotFiredAnimation();
			
			muzzleFlash.Play(true);
			gunshotLight.intensity = blastBrightness;
			bulletCounter.ShotFired();
			
			StartCoroutine(ShootDelay());
			StartCoroutine(FadeLight(fadeFromTime));
		}
		else
		{
			if(!bulletCounter.AreShotsRemaing())
			{
				Debug.Log("OUT OF BULLETS!");
			}
			else
			{
				Debug.Log("CAN'T SHOOT YET!");
			}
		}
	}
	
	IEnumerator ShootDelay()
	{
		yield return new WaitForSeconds(.1f);
		canShoot = false;
		yield return new WaitForSeconds (shootDelayAmount);
		canShoot = true;
		
		if(saveLastShot != null)
		{
			if(saveLastShot.oneShotLeft)
			{
				canShoot = false;
			}
		}
	}
	
	IEnumerator FadeLight(float duration)
	{
		yield return new WaitForSeconds(.1f);
		
		gunshotLight.intensity = 0f;
		
		float time = 0;
		
		while (time < duration)
		{
			fadeLight.intensity = Mathf.Lerp(fadeFromValue, 0f, time / duration);
			time += Time.deltaTime;
			yield return null;
		}
		
		fadeLight.intensity = 0f;
		
		yield return new WaitForSeconds(.1f);
	}	
	
	public void SetCanShoot(bool canShoot)
	{
		this.canShoot = canShoot;
	}
}
