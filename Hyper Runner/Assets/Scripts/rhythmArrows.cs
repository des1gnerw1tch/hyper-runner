using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhythmArrows : MonoBehaviour {
    [SerializeField] private ALevelManager levelManager;
    [SerializeField] private float playerFloatingSpeed;
    [SerializeField] private float surroundingSpeedMultiplier;

    [SerializeField] private Transform player;
    [SerializeField] private danceTileManager danceManager;
    [SerializeField] private InterpolateColor objectToInterpolate;
    [SerializeField] private float speedToInterpolate;
    [SerializeField] private Color colorToInterpolate;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            levelManager.SetPlayerMode("Rhythm");
            levelManager.playerCamMoveSpeed = playerFloatingSpeed;
            Parallax.multiplier = surroundingSpeedMultiplier;
            levelManager.UpdateSpeeds();
            danceManager.enabled = true;
            danceManager.UpdateValidDanceKeys();
            if (objectToInterpolate != null) {
                this.objectToInterpolate.Lerp(speedToInterpolate, colorToInterpolate);
            }

        }
    }
}
