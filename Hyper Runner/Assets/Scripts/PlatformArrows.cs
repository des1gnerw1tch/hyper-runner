using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformArrows : MonoBehaviour {
    [SerializeField] private ALevelManager levelManager;
    [SerializeField] private float playerRunningSpeed;
    [SerializeField] private float surroundingSpeedMultiplier;
    [SerializeField] private danceTileManager danceManager;
    [SerializeField] private InterpolateColor objectToInterpolate;
    [SerializeField] private float speedToInterpolate;
    [SerializeField] private Color colorToInterpolate;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            levelManager.SetPlayerMode("Platformer");
            levelManager.playerCamMoveSpeed = playerRunningSpeed;
            Parallax.multiplier = surroundingSpeedMultiplier;
            levelManager.UpdateSpeeds();
            danceManager.enabled = false;

            if (objectToInterpolate != null) {
                this.objectToInterpolate.Lerp(speedToInterpolate, colorToInterpolate);
            }
        }
    }
}
