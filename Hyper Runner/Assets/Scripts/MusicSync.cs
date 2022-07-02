using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Makes sure that music is synced with game
 */
public class MusicSync : MonoBehaviour {
    public AudioSource levelMusic;
    private float thisSample;
    private float lastSample;
    public static float deltaSample;
    private float pitch;
    private float duration;
    
    private ProgressBar progressBar;

    void Start() {
        deltaSample = 0f;
        progressBar = ProgressBar.Instance;
    }

    // Update is called once per frame
    void Update() {
        thisSample = levelMusic.timeSamples;
        deltaSample = (thisSample - lastSample) / 90000;
        lastSample = thisSample;
        UpdateProgressBar();
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

    // Pauses the music that is being played
    public void PauseMusic() {
        this.levelMusic.Pause();
    }

    // Resumes the music that is being played
    public void ResumeMusic() {
        this.levelMusic.Play();
    }

    private void UpdateProgressBar()
    {
        Debug.Log(levelMusic.time / levelMusic.clip.length);
        progressBar.UpdateProgress(levelMusic.time / levelMusic.clip.length);
    }
}
