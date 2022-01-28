using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePositionImage : MonoBehaviour
{
    [Tooltip("How far from player until respawn")]
    [SerializeField] private float distFromPlayerToRespawn;
    [Tooltip("Distance placed in front of player")]
    [SerializeField] private float spawnDist = 10f;
    [SerializeField] private float spawnDistWiggle = 0f; // position randomly placed
    private Transform player;

    void Start()
    {
      player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
      float dif = player.position.x - transform.position.x;
      if (dif >= distFromPlayerToRespawn)  {
        float wiggle = Random.Range(0f, spawnDistWiggle);
        float xPos = player.position.x + spawnDist + wiggle;
        transform.position = new Vector3(xPos, transform.position.y, 0);
      }
    }
}
