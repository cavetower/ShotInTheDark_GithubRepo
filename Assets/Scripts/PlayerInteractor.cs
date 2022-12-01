using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
	[SerializeField] private Transform interactionPoint;
	[SerializeField] private float interactionPointRadius;
	[SerializeField] private LayerMask interactableMask;
	
	[SerializeField] private Camera cam;
	
	[SerializeField] private InputManager inputManager;
	
	[SerializeField] private PlayerUI playerUI;
	
	private PlayerController playerController;
	private PlayerInventory playerInventory;
	private CameraController cameraController;
	private Item currentItem;
	
	
	//Tracks a maximum of three interactable onjects.
	private readonly Collider[] colliders = new Collider[3];
	private int numCollidersFound;
	
	
	private void Start()
	{
		playerInventory = GetComponent<PlayerInventory>();
		playerController = inputManager.GetPlayerController();
		cameraController = Camera.main.GetComponent<CameraController>();
	}
	
	
	//Used to show the interaction area.
	
	// private void OnDrawGizmos() 
	// {
	// 	Gizmos.color = Color.red;
	// 	Gizmos.DrawWireSphere(this.interactionPoint.position, this.interactionPointRadius);		
	// }

	
	public void CheckForInteractable()
	{
		numCollidersFound = Physics.OverlapSphereNonAlloc(interactionPoint.position, interactionPointRadius, colliders, interactableMask);
		
		if(numCollidersFound > 0)
		{
			
			//Interacting with an ITEM.
			if(colliders[0].GetComponent<Item>() != null)
			{	
				inputManager.ToggleActionMap(playerController.Interaction);	
				
				
				currentItem = colliders[0].GetComponent<Item>();
				currentItem.InteractWithItem();	
			}
			
			//Interacting with something other than an Item. 
			else if(colliders[0].GetComponent<BaseInteractable>() != null)
			{		
				if(colliders[0].GetComponent<BaseInteractable>().TryInteraction())
				{
					inputManager.ToggleActionMap(playerController.Interaction);	
					
				}
			}
		}
		else
		{
			Debug.Log(gameObject.name + " has NOTHING to interact with!");
		}
	}
	
	
	public void EndInteraction()
	{
		if(currentItem != null)
		{
			if(currentItem.ItemCutSceneCompleteCheck())
			{
				if(currentItem.CanPickUpCheck())
				{
					PickUpItem();
				}
			
				inputManager.ToggleActionMap(playerController.Player);
				
				cameraController.RegainCameraControl();
				playerUI.ClearPromptText();
			}
		}
		else if(cameraController.CheckIsCameraDoneLooking())
		{	
			inputManager.ToggleActionMap(playerController.Player);
			
			cameraController.RegainCameraControl();
		}
		else
		{
			Debug.Log("Can't End Interaction Yet!");
		}
	}
	
	public void PickUpItem()
	{
		playerInventory.AddItemToInventory(currentItem.item);
		
		AudioManager.Instance.Play("PickUpKey", false);
		
		//Logic to pick up item
		Destroy(currentItem.gameObject);
		currentItem = null;
	}
	
	
	
	
}
