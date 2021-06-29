using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// a dance tile object
public abstract class ADanceObject : MonoBehaviour, IDanceObject {

    [HideInInspector] public bool active = false; // active is whether object can be interacted with
    [HideInInspector] public Transform player; // player transform 
    [HideInInspector] public float score; // score earned for this dance tile
    public CharacterHealth characterHealth; // character health of player
    public string keyToPress; // the key to press for this dance object
    public float distanceUntilDestroy; // the dist from player for this object to destroy itself after miss
    public GameObject destroyEffect; // gameobject spawned when dance tile is destroyed
    public GameObject okText; // OK rating text prefab
    public GameObject goodText; // GOOD rating text prefab
    public GameObject perfectText; // PERFECT rating text prefab
    public GameObject missedText; // MISSED rating text prefab
    public GameObject canvas; // current scene canvas
    public float camRumbleIntensity; // camera shake amplitude
    public float camRumbleSpeed; // camera shake speed
    public float camRumbleDuration; // camera shake duration

    // method stubs to override, all player input
    public virtual void OnUpDanceKeyPress() {

    }

    public virtual void OnDownDanceKeyPress() {

    }

    public virtual void OnUpDanceKeyRelease() {

    }

    public virtual void OnDownDanceKeyRelease() {

    }

    public virtual void OnAnyDanceKeyPress() {

    }

    // TODO: clean this up this function sucks
    // spawns rating texts and adds to charisma when player presses a dance key
    // EFFECT: adds to characterHealth charisma, changes ResultsManager fields
    public void EvaluateScore(float _score) {
        ResultsManager.IncTotalDanceTiles();
        if (_score > 9.7) {
            SpawnScoreText(perfectText); // spawn perfect text
            characterHealth.AddCharisma(10f);
            FindObjectOfType<AudioManager>().Play("metronome");

        } else if (_score > 9.5) {
            characterHealth.AddCharisma(3f);
            SpawnScoreText(goodText); // spawn good text
            FindObjectOfType<AudioManager>().Play("metronome");
            ResultsManager.IncNonPerfectTiles();
        } else if (_score > 9) {
            if (characterHealth.charisma > 50f) {
                characterHealth.AddCharisma(-5f); // "okay" rating will only penalize if at high-charisma
                FindObjectOfType<AudioManager>().Play("metronome");
            } else {
                characterHealth.AddCharisma(3f);
                FindObjectOfType<AudioManager>().Play("metronome");
            }
            FindObjectOfType<AudioManager>().Play("metronome");
            SpawnScoreText(okText); // spawn ok text
            ResultsManager.IncNonPerfectTiles();
        } else {
            characterHealth.AddCharisma(-10f);
            SpawnScoreText(missedText); // spawn missed text pop up
            FindObjectOfType<AudioManager>().Play("negative");
            ResultsManager.IncNonPerfectTiles();
            ResultsManager.IncMissedDanceTiles();
        }
    }

    // spawns a score text on the players canvas
    public void SpawnScoreText(GameObject text) {
        var image = Instantiate(text) as GameObject;
        image.transform.SetParent(canvas.transform, false);

        // set the placement of these pop ups a little random
        float wobble = 15;
        float difX = UnityEngine.Random.Range(-wobble, wobble);
        float difY = UnityEngine.Random.Range(-wobble, wobble);
        image.GetComponent<RectTransform>().Translate(new Vector3(difX, difY, 0), Space.World);
    }



}
