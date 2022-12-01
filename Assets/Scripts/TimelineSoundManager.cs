using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimelineSoundManager : MonoBehaviour
{

	public void PlayTimelineSound(string soundName)
	{
		AudioManager.Instance.Play(soundName, false);
	}
}
