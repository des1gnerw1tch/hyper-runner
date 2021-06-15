using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class sunsetManager : ALevelManager
{
    [SerializeField] public Interpolate InterpolManager;
    private float launches = 0;
    [SerializeField] public Color sky_launch2_color;
    [SerializeField] public Color horizon_launch2_color;

    public override void Start()
    {
      UpdateSpeeds();
      //Play welcome message
      StartCoroutine(PlayWelcome());
    }

    public override void SetPlayerMode(string mode)  {
      switch (mode) {
        case "Platformer":
          playerMovement.enabled = true;
          playerMovement.SetAnimatorControllerAsPlatformer();
          rhythmMovement.enabled = false;
          input.SwitchCurrentActionMap("Player"); // switches action map to rhythm
          player_rb.gravityScale = 1f;
          flyingParticles.SetActive(false);

          //KEEP start sky and horizon color change back to normal, magnitude is speed
          InterpolManager.LerpSky(-4f);
          InterpolManager.LerpHorizon(-4f);
          // END KEEP
          break;
        case "Rhythm":
          // KEEP
          launches++;
          // END KEEP
          playerMovement.enabled = false;
          rhythmMovement.enabled = true;
          input.SwitchCurrentActionMap("Dance Keys"); // switches action map to rhythm

          player_rb.gravityScale = 0;
          flyingParticles.SetActive(true);

          // this is how fast the player will jump into rhythym mode, will
          // fix this bad system later
          rhythmMovement.startRhythm(5f);

          // KEEP
          //start sky and horizon color change, including speed
          if (launches == 2)  {
            InterpolManager.SetSkyAltColor(sky_launch2_color);
            InterpolManager.SetHorizonAltColor(horizon_launch2_color);
          }
          InterpolManager.LerpSky(16f);
          InterpolManager.LerpHorizon(16f);
          // END KEEP
          break;
      }
    }

    IEnumerator PlayWelcome() {
      float delay = 3f;
      yield return new WaitForSeconds(delay);
      FindObjectOfType<AudioManager>().Play("welcomeMessage");
    }

}
