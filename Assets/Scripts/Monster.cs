using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class Monster : MonoBehaviour
{
	
	[SerializeField] private SceneReset sceneReset;
	[SerializeField] private PlayableDirector timeLine;
	bool isDead = false;
	
	[SerializeField] private GameObject whiteScreen;
	
	[SerializeField] ChangeTimeScale changeTimeScale;
	
	private void OnTriggerEnter(Collider other) 
	{
		
		//Hit by Monster
		if(other.GetComponent<CharacterController>() != null && isDead==false)
		{
			changeTimeScale.StopSlowMotion();
			
			if(sceneReset != null)
			{
				AudioManager.Instance.Play("MonsterImpact", true);
				sceneReset.OnPlayerDeath();
			}
						
			SceneController.ReloadScene();
		}


		//Monster has been shot
		else if(other.GetComponent<Bullet>()!=null)
		{
			
			isDead=true;
			AudioManager.Instance.Play("MonsterDeath", true);
			timeLine.Stop();
			StopAllCoroutines();
			changeTimeScale.StopSlowMotion();
			StartCoroutine(KillMonster());
		}
	}

	public IEnumerator KillMonster()
	{
		whiteScreen.SetActive(true);
		
		yield return new WaitForSeconds(3f);
		
		AsyncOperation operation = SceneManager.LoadSceneAsync(7);
		
		
		while(!operation.isDone)
		{
			
			yield return null;		
		}
	}


}
