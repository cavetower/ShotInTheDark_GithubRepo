using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantKey : MonoBehaviour, IShootable
{
   
   private Rigidbody rb;
   
   private void Awake() 
   {
		rb = GetComponent<Rigidbody>();
		rb.useGravity = false;
   }
   public void ShotReaction()
   {
		rb.useGravity = true;
   }
}
