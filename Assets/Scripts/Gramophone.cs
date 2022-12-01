using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gramophone : MonoBehaviour, IShootable
{
    private AudioManager audioManager;
    private AudioSource audioSource;

    private void Awake()
    {
        audioManager = AudioManager.Instance;
        audioSource = GetComponent<AudioSource>();
    }

    public void ShotReaction()
    {
        audioManager.Play("BulletHitMetal", true);
        audioSource.Stop();
    }
}
