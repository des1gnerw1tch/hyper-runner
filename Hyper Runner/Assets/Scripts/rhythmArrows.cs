using UnityEngine;

public class rhythmArrows : MonoBehaviour {
    [SerializeField] private float playerFloatingSpeed;
    [SerializeField] private float surroundingSpeedMultiplier;
    [SerializeField] private InterpolateTrigger interpolationTrigger;
    
    [Header("Auto-get components")]
    [SerializeField] private ALevelManager levelManager;

    private void Start()
    {
        levelManager = ALevelManager.Instance;
    }
    
    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")) {
            levelManager.SetPlayerMode("Rhythm");
            levelManager.playerCamMoveSpeed = playerFloatingSpeed;
            Parallax.multiplier = surroundingSpeedMultiplier;
            levelManager.UpdateSpeeds();

            if (interpolationTrigger != null) {
                this.interpolationTrigger.StartInterpolateObjects();

            } else {
                Debug.LogError("No Object to interpolate selected");
            }

        }
    }
}
