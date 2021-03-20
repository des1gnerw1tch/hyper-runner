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
          skyCounter = 0;
        }
        mainCamera.backgroundColor = c;
      }
      else if (skySpeed < 0)  {
        skyCounter += MusicSync.deltaSample * Mathf.Abs(skySpeed);
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
    }

    public void LerpHorizon(float speed)  {
      horizonSpeed = speed/10;
      horizon = FindNearestHorizon();
    }

    SpriteRenderer FindNearestHorizon() {
      Transform player = GameObject.FindWithTag("Player").transform;
      GameObject[] horizons = GameObject.FindGameObjectsWithTag("Horizon");
      GameObject nearest = horizons[0];
      foreach(GameObject h in horizons) {
        float dif = h.transform.position.x - player.position.x;
        // replaces nearest with horizon that has the least positive difference between the horizon and the player
        // if the current horizon is behind the player, nearest will be the next horizon.
        if ((dif > 0 && dif < nearest.transform.position.x - player.position.x) || nearest.transform.position.x - player.position.x < 0) {
          nearest = h;
        }
      }
      return nearest.GetComponent<SpriteRenderer>();
    }
}
