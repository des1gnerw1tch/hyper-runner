using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmMovement : MonoBehaviour
{
    public float speed;
    private bool teleporting;
    private float teleportSpeed;
    [SerializeField] private const float MIDDLE_OF_SCREEN_Y = 8.8f;
    [SerializeField] private Animator animatorComponent;
    [SerializeField] private RuntimeAnimatorController rhythmAnimator;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Switched!");

    }

    // Update is called once per frame
    void Update()
    {
      transform.position = new Vector3 (transform.position.x + speed*Time.deltaTime, transform.position.y, transform.position.z);

      if (teleporting)  {
        float step = teleportSpeed * Time.deltaTime;
        Vector2 target = new Vector2(transform.position.x, MIDDLE_OF_SCREEN_Y);
        transform.position = Vector2.MoveTowards(transform.position, target, step);
        if (transform.position.y == MIDDLE_OF_SCREEN_Y) {
          teleporting = false;
          Debug.Log("Stopped Teleporting");
          animatorComponent.runtimeAnimatorController = rhythmAnimator;
        }
      }
    }

    // startRhythm : Float -> will move player
    // when called will over time kick the player into the middle of the
    // screen. it will turn off gravity too.
    public void startRhythm(float teleSpeed)  {
      Debug.Log("Started teleporting");
      teleporting = true;
      teleportSpeed = teleSpeed;
    }
}
