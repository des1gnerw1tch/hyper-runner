using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] Transform player;
    private float difXFromPlayer; // original camera distance from player, camX-playerX
    private bool active = false; // whether camera is activitely shaking or not
    private float intensity;    // intensity : how big the camera displacement is

    void Start()  {
      difXFromPlayer = transform.position.x - player.position.x;
    }

    // Begin : float, float -> <Shakes the camera>
    // will shake the camera, set intensity and duration variables
    // duration : how long the camera shake sequence will last
    public void Begin(float _intensity, float _duration)  {
      intensity = _intensity;
      string coroutine = "StopShake(_duration)";
      StartCoroutine(coroutine);
      active = true;
    }

    void Update()
    {
      if (active) {
        // do camera shake
      }
    }

    IEnumerator StopShake(float dur)
    {
       yield return new WaitForSeconds(dur);
       Debug.Log("Stopped Shake");
       active = false;
     }
}
