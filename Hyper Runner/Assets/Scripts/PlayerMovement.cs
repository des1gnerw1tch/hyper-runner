using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float speed;
  public float jumpPower;

  private bool touchingGround;
  private int jumpsLeft;
  private float initialGravity;

  [SerializeField] private Rigidbody2D rb;
  [SerializeField] private Animator animator;
  [SerializeField] private Collider2D jumpCollider;
  [SerializeField] private RuntimeAnimatorController platformAnimator;
  private AudioManager audio;

  private float lastSample;
  private float thisSample;

  void Start()  {
    audio = FindObjectOfType<AudioManager>();
    initialGravity = rb.gravityScale;
  }
  void Update()
  {
    transform.position = new Vector3 (transform.position.x + speed * MusicSync.deltaSample,
      transform.position.y, transform.position.z);

    if (Input.GetKeyDown("space") && jumpsLeft > 0)
        {
            Jump();
        }
//for mobile players

    /*if (Input.touchCount > 0) {
      Touch touch = Input.GetTouch(0);
      if (touch.phase == TouchPhase.Began && touchingGround)  {
        Jump();
      }
    }*/

    //this will ground the player when holding s
    if (Input.GetKey("s"))  {
      rb.gravityScale = 20;
    } else {
      rb.gravityScale = initialGravity;
    }

    if (Input.GetKeyDown("o"))
        {
            Debug.Log(transform.position.x);
        }

  }

  void Jump() {
    rb.velocity =  new Vector2(rb.velocity.x, 0);;
    rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
    jumpsLeft-= 1;

    //this will double jump, happens when jumping and not touching ground
    if (!touchingGround)  {
      animator.SetTrigger("doubleJump");
      audio.Play("jump2");
    } else {
      audio.Play("jump1");
    }

  }

  void OnTriggerEnter2D(Collider2D other)  {
    if (jumpCollider.IsTouching(other))  {
      if (other.gameObject.CompareTag("Ground"))
        TouchGround();
    }
  }
  void TouchGround()  {
      touchingGround = true;
      jumpsLeft = 2;
      animator.SetBool("jumping", false);
      audio.Play("landing");
      FindObjectOfType<CameraShake>().Begin(.02f, 10, .1f);
  }

  void OnCollisionExit2D(Collision2D other) {
    if (other.gameObject.CompareTag("Ground")) {
      touchingGround = false;
      animator.SetBool("jumping", true);
    }
  }
  // this will set our players animator controller to the platformer animator controller
  public void SetAnimatorControllerAsPlatformer() {
    animator.runtimeAnimatorController = platformAnimator;
  }


}
