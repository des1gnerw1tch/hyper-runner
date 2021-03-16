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
      Debug.Log(dif);
      if (dif >= distFromPlayerToRespawn)  {
        parallax.SetXPosition(player.position.x + spawnDist);
      }
    }
}
