using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RePositionImage : MonoBehaviour
{
    [SerializeField] private float distFromPlayerToRespawn; // how far from player until respawn
    [SerializeField] private float spawnDist = 10f; // position placed in front of player
    [SerializeField] private Parallax parallax;
    private Transform player;

    void Start()
    {
      player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
      float dif = player.position.x - transform.position.x;
      if (dif >= distFromPlayerToRespawn)  {
        transform.position = new Vector3(player.position.x + spawnDist, transform.position.y, 0);
      }
    }
}
