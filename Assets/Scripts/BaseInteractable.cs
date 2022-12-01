using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseInteractable: MonoBehaviour
{    
	
	[SerializeField] private bool isItemRequired;
	[SerializeField] private ItemSO itemRequired;
	
	private PlayerInventory playerInventory;
	protected CameraController cameraController;
	
	
	public virtual void Awake()
	{
		playerInventory = FindObjectOfType<PlayerInventory>();
		
		if(playerInventory == null)
		{
			Debug.LogWarning("MISSING PLAYER INVENTORY");
		}
		
		cameraController = Camera.main.GetComponent<CameraController>();
		
		if(cameraController == null)
		{
			Debug.LogWarning("MISSING PLAYER INVENTORY ON " + gameObject);
		}
		
		
	}
	
	public virtual bool TryInteraction()
	{
		if(!isItemRequired)
		{
			Interaction();
			return true;
		}
		
		if(isItemRequired)
		{
			if(itemRequired == playerInventory.CurrentItemHeld())
			{
				playerInventory.UseItem();
				Interaction(); 
				return true;
			}
			else
			{
				AudioManager.Instance.Play("VO_DontHaveKey", false);
				return false;
			}
		}
		
		return false;
	}
	
	protected abstract void Interaction();
	
	protected abstract void CameraLookAtInteraction(Transform cameraLookPoint);
	
}
