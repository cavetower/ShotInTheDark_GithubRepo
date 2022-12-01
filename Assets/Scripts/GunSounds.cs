using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunSounds : MonoBehaviour
{

	private AudioManager audioManager;
	
	private void Start() 
	{
		audioManager = AudioManager.Instance;
	}

   public void GunshotSound()
   {
		audioManager.Play("Gunshot", true);
   }
}
