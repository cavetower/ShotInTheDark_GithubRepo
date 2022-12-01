using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeWalkingSurface : MonoBehaviour
{
	
	public GameManager.GroundType groundType;
	
	private void OnTriggerEnter(Collider other) 
	{
		if(other.GetComponent<CharacterController>() != null)
		{
			GameManager.Instance.ChangeGroundType(groundType);
		}
	}
}
