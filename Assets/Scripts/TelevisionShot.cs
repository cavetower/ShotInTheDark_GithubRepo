using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelevisionShot : MonoBehaviour, IShootable
{
    private AudioManager audioManager;

    private void Awake()
    {
        audioManager = AudioManager.Instance;
    }

    public void ShotReaction()
    {
        audioManager.Play("BulletHitMetal", true);
    }
}
