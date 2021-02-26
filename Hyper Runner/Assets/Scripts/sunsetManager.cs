using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunsetManager : MonoBehaviour
{
    public float playerCamMoveSpeed = 5f;
    [SerializeField] private Move cameraMovement;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private RhythmMovement rhythmMovement;
    [SerializeField] private Rigidbody2D player_rb;

    void Start()
    {
      UpdateSpeeds();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown("up"))  {
        Debug.Log(Time.time);
      }
    }

    // UpdateSpeeds : Updates the values of speed for both the camera and the player
    public void UpdateSpeeds()  {
      playerMovement.speed = playerCamMoveSpeed;
      rhythmMovement.speed = playerCamMoveSpeed;
      cameraMovement.speed = playerCamMoveSpeed;
    }

    //SetPlayerMode : String Float -> switches player mode

    public void SetPlayerMode(string mode)  {
      switch (mode) {
        case "Platformer":
          playerMovement.enabled = true;
          rhythmMovement.enabled = false;
          break;
        case "Rhythm":
          playerMovement.enabled = false;
          rhythmMovement.enabled = true;
          player_rb.gravityScale = 0;
          // this is how fast the player will jump into rhythym mode, will
          // fix this bad system later
          rhythmMovement.startRhythm(5f);
          break;
      }
    }

}
