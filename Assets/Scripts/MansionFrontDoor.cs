using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MansionFrontDoor : MonoBehaviour
{
	[SerializeField] private Animator anim;
	[SerializeField] private ParticleSystem leaves;
	private AudioManager audioManager;
	
	
	private void Start() 
	{
		audioManager = AudioManager.Instance;
	}
	
	
	
	private void OnTriggerEnter(Collider other) 
	{
		
		anim.SetTrigger("OpenDoor");
		leaves.Play();
		audioManager.Play("FrontDoorsOpen", false);
		audioManager.Play("WindGust", false);
		Destroy(this);
	}
}
