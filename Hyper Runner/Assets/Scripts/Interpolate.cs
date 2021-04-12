using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interpolate : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Color sky1;
    [SerializeField] private Color sky2;
    private float skySpeed;
    private float skyCounter;

    [SerializeField] private SpriteRenderer horizon;
    [SerializeField] private Color horizon1;
    [SerializeField] private Color horizon2;

    private float horizonSpeed;
    private float horizonCounter;

    void Update()
    {
      //sky interpolation
      if (skySpeed > 0) {
        skyCounter += MusicSync.deltaSample * skySpeed;
        Color c = Color.Lerp(sky1, sky2, skyCounter);
        if (skyCounter >= 1)  {
          skySpeed = 0;
        }
        mainCamera.backgroundColor = c;
      }
      else if (skySpeed < 0)  {
        skyCounter += MusicSync.deltaSample * Mathf.Abs(skySpeed);
        Color c = Color.Lerp(sky2, sky1, skyCounter);
        if (skyCounter >= 1)  {
          skySpeed = 0;
        }
        mainCamera.backgroundColor = c;
      }

      //Horizon Interpolation
      if (horizonSpeed > 0) {
        horizonCounter += MusicSync.deltaSample * horizonSpeed;
        Color c = Color.Lerp(horizon1, horizon2, horizonCounter);
        if (horizonCounter >= 1)  {
          horizonSpeed = 0;
        }
        horizon.color = c;
      }
      else if (horizonSpeed < 0)  {
        horizonCounter += MusicSync.deltaSample * Mathf.Abs(horizonSpeed);
        Color c = Color.Lerp(horizon2, horizon1, horizonCounter);
        if (horizonCounter >= 1)  {
          horizonSpeed = 0;
        }
        horizon.color = c;
      }

    }

    public void LerpSky(float speed)  {
      skySpeed = speed/10;
      skyCounter = 0; // resets our counter variable
    }

    public void LerpHorizon(float speed)  {
      horizonSpeed = speed/10;
      horizonCounter = 0; // resets our counter variable
    }

    public void SetSkyAltColor(Color col)  {
      sky2 = col;
    }

    public void SetHorizonAltColor(Color col)  {
      horizon2 = col;
    }

}
