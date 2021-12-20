using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformArrows : MonoBehaviour {
    [SerializeField] private ALevelManager levelManager;
    [SerializeField] private float playerRunningSpeed;
    [SerializeField] private float surroundingSpeedMultiplier;
    [SerializeField] private danceTileManager danceManager;
    [SerializeField] private InterpolateTrigger interpolationTrigger;

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            levelManager.SetPlayerMode("Platformer");
            levelManager.playerCamMoveSpeed = playerRunningSpeed;
            Parallax.multiplier = surroundingSpeedMultiplier;
            levelManager.UpdateSpeeds();
            danceManager.enabled = false;

            if (interpolationTrigger != null) {
                this.interpolationTrigger.StartInterpolateObjects();

            } else {
                Debug.LogError("No Object to interpolate selected");
            }
        }
    }
}
