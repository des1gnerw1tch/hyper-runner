using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicSync : MonoBehaviour
{
    public AudioSource levelMusic;
    private float thisSample;
    private float lastSample;
    public static float deltaSample;
    private float pitch;
    private float duration;
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

    // changes pitch for # of seconds
    public void changePitch(float pitch, float duration) {
      this.pitch = pitch;
      this.duration = duration;
      StartCoroutine("pitchChange");
    }

    IEnumerator pitchChange() {
      float originalPitch = levelMusic.pitch;
      levelMusic.pitch = pitch;
      yield return new WaitForSeconds(duration);
      levelMusic.pitch = originalPitch;
    }
}
