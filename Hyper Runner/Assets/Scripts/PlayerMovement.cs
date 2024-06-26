using System.Collections;
using Parry_System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    [HideInInspector] public float speed;
    public float jumpPower;

    private bool touchingGround;
    [HideInInspector]
    public int jumpsLeft;
    private float initialGravity;

    // For jump stashing: Jump should be activated if pressed a fraction of a second before collide with ground
    private bool isJumpStashed;
    private Coroutine routine;
    private const float STASH_JUMP_FOR_SECONDS = .1f;

    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Animator animator;
    [SerializeField] private Collider2D jumpCollider;
    [SerializeField] private RuntimeAnimatorController platformAnimator;
    private AudioManager audio;

    [Header("When double jump")]
    [SerializeField] private Flash flashObject;
    [SerializeField] private Color flashColor;
    [SerializeField] private float flashSpeed;

    // parry slo mo effect information
    private Animator cameraAnimator;
    private AParryObject parryObject;

    void Start() {
        audio = FindObjectOfType<AudioManager>();
        initialGravity = rb.gravityScale;

        cameraAnimator = Camera.main.GetComponent<Animator>();
        
        ResetGravity();
    }

    void Update() {
        transform.position = new Vector3(transform.position.x + speed * MusicSync.deltaSample,
          transform.position.y, transform.position.z);
    }

    #region Input
    
    public void OnFloorDown() {
        rb.gravityScale = 20;
    }

    public void OnFloorUp() {
        rb.gravityScale = initialGravity;
    }

    private void OnJump() {
        if (jumpsLeft > 0) {
            rb.velocity = new Vector2(rb.velocity.x, 0); ;
            rb.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
            jumpsLeft -= 1;

            if (!touchingGround) {
                // double jump, will pick random between 2 diffrerent animations
                // (gator archived for the moment) 
                int randomNumber = Random.Range(0, 2);
                switch (randomNumber) {
                    case 0:
                        animator.SetTrigger("doubleJump");
                        break;
                    case 1:
                        animator.SetTrigger("twirl");
                        break;
                    case 2:
                        animator.SetTrigger("gator");
                        break;
                }
                flashObject.StartFlash(flashColor, flashSpeed);
                audio.Play("clap");
                cameraAnimator.SetTrigger("parry");
                parryObject.OnParry();
            } else {
                // normal jump
                audio.Play("jump1");
            }
        }
        else
        {
            routine = StartCoroutine(nameof(StashJump));
        }
    }
    
    #endregion

    private IEnumerator StashJump()
    {
        isJumpStashed = true;
        yield return new WaitForSeconds(STASH_JUMP_FOR_SECONDS);
        isJumpStashed = false;
        routine = null;
    }

    void OnTriggerEnter2D(Collider2D other) {

        if (jumpCollider.IsTouching(other)) {
            if (other.gameObject.CompareTag("Ground"))
                TouchGround();
        }
    }

    void TouchGround() {
        touchingGround = true;
        jumpsLeft = 1;
        animator.SetBool("jumping", false);
        audio.Play("landing");
        FindObjectOfType<CameraShake>().Begin(.02f, 10, .1f);

        if (isJumpStashed)
        {
            StashedJump();
        }
    }

    // Executes a stashed jump from the player. 
    private void StashedJump()
    {
        StopCoroutine(routine);
        routine = null;
        isJumpStashed = false;
        OnJump();
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
    public void enterParryObject(AParryObject parryObject) {
        jumpsLeft = 1;
        this.parryObject = parryObject;
        
        if (isJumpStashed)
        {
            StashedJump();
        }
    }

    // when player leaves parry obbject
    public void exitParryObject() {
        if (!touchingGround) {
            jumpsLeft = 0;
            this.parryObject = null;
        }
    }

    // activates negative gravity on the player, and flips sprite
    public void ActivateNegativeGravity(Color flashColor, float flashSpeed) {
        // this flips gravity, same magnitude negative direction
        this.rb.velocity = Vector3.zero; // resets velocity of player
        Physics2D.gravity = new Vector2(0, Mathf.Abs(Physics2D.gravity.y));
        this.transform.rotation = Quaternion.Euler(Vector3.right * 180);
        flashObject.StartFlash(flashColor, flashSpeed);
        this.jumpsLeft -= 1;
    }

    // activates normal gravity on the player, and flips sprite back to upright if needed
    public void ActivateNormalGravity(Color flashColor, float flashSpeed) {
        this.rb.velocity = Vector3.zero; // resets velocity of player 
        Physics2D.gravity = new Vector2(0, -Mathf.Abs(Physics2D.gravity.y));
        this.transform.rotation = Quaternion.Euler(Vector3.zero);
        flashObject.StartFlash(flashColor, flashSpeed);
        this.jumpsLeft -= 1;
    }

    private void ResetGravity() => Physics2D.gravity = new Vector2(0, -Mathf.Abs(Physics2D.gravity.y));

}
