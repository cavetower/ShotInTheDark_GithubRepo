using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullet : MonoBehaviour
{
	
	[SerializeField] private BulletCounter bulletCounter;
	[SerializeField] private GunshotLight gunshotLight;
	
	[SerializeField] private GameObject bullet;
	[SerializeField] private float shootForce;
	
	[SerializeField] private Camera cam;
	[SerializeField] private Transform shootPoint;
	
	[SerializeField] private InputManager inputManager;
	
	[SerializeField] private Transform altShootPoint;
		
	private bool atZeroBullets;
	Ray ray;
	

	public void Shoot()
	{
		if(!CheckToShoot() || !inputManager.IsAimingCheck())
		{
			//don't shoot if check to shoot is false or isn't aiming
			return;
		}
		
		
		Vector3 fwd = shootPoint.transform.TransformDirection(Vector3.forward);
		RaycastHit hit;
		
		Vector3 targetPoint;
		
	 	if(Physics.Raycast(shootPoint.transform.position, fwd, out hit))
		{
			targetPoint = hit.point;
		}
		else
		{
			targetPoint = altShootPoint.position;
		}		
		
		Vector3 directionOfShot = targetPoint - shootPoint.position;
		//Instantiate Bullet
		GameObject currentBullet = Instantiate(bullet, shootPoint.position, Quaternion.identity);
		
		//Rotate bullet to shoot direction
		currentBullet.transform.forward = directionOfShot.normalized;
		
		//Add force to bullet
		currentBullet.GetComponent<Rigidbody>().AddForce(directionOfShot.normalized * shootForce, ForceMode.Impulse);
		
	}
	
	private bool CheckToShoot()
	{
		if(bulletCounter.AreShotsRemaing() && gunshotLight.canShoot)
		{
			return true;
		}
		else if(!bulletCounter.AreShotsRemaing())
		{
			if(!atZeroBullets)
			{
				atZeroBullets = true;
				return true;	
			}
			else
			{
				NoShotsLeft();
				return false;
			}
		}
		else
		{
			return false;
		}
	}
	
	private void OnDrawGizmos() 
	{
		Gizmos.color = Color.red;
		Gizmos.DrawRay(ray);
			
	}
	
	private void NoShotsLeft()
	{
		
		//To prevent audio on the first shot which takes you to zero bullets.
		// if(!atZeroBullets)
		// {
		// 	atZeroBullets = true;
		// 	return;
		// }
		
		
		int randomCantShoot = Random.Range(1,3);
			
		if(randomCantShoot == 1)
		{
			AudioManager.Instance.Play("VO_LastShot", false);
		}
		if(randomCantShoot == 2)
		{
			AudioManager.Instance.Play("VO_NoBullets", false);
		}
		
	}
}
