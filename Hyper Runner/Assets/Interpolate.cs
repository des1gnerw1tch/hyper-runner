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

    void Start()
    {
      //mainCamera.backgroundColor = sky2;
      //LerpSky(-8);
      //LerpHorizon(-3);
    }

    void Update()
    {
      //sky interpolation
      if (skySpeed > 0) {
        skyCounter += Time.deltaTime * skySpeed;
        Color c = Color.Lerp(sky1, sky2, skyCounter);
        if (skyCounter >= 1)  {
          skySpeed = 0;
          skyCounter = 0;
        }
        mainCamera.backgroundColor = c;
      }
      else if (skySpeed < 0)  {
        skyCounter += Time.deltaTime * Mathf.Abs(skySpeed);
        Color c = Color.Lerp(sky2, sky1, skyCounter);
        if (skyCounter >= 1)  {
          skySpeed = 0;
          horizonCounter = 0;
        }
        mainCamera.backgroundColor = c;
      }

      //Horizon Interpolation
      //sky interpolation
      if (horizonSpeed > 0) {
        horizonCounter += Time.deltaTime * horizonSpeed;
        Color c = Color.Lerp(horizon1, horizon2, horizonCounter);
        if (horizonCounter >= 1)  {
          horizonSpeed = 0;
        }
        horizon.color = c;
      }
      else if (horizonSpeed < 0)  {
        horizonCounter += Time.deltaTime * Mathf.Abs(horizonSpeed);
        Color c = Color.Lerp(horizon2, horizon1, horizonCounter);
        if (horizonCounter >= 1)  {
          horizonSpeed = 0;
        }
        horizon.color = c;
      }

    }

    public void LerpSky(float speed)  {
      skySpeed = speed/10;
    }

    public void LerpHorizon(float speed)  {
      horizonSpeed = speed/10;
    }
}
