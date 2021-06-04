using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  public float speed;
  public float jumpPower;

  private bool touchingGround;
  /*[HideInInspector]*/ public int jumpsLeft;
  private float initialGravity;

  [SerializeField] private Rigidbody2D rb;
  [SerializeField] private Animator animator;
  [SerializeField] private Collider2D jumpCollider;
  [SerializeField] private RuntimeAnimatorController platformAnimator;
  private AudioManager audio;

  private float lastSample;
  private float thisSample;

  [Header("When double jump")]
  [SerializeField] private Flash flashObject;
  [SerializeField] private Color flashColor;
  [SerializeField] private float flashSpeed;

  // parry slo mo effect information
  [SerializeField] private MusicSync musicSync;
  [SerializeField] private Animator cameraAnimator;
  private const float SLOMOPITCH = 1f;
  private const float SLOMODURATION = .3f;

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

    if (!touchingGround)  {
      // double jump
      animator.SetTrigger("doubleJump");
      flashObject.StartFlash(flashColor, flashSpeed);
      audio.Play("clap");
      musicSync.changePitch(SLOMOPITCH, SLOMODURATION);
      cameraAnimator.SetTrigger("parry");
    } else {
      // normal jump
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
      jumpsLeft = 1;
      animator.SetBool("jumping", false);
      audio.Play("landing");
      FindObjectOfType<CameraShake>().Begin(.02f, 10, .1f);
  }

  void OnCollisionExit2D(Collision2D other) {
    if (other.gameObject.CompareTag("Ground")) {
      touchingGround = false;
      animator.SetBool("jumping", true);
      jumpsLeft = 0;
    }
  }
  // this will set our players animator controller to the platformer animator controller
  public void SetAnimatorControllerAsPlatformer() {
    animator.runtimeAnimatorController = platformAnimator;
  }

  // when player enters parry object
  public void enterParryObject()  {
    jumpsLeft = 1;
  }

  // when player leaves parry obbject
  public void exitParryObject() {
    if (!touchingGround) {
      jumpsLeft = 0;
    }
  }


}
