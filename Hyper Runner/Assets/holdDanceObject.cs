using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/* this dance object will give you charisma when you start holding, down
a the key. once key is let up, charisma will be awarded based on how far from
the end your player is */
public class holdDanceObject : MonoBehaviour
{
    private Transform player;
    private CharacterHealth characterHealth;
    [SerializeField] private string keyToPress;
    [SerializeField] private Transform endNode;
    [SerializeField] private float distanceUntilDestroy;
    private float score;
    [HideInInspector] public bool active = false; // active is whether object can be interacted with
    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private GameObject okText;
    [SerializeField] private GameObject goodText;
    [SerializeField] private GameObject perfectText;
    [SerializeField] private GameObject missedText;
    [SerializeField] private GameObject canvas;
    [SerializeField] private float camRumbleIntensity;
    [SerializeField] private float camRumbleSpeed;
    [SerializeField] private float camRumbleDuration;
    private bool firstPress = true;

    void Start()  {
      player = GameObject.FindWithTag("Player").GetComponent<Transform>();
      characterHealth = FindObjectOfType<CharacterHealth>();
      firstPress = true;
    }

    void Update()
    {
      if (Input.GetKey(keyToPress) && active) {
        Pressing();
      }

      if (Input.GetKeyUp(keyToPress) && active) {
        EndAccuracy();
        active = false;
      }

      // despawn object if missed
      if ((player.position.x - transform.position.x) >= distanceUntilDestroy && firstPress)  {
        characterHealth.AddCharisma(-10f);
        try {
          FindObjectOfType<danceTileManager>().ActivateNextFowardKey();
        } catch (Exception e) {
          Debug.Log("tried to access dance tile manager when it was deactivated");
        }
        SpawnScoreText(missedText); // spawn missed text pop up
        FindObjectOfType<AudioManager>().Play("negative");
        Destroy(gameObject);
      }
    }

    void Pressing()  { // this function is called every frame the key is down

      float difference = Mathf.Abs(player.position.x - transform.position.x);

      if (firstPress) { // checks if it is the players first press or not
        firstPress = false;
        score = 10 - difference;
        if (score < 0)
          score = 0;

        EvaluateScore(score);
        if (score > 9)  { // if first press is success
          FindObjectOfType<AudioManager>().Play("metronome");
        } else { // if first press is faliure
          active = false;
          Instantiate(destroyEffect, transform.position, Quaternion.identity);
          SpawnScoreText(missedText); // spawn missed text pop up
          Destroy(gameObject);
        }

        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        FindObjectOfType<CameraShake>().Begin(camRumbleIntensity, camRumbleSpeed, camRumbleDuration);
        Debug.Log("Score: " + score);
      } else { // not first press
        Debug.Log(1f * MusicSync.deltaSample);
        characterHealth.AddCharisma(1f * MusicSync.deltaSample);
      }
    }

    void EndAccuracy ()  {
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

    void EvaluateScore(float _score)  {
      if (_score > 9.7)  {
        SpawnScoreText(perfectText); // spawn perfect text
        characterHealth.AddCharisma(10f);
        FindObjectOfType<AudioManager>().Play("metronome");
      } else if (_score > 9.5) {
        characterHealth.AddCharisma(3f);
        SpawnScoreText(goodText); // spawn good text
        FindObjectOfType<AudioManager>().Play("metronome");
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
      } else  {
        characterHealth.AddCharisma(-10f);
        SpawnScoreText(missedText); // spawn missed text pop up
        FindObjectOfType<AudioManager>().Play("negative");
      }
    }

    void SpawnScoreText(GameObject text) {
      var image = Instantiate(text) as GameObject;
      image.transform.SetParent(canvas.transform, false);

      // set the placement of these pop ups a little random
      float wobble = 15;
      float difX = UnityEngine.Random.Range(-wobble, wobble);
      float difY = UnityEngine.Random.Range(-wobble, wobble);
      image.GetComponent<RectTransform>().Translate(new Vector3(difX, difY, 0), Space.World);
    }
}
