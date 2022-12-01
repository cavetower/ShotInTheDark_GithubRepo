using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpTutorialEnder : MonoBehaviour
{
	
	[SerializeField] private JumpTutorial jumpTutorial;
	// Start is called before the first frame update
	
	private void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.TryGetComponent(out CharacterController characterController))
		{
			jumpTutorial.jumpTutorialComplete = true;
		}
	}
}
