using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()  {
      player = GameObject.FindWithTag("Player").GetComponent<Transform>();
      characterHealth = FindObjectOfType<CharacterHealth>();
    }
    void Update()
    {
      if (Input.GetKeyDown(keyToPress) && active) {
        Pressed();
      }

      // kill player if goes to far
      if ((player.position.x - transform.position.x) >= distanceUntilDestroy)  {
        characterHealth.Die();
      }
    }

    void Pressed()  {
      FindObjectOfType<AudioManager>().Play("metronome");
      float difference = Mathf.Abs(player.position.x - transform.position.x);
      score = 10 - difference;
      if (score < 0)
        score = 0;
      Debug.Log("Score: " + score);

      if (score > 9.7)  {
        SpawnScoreText(perfectText); // spawn perfect text
      } else if (score > 9.5) {
        SpawnScoreText(goodText); // spawn good text
      } else if (score > 9) {
        SpawnScoreText(okText); // spawn ok text
      } else  {
        characterHealth.Die();
      }

      Instantiate(destroyEffect, transform.position, Quaternion.identity);
      Destroy(gameObject);
    }

    void SpawnScoreText(GameObject text) {
      var image = Instantiate(text) as GameObject;
      image.transform.SetParent(canvas.transform, false);
    }

}
