using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;


public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager Instance;
    public AudioMixer startingAudioMixer;


   void Awake()
   {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return; 
        }

        DontDestroyOnLoad(gameObject);

        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.outputAudioMixerGroup = s.audioMixerGroup;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;

            s.source.loop = s.loop;

        }
   }


    public void Play (string name, bool randomPitch)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if ( s == null )
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        if(randomPitch == true)
        {
            s.source.pitch = UnityEngine.Random.Range(.8f, 1.2f);
        }


        s.source.Play();
    }



    public void FadeInMusic(AudioMixer audioMixer)
    {
        //StartCoroutine(FadeMixerGroup.StartFade(audioMixer, "BadLullabyVolume_Piano", 3f, 1f));
    }




    /*Either cache the audio manager (for lots of sounds) with: declaring a AudioManager variable and then use
    audioManager = GetComponent<AudioManager>(); in Awake method. Then use audioManager.Play("NAME OF CLIP", false); 

    ALTERNATIVELY, use FindObjectOfType<AudioManager>().Play("NAME OF CLIP", false);

    The bool after the name of the clip is a true or false to randomize pitch.*/
}

