using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class ALevelManager : MonoBehaviour, ILevelManager
{
  public float playerCamMoveSpeed = 5f;
  public Move cameraMovement;
  public PlayerMovement playerMovement;
  public RhythmMovement rhythmMovement;
  public PlayerInput input;
  public Rigidbody2D player_rb;
  public GameObject flyingParticles;

    // Start is called before the first frame update
    public virtual void Start()
    {
      UpdateSpeeds();
    }

    // UpdateSpeeds : Updates the values of speed for both the camera and the player
    public virtual void UpdateSpeeds()  {
      Debug.Log("Using Amanager class");
      playerMovement.speed = playerCamMoveSpeed;
      rhythmMovement.speed = playerCamMoveSpeed;
      cameraMovement.speed = playerCamMoveSpeed;
    }

    // using either "Rhythm" or "Platformer" as mode, performs operations
    // to switch mode of game
    public virtual void SetPlayerMode(string mode)  {
      switch (mode) {
        case "Platformer":
          playerMovement.enabled = true;
          playerMovement.SetAnimatorControllerAsPlatformer();
          rhythmMovement.enabled = false;
          input.SwitchCurrentActionMap("Player"); // switches action map to rhythm
          player_rb.gravityScale = 1f;
          flyingParticles.SetActive(false);
          break;
        case "Rhythm":
          playerMovement.enabled = false;
          rhythmMovement.enabled = true;
          input.SwitchCurrentActionMap("Dance Keys"); // switches action map to rhythm

          player_rb.gravityScale = 0;
          flyingParticles.SetActive(true);

          // this is how fast the player will jump into rhythym mode, will
          // fix this bad system later
          rhythmMovement.startRhythm(5f);
          break;
      }
    }
}
