using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhythmArrows : MonoBehaviour {
    [SerializeField] private ALevelManager levelManager;
    [SerializeField] private float playerFloatingSpeed;
    [SerializeField] private float surroundingSpeedMultiplier;

    [SerializeField] private Transform player;
    [SerializeField] private danceTileManager danceManager;
    [SerializeField] private AInterpolateColor objectToInterpolate;
    [SerializeField] private float speedToInterpolate;
    [SerializeField] private Color colorToInterpolate;
    [SerializeField] private bool shouldRainbowMash = false;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            levelManager.SetPlayerMode("Rhythm");
            levelManager.playerCamMoveSpeed = playerFloatingSpeed;
            Parallax.multiplier = surroundingSpeedMultiplier;
            levelManager.UpdateSpeeds();
            danceManager.enabled = true;
            danceManager.UpdateValidDanceKeys();
            if (objectToInterpolate != null) {
                //this.objectToInterpolate.Lerp(speedToInterpolate, colorToInterpolate);
                if (this.shouldRainbowMash) {
                    this.objectToInterpolate.RainbowMash(speedToInterpolate);
                } else {
                    this.objectToInterpolate.Lerp(speedToInterpolate, colorToInterpolate);
                }

            } else {
                Debug.LogError("No Object to interpolate selected");
            }

        }
    }
}
