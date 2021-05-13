using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] Transform player;
    private float originalCamX; // original camera X position
    private float originalCamY; // original camera height, camY
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
      originalCamX = transform.localPosition.x;
      originalCamY = transform.localPosition.y;
    }

    // Begin : float, float -> <Shakes the camera>
    // will shake the camera, set amplitude and duration variables

    public void Begin(float _amplitude, float _speed, float _duration)  {
      ResetVariables();
      amplitude = _amplitude;
      speed = _speed;
      duration = _duration;
      StartCoroutine("StopShake");
      // set up first shake
      target = RandVector();
    }

    void Update()
    {
      if (active) {
        if (!xReached || !yReached) {
          xReached = transform.localPosition.x == target.x;
          yReached = transform.localPosition.y == target.y;
          Vector2 planeVector = Vector2.MoveTowards(transform.localPosition, target, speed * Time.deltaTime);
          transform.localPosition = new Vector3(planeVector.x, planeVector.y, transform.localPosition.z);
        } else {
          if (shakeStopped && nextCycle == "shake") {
            active = false; // shaking ends here...
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
        }
      }
    }

    IEnumerator StopShake()
    {
       yield return new WaitForSeconds(duration);
       shakeStopped = true;
     }

     Vector2 RandVector()  {
       float xPos = transform.localPosition.x + Random.Range(-amplitude, amplitude);
       float yPos = transform.localPosition.y + Random.Range(-amplitude, amplitude);
       Vector2 vector = new Vector2(xPos, yPos);
       return vector;
     }

     Vector2 ResetPosition()  {
       Vector2 vector = new Vector2(originalCamX, originalCamY);
       return vector;
     }

     void ResetVariables()  {
       active = true;
       yReached = false;
       xReached = false;
       nextCycle = "shake";
       shakeStopped = false;
     }
}
