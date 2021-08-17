using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/* this dance object will give you charisma when you start holding, down
a the key. once key is let up, charisma will be awarded based on how far from
the end your player is */
public class holdDanceObject : ADanceObject {
    [SerializeField] private Transform endNode;
    private bool firstPress = true;
    private bool isPressing;

    void Start() {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        characterHealth = FindObjectOfType<CharacterHealth>();
        firstPress = true;
    }

    void Update() {

        // for new input system
        if (isPressing && active) {
            Pressing();
        }

        // despawn object if missed
        bool missedEntry = (player.position.x - transform.position.x) >= distanceUntilDestroy;
        bool missedExit = (player.position.x - endNode.position.x) >= distanceUntilDestroy;
        if ((missedEntry && firstPress) || missedExit) {
            characterHealth.AddCharisma(-10f);
            try {
                FindObjectOfType<danceTileManager>().ActivateNextFowardKey();
            }
            catch (Exception e) {
                Debug.Log("tried to access dance tile manager when it was deactivated");
            }
            SpawnScoreText(missedText); // spawn missed text pop up
            FindObjectOfType<AudioManager>().Play("negative");
            ResultsManager.IncMissedDanceTiles();
            ResultsManager.IncNonPerfectTiles();
            Destroy(gameObject);
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
            if (score > 9) { // if first press is success
                FindObjectOfType<AudioManager>().Play("metronome");
            } else { // if first press is faliure
                active = false;
                Instantiate(destroyEffect, transform.position, Quaternion.identity);
                SpawnScoreText(missedText); // spawn missed text pop up
                Destroy(gameObject);
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

        FindObjectOfType<danceTileManager>().ActivateNextFowardKey();
        EvaluateScore(endScore);
        Instantiate(destroyEffect, endNode.position, Quaternion.identity);
        FindObjectOfType<CameraShake>().Begin(camRumbleIntensity, camRumbleSpeed, .1f); // to cancel rumble
        Destroy(gameObject);
    }

    public override void Pressed(string key) {
        if (this.active) {
            if (key == this.keyToPress) { // if key pressed is correct
                this.isPressing = true;
            } else { // if key pressed is incorrect
                //TODO: fill this out
            }
        }

    }
    // INPUT: Will be called from player -> danceTileManager, as player is the only one with input connected
    // method stubs to override, all player input

    public override void OnUpDanceKeyRelease() {
        if (keyToPress == "up" && active && isPressing) {
            this.CorrectKeyReleased();
        }
    }

    public override void OnDownDanceKeyRelease() {
        if (keyToPress == "down" && active && isPressing) {
            this.CorrectKeyReleased();
        }
    }

    public override void OnLeftDanceKeyRelease() {
        if (keyToPress == "left" && active && isPressing) {
            this.CorrectKeyReleased();
        }
    }

    public override void OnRightDanceKeyRelease() {
        if (keyToPress == "right" && active && isPressing) {
            this.CorrectKeyReleased();
        }
    }

    // when the correct key for the dance object is released
    void CorrectKeyReleased() {
        this.isPressing = false;
        this.EndAccuracy();
        this.active = false;
    }

}
