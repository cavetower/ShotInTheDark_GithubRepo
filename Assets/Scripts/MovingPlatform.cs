using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{



private void OnTriggerStay(Collider other) 
{
	if(other.gameObject.TryGetComponent(out CharacterController characterController))
	{
		characterController.gameObject.transform.SetParent(this.gameObject.transform);
	}
}

private void OnTriggerExit(Collider other) 
{
	if(other.gameObject.TryGetComponent(out CharacterController characterController))
	{
		characterController.gameObject.transform.parent = null;
	}
}

}
