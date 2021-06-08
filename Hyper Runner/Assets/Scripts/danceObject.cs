using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

    // Normal Dance Tile, press a key to interact
public class danceObject : ADanceObject
{
    private Transform player;
    private CharacterHealth characterHealth;
    [SerializeField]
    private string keyToPress;
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

    void Start()  {
      player = GameObject.FindWithTag("Player").GetComponent<Transform>();
      characterHealth = FindObjectOfType<CharacterHealth>();
    }

    void Update()
    {
      // TODO: get input for keyboard, will change to new input system later
      if (Input.GetKeyDown(keyToPress) && active) {
        Pressed();
      }

      // despawn object if missed
      if ((player.position.x - transform.position.x) >= distanceUntilDestroy)  {
        characterHealth.AddCharisma(-10f);
        try {
          FindObjectOfType<danceTileManager>().ActivateNextFowardKey();
        } catch (Exception e) {
          Debug.Log("tried to access dance tile manager when it was deactivated");
        }
        FindObjectOfType<AudioManager>().Play("negative");
        SpawnScoreText(missedText); // spawn missed text pop up
        Destroy(this.gameObject);
      }
    }

    void Pressed()  {

      float difference = Mathf.Abs(player.position.x - transform.position.x);
      score = 10 - difference;
      if (score < 0)
        score = 0;
      //Debug.Log("Score: " + score);

      if (score > 9.7)  {
        SpawnScoreText(perfectText); // spawn perfect text
        characterHealth.AddCharisma(10f);
        FindObjectOfType<AudioManager>().Play("metronome");
      } else if (score > 9.5) {
        characterHealth.AddCharisma(3f);
        SpawnScoreText(goodText); // spawn good text
        FindObjectOfType<AudioManager>().Play("metronome");
      } else if (score > 9) {
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

      Instantiate(destroyEffect, transform.position, Quaternion.identity);
      FindObjectOfType<CameraShake>().Begin(camRumbleIntensity, camRumbleSpeed, camRumbleDuration);
      Destroy(gameObject);
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

    // INPUT: Will be called from player object, as player is the only one with input connected
    public override void OnUpDanceKeyPress()  {
      if (keyToPress == "up" && active)  {
        Pressed();
      }
    }

    public override void OnDownDanceKeyPress()  {
      if (keyToPress == "down" && active) {
        Pressed();
      }
    }

}
