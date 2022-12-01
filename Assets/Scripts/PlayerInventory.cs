using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
	[SerializeField] private Image itemHeldIcon;
	
	[SerializeField] private ItemSO itemHeld;
	
	private void Awake()
	{
		itemHeldIcon.gameObject.SetActive(false);
		itemHeld = null;
		
	}


	public void AddItemToInventory(ItemSO item)
	{
		itemHeld = item;
		
		itemHeldIcon.sprite = item.itemIcon;
		itemHeldIcon.gameObject.SetActive(true);
	}
	
	public ItemSO CurrentItemHeld()
	{
		return itemHeld;
	}
	
	public void UseItem()
	{
		itemHeld = null;
		itemHeldIcon.sprite = null;
		itemHeldIcon.gameObject.SetActive(false);
	}
}
