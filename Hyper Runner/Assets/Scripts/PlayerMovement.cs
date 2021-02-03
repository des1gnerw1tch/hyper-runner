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
  private AudioManager audio;

  void Start()  {
    audio = FindObjectOfType<AudioManager>();
    initialGravity = rb.gravityScale;
  }
  void Update()
  {
    transform.position = new Vector3 (transform.position.x + speed*Time.deltaTime, transform.position.y, transform.position.z);
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

  }

  void Jump() {
    rb.velocity =  new Vector2(rb.velocity.x, 0);;
    rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
    jumpsLeft-= 1;
    Debug.Log("Jumped");

    //this will double jump, happens when jumping and not touching ground
    if (!touchingGround)  {
      animator.SetTrigger("doubleJump");
      audio.Play("jump2");
    } else {
      audio.Play("jump1");
    }

  }

  void OnCollisionEnter2D(Collision2D other)  {
    if (other.gameObject.CompareTag("Ground")) {
      touchingGround = true;
      jumpsLeft = 2;
      Debug.Log("Touched the ground");
      animator.SetBool("jumping", false);
      audio.Play("landing");
    }
  }

  void OnCollisionExit2D(Collision2D other) {
    if (other.gameObject.CompareTag("Ground")) {
      touchingGround = false;
      animator.SetBool("jumping", true);
    }
  }



}
