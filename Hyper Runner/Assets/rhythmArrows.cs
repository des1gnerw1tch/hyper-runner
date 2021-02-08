using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhythmArrows : MonoBehaviour
{
    [SerializeField] private sunsetManager levelManager;
    [SerializeField] private float playerFloatingSpeed;

    void OnTriggerEnter2D(Collider2D other) {
      if (other.CompareTag("Player")) {
        levelManager.SetPlayerMode("Rhythm");
        levelManager.playerCamMoveSpeed = playerFloatingSpeed;
        levelManager.UpdateSpeeds();
      }
    }
}
