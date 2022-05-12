using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rhythmArrows : MonoBehaviour {
    [SerializeField] private ALevelManager levelManager;
    [SerializeField] private float playerFloatingSpeed;
    [SerializeField] private float surroundingSpeedMultiplier;
    
    [Header("Auto-get player components")]
    [SerializeField] private Transform player;
    [SerializeField] private danceTileManager danceManager;
    [SerializeField] private InterpolateTrigger interpolationTrigger;

    private void Start()
    {
        danceManager = danceTileManager.Instance;
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            levelManager.SetPlayerMode("Rhythm");
            levelManager.playerCamMoveSpeed = playerFloatingSpeed;
            Parallax.multiplier = surroundingSpeedMultiplier;
            levelManager.UpdateSpeeds();
            danceManager.enabled = true;
            danceManager.UpdateValidDanceKeys();
            if (interpolationTrigger != null) {
                this.interpolationTrigger.StartInterpolateObjects();

            } else {
                Debug.LogError("No Object to interpolate selected");
            }

        }
    }
}
