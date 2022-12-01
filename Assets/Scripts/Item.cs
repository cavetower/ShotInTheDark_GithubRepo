using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	public ItemSO item;
	
	private bool itemCutSceneComplete = false;
	
	private ParticleSystem itemParticles;
	
	private PlayerUI playerUI;
	
	[SerializeField] private string voiceOverToCall;

	
	[SerializeField] float cutsceneTimeLength;
	
	private void Awake()
	{
		
		playerUI = FindObjectOfType<PlayerUI>();
		
		if(playerUI == null)
		{
			Debug.LogWarning("THERE IS NO PROMPT TEXT UI.");
		}	
	}
	
	private void OnEnable() 
	{
		if(itemParticles != null)
		{
			itemParticles = Instantiate(item.flashingParticle, this.transform.position, Quaternion.identity, this.transform);
			itemParticles.Play(true);		
		}
		else
		{
			Debug.LogWarning("ITEM HAS NO PARTICLES SET UP.");
		}
	}
	
	public void InteractWithItem()
	{
		itemCutSceneComplete = false;
		
		CameraController cameraController = Camera.main.GetComponent<CameraController>();
		
		cameraController.LookAtTransform(this.transform, 2f, false);
		StartCoroutine(ItemInteractionCutScene());
		
	}
	
	private IEnumerator ItemInteractionCutScene()
	{
		if(itemParticles != null)
		{
			itemParticles.Stop(true);		
		}
		
		
		if(voiceOverToCall != null)
		{
			AudioManager.Instance.Play(voiceOverToCall, false);			
		}

		playerUI.promptText.alpha = 1f;
		//playerUI.DoDisplayPromptText(item.descriptionText);
		yield return new WaitForSeconds(cutsceneTimeLength);
		
		if(ControllerType.isUsingKeyboard)
		{
			playerUI.DoDisplayPromptText("Press <sprite name=SpaceBar> button to pick up key.");	
		}
		else
		{
		 playerUI.DoDisplayPromptText("Press <sprite name=SouthButton> button to pick up key.");	
		}
		
		
		itemCutSceneComplete = true; 
	}
	
	public bool ItemCutSceneCompleteCheck()
	{
		return itemCutSceneComplete;
	}
	
	public bool CanPickUpCheck()
	{
		return item.canPickUp;
	}
	
}
