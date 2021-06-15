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
      base.SetPlayerMode(mode); // call base SetPlayerMode function
      switch (mode) {
        case "Platformer":
          //start sky and horizon color change back to normal, magnitude is speed
          InterpolManager.LerpSky(-4f);
          InterpolManager.LerpHorizon(-4f);
          break;
        case "Rhythm":
          launches++;
          //start sky and horizon color change, including speed
          if (launches == 2)  {
            InterpolManager.SetSkyAltColor(sky_launch2_color);
            InterpolManager.SetHorizonAltColor(horizon_launch2_color);
          }
          InterpolManager.LerpSky(16f);
          InterpolManager.LerpHorizon(16f);
          break;
      }
    }

    IEnumerator PlayWelcome() {
      float delay = 3f;
      yield return new WaitForSeconds(delay);
      FindObjectOfType<AudioManager>().Play("welcomeMessage");
    }

}
