using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    // Normal Dance Tile, press a key to interact
public class danceObject : MonoBehaviour
{
    private Transform player;
    private CharacterHealth characterHealth;
    [SerializeField]
    private string keyToPress;
    [SerializeField] private float distanceUntilDestroy;
    private float score;
    public bool active = false; // active : can be interacted with?
    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private GameObject okText;
    [SerializeField] private GameObject goodText;
    [SerializeField] private GameObject perfectText;
    [SerializeField] private GameObject canvas;
    [SerializeField] private Flash objToFlash;
    [SerializeField] private Color flashColor;
    [SerializeField] private Color negativeFlashColor;
    [SerializeField] private float flashSpeed;
    [SerializeField] private float camRumbleIntensity;
    [SerializeField] private float camRumbleSpeed;
    [SerializeField] private float camRumbleDuration;

    void Start()  {
      player = GameObject.FindWithTag("Player").GetComponent<Transform>();
      characterHealth = FindObjectOfType<CharacterHealth>();
    }
    void Update()
    {
      if (Input.GetKeyDown(keyToPress) && active) {
        Pressed();
      }

      // despawn object if missed
      if ((player.position.x - transform.position.x) >= distanceUntilDestroy)  {
        characterHealth.AddCharisma(-10f);
        FindObjectOfType<danceTileManager>().ActivateNextFowardKey();
        FindObjectOfType<AudioManager>().Play("negative");
        objToFlash.StartFlash(negativeFlashColor, flashSpeed);
        Destroy(this.gameObject);
      }
    }

    void Pressed()  {

      float difference = Mathf.Abs(player.position.x - transform.position.x);
      score = 10 - difference;
      if (score < 0)
        score = 0;
      Debug.Log("Score: " + score);

      if (score > 9.7)  {
        SpawnScoreText(perfectText); // spawn perfect text
        characterHealth.AddCharisma(10f);
        FindObjectOfType<AudioManager>().Play("metronome");
        objToFlash.StartFlash(flashColor, flashSpeed);
      } else if (score > 9.5) {
        characterHealth.AddCharisma(3f);
        SpawnScoreText(goodText); // spawn good text
        FindObjectOfType<AudioManager>().Play("metronome");
        objToFlash.StartFlash(flashColor, flashSpeed);
      } else if (score > 9) {
        if (characterHealth.charisma > 50f) {
          characterHealth.AddCharisma(-5f); // "okay" rating will only penalize if at high-charisma
        }
        FindObjectOfType<AudioManager>().Play("metronome");
        SpawnScoreText(okText); // spawn ok text
        objToFlash.StartFlash(flashColor, flashSpeed);
      } else  {
        characterHealth.AddCharisma(-10f);
        FindObjectOfType<AudioManager>().Play("negative");
        objToFlash.StartFlash(negativeFlashColor, flashSpeed);
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
      float difX = Random.Range(-wobble, wobble);
      float difY = Random.Range(-wobble, wobble);
      image.GetComponent<RectTransform>().Translate(new Vector3(difX, difY, 0), Space.World);
    }

}
