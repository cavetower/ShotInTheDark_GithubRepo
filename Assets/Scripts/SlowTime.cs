using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour
{

	[SerializeField] private float timeUnitlSlowMotion = 3f;

	public void SlowMotionStart()
	{
		StartCoroutine(SlowMotion());
	}
	
	
	public IEnumerator SlowMotion()
	{
		float time = 0;
		
		while (time < timeUnitlSlowMotion)
		{
			
			Time.timeScale = Mathf.Lerp(1f, .05f, time / timeUnitlSlowMotion);
			time += Time.deltaTime;
			yield return null;
		}
		Time.timeScale = .05f;
		Time.fixedDeltaTime = Time.timeScale * .02f;
	}
	
	
	public void ResetTimeScale()
	{
		Time.timeScale = 1f;
	}

}
