using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhythmArrows : MonoBehaviour
{
    [SerializeField] private sunsetManager levelManager;
    [SerializeField] private float playerFloatingSpeed;
    [SerializeField] private float surroundingSpeedMultiplier;

    [SerializeField] private Transform player;

    void OnTriggerEnter2D(Collider2D other) {
      if (other.CompareTag("Player")) {
        levelManager.SetPlayerMode("Rhythm");
        levelManager.playerCamMoveSpeed = playerFloatingSpeed;
        Parallax.multiplier = surroundingSpeedMultiplier;
        levelManager.UpdateSpeeds();
        //UpdateValidDanceKeys();
        //FindObjectOfType<CameraShake>().Begin(.5f, 15f, 1f);
      }
    }
}
