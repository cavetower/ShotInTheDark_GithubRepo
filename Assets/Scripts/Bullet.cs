using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	
	private Coroutine bulletDestroyCoroutine;
	[SerializeField] private float timeUntilBulletDestroy = 3f;
	
   private void OnCollisionEnter(Collision other) {
		Debug.Log("Bullet collided with " + other.gameObject);
		
		if(other.gameObject.TryGetComponent(out IShootable shootable))
		{
			shootable.ShotReaction();
		}
		
		StopCoroutine(bulletDestroyCoroutine);
		Destroy(this.gameObject);
   }
   
   private void OnEnable() 
   {
		bulletDestroyCoroutine = StartCoroutine(TimeUntilDestroyBullet());
   }
   
   private IEnumerator TimeUntilDestroyBullet()
   {
		yield return new WaitForSeconds(timeUntilBulletDestroy);
		Destroy(this.gameObject);
   }

}
