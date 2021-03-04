using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class danceObject : MonoBehaviour
{
    private Transform player;
    [SerializeField]
    private string keyToPress;
    private float score;
    public bool active = false; // active : can be interacted with?

    void Start()  {
      player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    void Update()
    {
      if (Input.GetKeyDown(keyToPress) && active) {
        Pressed();
      }
    }

    void Pressed()  {
      float difference = Mathf.Abs(player.position.x - transform.position.x);
      score = 10 - difference;
      if (score < 0)
        score = 0;
      Debug.Log(score);
      Destroy(gameObject);
    }

}
