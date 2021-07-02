using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class ALevelManager : MonoBehaviour, ILevelManager {
    public float playerCamMoveSpeed = 5f;
    public Move cameraMovement;
    public PlayerMovement playerMovement;
    public RhythmMovement rhythmMovement;
    public PlayerInput input;
    public Rigidbody2D player_rb;
    public GameObject flyingParticles;
    public float launchToRhythmSpeed = 5f;

    // Start is called before the first frame update
    public virtual void Start() {
        UpdateSpeeds();
        ResultsManager.init(); // initializes results of current game, which has just started
    }

    // UpdateSpeeds : Updates the values of speed for both the camera and the player
    public virtual void UpdateSpeeds() {
        playerMovement.speed = playerCamMoveSpeed;
        rhythmMovement.speed = playerCamMoveSpeed;
        cameraMovement.speed = playerCamMoveSpeed;
    }

    // using either "Rhythm" or "Platformer" as mode, performs operations
    // to switch mode of game
    public virtual void SetPlayerMode(string mode) {
        switch (mode) {
            case "Platformer":
                playerMovement.enabled = true;
                playerMovement.SetAnimatorControllerAsPlatformer();
                rhythmMovement.enabled = false;
                input.SwitchCurrentActionMap("Platformer"); // switches action map to platformer
                player_rb.gravityScale = 5f;
                flyingParticles.SetActive(false);
                break;
            case "Rhythm":
                playerMovement.enabled = false;
                rhythmMovement.enabled = true;
                input.SwitchCurrentActionMap("Dancer"); // switches action map to rhythm

                player_rb.gravityScale = 0;
                flyingParticles.SetActive(true);

                // this is how fast the player will jump into rhythym mode, will
                // fix this bad system later
                rhythmMovement.startRhythm(this.launchToRhythmSpeed);
                break;
        }
    }
}
