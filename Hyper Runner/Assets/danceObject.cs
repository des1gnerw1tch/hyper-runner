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
      float difference = Mathf.Abs(player.position.x - transform.position.x);
      score = 10 - difference;
      if (score < 0)
        score = 0;
      Debug.Log("Score: " + score);
      if (score < 9) {
        characterHealth.Die();
      }
      Destroy(gameObject);
    }

}
