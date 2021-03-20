using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSync : MonoBehaviour
{
    public AudioSource levelMusic;
    private float thisSample;
    private float lastSample;
    public static float deltaSample;
    void Start()
    {
      deltaSample = 0f;
    }

    // Update is called once per frame
    void Update()
    {
      thisSample = levelMusic.timeSamples;
      deltaSample = (thisSample - lastSample) / 90000;
      lastSample = thisSample;
      //Debug.Log(deltaSample);
    }
}
