using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] Move cameraMovement;
    private float difXFromPlayer; // original camera distance from player, camX-playerX
    private float originalCamHeight; // original camera height, camY
    private bool active = false; // whether camera is activitely shaking or not
    private float amplitude;    // amplitude : how big the camera displacement is
    private float duration;     // duration : how long the camera shake sequence will last
    private float speed = 10f;   // the speed in which the camera will move when shaking
    private bool xReached = false; // whether camera has successfully reached this position in shake
    private bool yReached = false;
    private string nextCycle; // what next cyle of the shake routine is
    private Vector2 target; // the target of the camera for the shake
    private bool shakeStopped; // will stop the camera shake at the next shake

    void Start()  {

    }

    // Begin : float, float -> <Shakes the camera>
    // will shake the camera, set amplitude and duration variables

    public void Begin(float _amplitude, float _speed, float _duration)  {
      difXFromPlayer = transform.position.x - player.position.x;
      originalCamHeight = transform.position.y;

      amplitude = _amplitude;
      speed = _speed;
      duration = _duration;

      StartCoroutine("StopShake");
      active = true;
      cameraMovement.enabled = false;
      // set up first shake
      target = RandVector();
      nextCycle = "shake";
      xReached = false;
      yReached = false;
    }

    void Update()
    {
      if (active) {
        if (!xReached || !yReached) {
          xReached = transform.position.x == target.x;
          yReached = transform.position.y == target.y;
          Vector2 planeVector = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
          transform.position = new Vector3(planeVector.x, planeVector.y, transform.position.z);
          Debug.Log("shaking");
        } else {
          if (shakeStopped && nextCycle == "shake") {
            active = false;
            cameraMovement.enabled = true;
            shakeStopped = false;
          } else if (nextCycle == "shake")  {
            target = RandVector();
            nextCycle = "reset";
          } else if (nextCycle == "reset") {
            target = ResetPosition();
            nextCycle = "shake";
          }
          xReached = false;
          yReached = false;
          Debug.Log("switch shake");
        }
      }
    }

    IEnumerator StopShake()
    {
       yield return new WaitForSeconds(duration);
       Debug.Log("Stopped Shake");
       shakeStopped = true;
     }

     Vector2 RandVector()  {
       float xPos = transform.position.x + Random.Range(-amplitude, amplitude);
       float yPos = transform.position.y + Random.Range(-amplitude, amplitude);
       Vector2 vector = new Vector2(xPos, yPos);
       return vector;
     }

     Vector2 ResetPosition()  {
       float xPos = difXFromPlayer + player.position.x;
       Vector2 vector = new Vector2(xPos, originalCamHeight);
       return vector;
     }
}
