using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Item")]
public class ItemSO : ScriptableObject
{
	public string itemName;
	
	[field: TextArea]
	public string descriptionText;
	public bool canPickUp;
	public GameObject prefabModel;
	public Sprite itemIcon;
	public ParticleSystem flashingParticle;
}
