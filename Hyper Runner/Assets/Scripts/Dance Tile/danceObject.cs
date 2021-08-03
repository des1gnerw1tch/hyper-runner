using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Normal Dance Tile, press a key to interact
public class danceObject : ADanceObject {

    void Start() {
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        characterHealth = FindObjectOfType<CharacterHealth>();
    }

    void Update() {
        // despawn object if missed
        if ((player.position.x - transform.position.x) >= distanceUntilDestroy) {
            characterHealth.AddCharisma(-10f);
            try {
                FindObjectOfType<danceTileManager>().ActivateNextFowardKey();
            }
            catch (Exception e) {
                Debug.Log("tried to access dance tile manager when it was deactivated");
            }
            FindObjectOfType<AudioManager>().Play("negative");
            SpawnScoreText(missedText); // spawn missed text pop up
            Destroy(this.gameObject);
        }
    }

    void Pressed() {

        float difference = Mathf.Abs(player.position.x - transform.position.x);
        score = 10 - difference;
        if (score < 0)
            score = 0;

        this.EvaluateScore(score);

        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        FindObjectOfType<CameraShake>().Begin(camRumbleIntensity, camRumbleSpeed, camRumbleDuration);
        Destroy(gameObject);
    }

    // INPUT: Will be called from player object, as player is the only one with input connected
    public override void OnUpDanceKeyPress() {
        if (keyToPress == "up" && active) {
            Pressed();
        }
    }

    public override void OnDownDanceKeyPress() {
        if (keyToPress == "down" && active) {
            Pressed();
        }
    }

    public override void OnLeftDanceKeyPress() {
        if (this.keyToPress == "left" && active) {
            Pressed();
        }
    }

    public override void OnRightDanceKeyPress() {
        if (this.keyToPress == "right" && active) {
            Pressed();
        }
    }

}
