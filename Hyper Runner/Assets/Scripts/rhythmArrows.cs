using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhythmArrows : MonoBehaviour
{
    [SerializeField] private sunsetManager levelManager;
    [SerializeField] private float playerFloatingSpeed;
    [SerializeField] private float surroundingSpeedMultiplier;

    [SerializeField] private Transform player;
    int i = 0;

    void OnTriggerEnter2D(Collider2D other) {
      if (other.CompareTag("Player")) {
        levelManager.SetPlayerMode("Rhythm");
        levelManager.playerCamMoveSpeed = playerFloatingSpeed;
        Parallax.multiplier = surroundingSpeedMultiplier;
        levelManager.UpdateSpeeds();
        UpdateValidDanceKeys();
      }
    }

    void Update() {
      // Will update active dance key, on KeyUp because want to make sure
      // first object when clicked is deleted first (which is on KeyDown)
      if (Input.GetKeyUp("up") || Input.GetKey("down")) {
        UpdateValidDanceKeys();
      }
    }

    //Makes sure that only 1 dance key is okay to press at one time
    void UpdateValidDanceKeys() {
      danceObject[] objs = FindObjectsOfType<danceObject>();
      if (objs.Length != 0) {
        danceObject closest = objs[0];
        foreach (danceObject obj in objs) {
          if (obj.gameObject.GetComponent<Transform>().position.x < closest.GetComponent<Transform>().position.x) {
            closest = obj;
          }
        }
        closest.active = true;
      }
    }
}
