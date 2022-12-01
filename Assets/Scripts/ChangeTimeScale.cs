using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTimeScale : MonoBehaviour
{
    [SerializeField] private float slowMotionTimescale = .1f;

    private float startTimescale;
    private float startFixedDeltaTime;

    void Start()
    {
        startTimescale = Time.timeScale;
        startFixedDeltaTime = Time.fixedDeltaTime;
    }

    public void StartSlowMotion()
    {
        Time.timeScale = slowMotionTimescale;
        Time.fixedDeltaTime = startFixedDeltaTime * slowMotionTimescale;
    }

    public void StopSlowMotion()
    {
        Time.timeScale = startTimescale;
        Time.fixedDeltaTime = startFixedDeltaTime;
    }
}
