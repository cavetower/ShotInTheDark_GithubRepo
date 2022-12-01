using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class StartCutscene : MonoBehaviour
{
	[SerializeField] PlayableDirector timeLine;

	private void OnTriggerEnter(Collider other) 
	{
		GameManager.Instance.CutSceneHappening(true);
		timeLine.Play();
	}

}
