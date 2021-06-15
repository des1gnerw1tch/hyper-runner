using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class ALevelManager : MonoBehaviour, ILevelManager
{
  public float playerCamMoveSpeed = 5f;
  [SerializeField] private Move cameraMovement;
  [SerializeField] private PlayerMovement playerMovement;
  [SerializeField] private RhythmMovement rhythmMovement;
  [SerializeField] private PlayerInput input;
  [SerializeField] private Rigidbody2D player_rb;
  [SerializeField] private GameObject flyingParticles;
  [SerializeField] private Interpolate InterpolManager;
  [SerializeField] private Color sky_launch2_color;
  [SerializeField] private Color horizon_launch2_color;


    // Start is called before the first frame update
    void Start()
    {
      UpdateSpeeds();
    }

    // UpdateSpeeds : Updates the values of speed for both the camera and the player
    public void UpdateSpeeds()  {
      playerMovement.speed = playerCamMoveSpeed;
      rhythmMovement.speed = playerCamMoveSpeed;
      cameraMovement.speed = playerCamMoveSpeed;
    }

    // using either "Rhythm" or "Platformer" as mode, performs operations
    // to switch mode of game
    public void SetPlayerMode(string mode)  {
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
