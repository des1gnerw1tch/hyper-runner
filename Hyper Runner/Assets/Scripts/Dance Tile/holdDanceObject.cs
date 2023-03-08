using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/* this dance object will give you charisma when you start holding, down
a the key. once key is let up, charisma will be awarded based on how far from
the end your player is */
public class holdDanceObject : ADanceObject {
    [Header("Hold Dance Object Required Components")]
    [SerializeField] private Transform endNode;
    private bool firstPress = true;
    private bool isPressing;

    protected override void Start() {
        base.Start(); // from ADanceObject
        firstPress = true;
    }

    void Update() {

        // for new input system
        if (isPressing) {
            Pressing();
        }

        // despawn object if missed
        bool missedEntry = (player.position.x - transform.position.x) >= distanceUntilDestroy;
        bool missedExit = (player.position.x - endNode.position.x) >= distanceUntilDestroy;
        if ((missedEntry && firstPress) || missedExit) {
            this.EvaluateScore(0);
            this.DestroyDanceTile();
        }
    }

    // this function is called every frame the key is down
    void Pressing() {

        float difference = Mathf.Abs(player.position.x - transform.position.x);

        if (firstPress) { // checks if it is the players first press or not
            firstPress = false;
            score = 10 - difference;
            if (score < 0)
                score = 0;

            EvaluateScore(score);
            if (score < FAILING_SCORE) { // if first press is failure
                this.DestroyDanceTile();
            }

            Instantiate(destroyEffect, transform.position, Quaternion.identity);
            FindObjectOfType<CameraShake>().Begin(camRumbleIntensity, camRumbleSpeed, camRumbleDuration);
        } else { // not first press
            characterHealth.AddCharisma(1f * MusicSync.deltaSample);
        }
    }

    // evaluates accuracy at end of hold key
    void EndAccuracy() {
        float difference = Mathf.Abs(player.position.x - endNode.position.x);
        float endScore = 10 - difference;
        if (endScore < 0)
            endScore = 0;
        
        EvaluateScore(endScore);
        Instantiate(destroyEffect, endNode.position, Quaternion.identity);
        FindObjectOfType<CameraShake>().Begin(camRumbleIntensity, camRumbleSpeed, .1f); // to cancel rumble
        Destroy(this.endNode.gameObject);
        DestroyDanceTile();
    }

    protected override void KeyPressedCorrectly() => this.isPressing = true;

    protected override void KeyPressedIncorrectly()
    {
        this.EvaluateScore(0);
        FindObjectOfType<CameraShake>().Begin(camRumbleIntensity, camRumbleSpeed, .1f); // to cancel rumble
        Destroy(this.endNode.gameObject);
        this.DestroyDanceTile();
    }
    
    // INPUT: Will be called from player -> danceTileManager, as player is the only one with input connected
    // method stubs to override, all player input

    public override void Released(string key) {
        if (key == this.keyToPress && isPressing) {
            this.CorrectKeyReleased();
        }
    }

    // when the correct key for the dance object is released
    void CorrectKeyReleased() {
        this.isPressing = false;
        this.EndAccuracy();
    }

}
