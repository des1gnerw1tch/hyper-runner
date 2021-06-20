using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    public float jumpPower;

    private bool touchingGround;
    /*[HideInInspector]*/
    public int jumpsLeft;
    private float initialGravity;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Collider2D jumpCollider;
    [SerializeField] private RuntimeAnimatorController platformAnimator;
    private AudioManager audio;

    private float lastSample;
    private float thisSample;

    [Header ("When double jump")]
    [SerializeField] private Flash flashObject;
    [SerializeField] private Color flashColor;
    [SerializeField] private float flashSpeed;

    // parry slo mo effect information
    [SerializeField] private MusicSync musicSync;
    [SerializeField] private Animator cameraAnimator;
    private AParryObject parryObject;

    void Start() {
        audio = FindObjectOfType<AudioManager> ();
        initialGravity = rb.gravityScale;
    }

    void Update() {
        transform.position = new Vector3 (transform.position.x + speed * MusicSync.deltaSample,
          transform.position.y, transform.position.z);

        // keyboard control
        if (Input.GetKeyDown ("space")) {
            OnJump ();

        }
        //for mobile players

        /*if (Input.touchCount > 0) {
          Touch touch = Input.GetTouch(0);
          if (touch.phase == TouchPhase.Began && touchingGround)  {
            Jump();
          }
        }*/

        //this will ground the player when holding s
        /*if (Input.GetKey("s"))  {
          rb.gravityScale = 20;
        } else {
          rb.gravityScale = initialGravity;
        }*/

        if (Input.GetKeyDown ("o")) {
            Debug.Log (transform.position.x);
        }
    }

    public void OnFloorDown() {
        rb.gravityScale = 20;
    }

    public void OnFloorUp() {
        rb.gravityScale = initialGravity;
    }

    public void OnJump() {
        if (jumpsLeft > 0) {
            rb.velocity = new Vector2 (rb.velocity.x, 0); ;
            rb.AddForce (transform.up * jumpPower, ForceMode2D.Impulse);
            jumpsLeft -= 1;

            if (!touchingGround) {
                // double jump
                int randomNumber = Random.Range (0, 3);
                Debug.Log (randomNumber);
                switch (randomNumber) {
                    case 0:
                        animator.SetTrigger ("doubleJump");
                        break;
                    case 1:
                        animator.SetTrigger ("twirl");
                        break;
                    case 2:
                        animator.SetTrigger ("gator");
                        break;
                }
                flashObject.StartFlash (flashColor, flashSpeed);
                audio.Play ("clap");
                cameraAnimator.SetTrigger ("parry");
                parryObject.onParry ();
            } else {
                // normal jump
                audio.Play ("jump1");
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other) {

        if (jumpCollider.IsTouching (other)) {
            if (other.gameObject.CompareTag ("Ground"))
                TouchGround ();
        }
    }

    void TouchGround() {
        touchingGround = true;
        jumpsLeft = 1;
        animator.SetBool ("jumping", false);
        audio.Play ("landing");
        FindObjectOfType<CameraShake> ().Begin (.02f, 10, .1f);
    }

    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag ("Ground")) {
            touchingGround = false;
            animator.SetBool ("jumping", true);
            jumpsLeft = 0;
        }
    }
    // this will set our players animator controller to the platformer animator controller
    public void SetAnimatorControllerAsPlatformer() {
        animator.runtimeAnimatorController = platformAnimator;
    }

    // when player enters parry object
    public void enterParryObject(AParryObject parryObject) {
        jumpsLeft = 1;
        this.parryObject = parryObject;
    }

    // when player leaves parry obbject
    public void exitParryObject() {
        if (!touchingGround) {
            jumpsLeft = 0;
            this.parryObject = null;
        }
    }


}
