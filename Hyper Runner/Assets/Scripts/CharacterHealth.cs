using System.Collections;
using Checkpoints;
using SpriteVisualEffects;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour {
    [SerializeField] private Collider2D frontCollider;
    public float charisma = 70f;
    private const float MIN_CHARISMA = 0f;
    private const float MAX_CHARISMA = 100f;
    [SerializeField] private Flash objToFlash;
    [SerializeField] private Color posFlashColor;
    [SerializeField] private Color negFlashColor;
    [SerializeField] private float flashSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private AlphaFade playerFade;

    private CheckpointManager checkpointManager;
    private MyLakitu myLakitu;
    
    [SerializeField] private MotivationBar motivationBar;
    
    private const float MIN_HEIGHT = 3.8f;
    private const float MAX_HEIGHT = 14f;
    private const float FADE_CYCLE_TIME = 0.45f;
    
    private Animator portrait_animator;
    private bool charismaIsHighest; // make sure "yay" sound is played only once

    private bool isInvincible = false; // Is in this state after platforming collision and now waiting for next checkpoint.
    
    // DEV FEATURES TODO: Remove this in actual game
    private MusicSync musicSync;
    private bool isFastFoward;

    void Start() {
        charisma = 100f;
        motivationBar.UpdateSlider(charisma / MAX_CHARISMA, false);
        this.isFastFoward = false;
        
        portrait_animator = GameObject.FindWithTag("CharismaPortrait").GetComponent<Animator>();
        musicSync = FindObjectOfType<MusicSync>();
        
        checkpointManager = CheckpointManager.Instance;
        myLakitu = MyLakitu.Instance;
    }


    // Sharp object case, kill player on any collision, including land on.
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Sharp")) { // A "Sharp" object means that player will die on it.
            this.RunIntoObject();
        }
    }

    // Any object case, if front collider is breached by game object, game over.
    void OnTriggerEnter2D(Collider2D other) {
        if (frontCollider.IsTouching(other)) {
            // only kills player on ground/sharp objects
            if (other.CompareTag("Ground") || (other.CompareTag("Sharp")))
                this.RunIntoObject();

        }
    }

    private void Die() => ALevelManager.Instance.LevelFailed();

        // Charisma
    public void AddCharisma(float value)
    {
        float oldCharisma = charisma;
        float raw = charisma + value;
        charisma = Mathf.Clamp(raw, MIN_CHARISMA, MAX_CHARISMA);
        UpdatePortrait();
        TintPlayer(value);
        motivationBar.UpdateSlider(charisma / MAX_CHARISMA, !Mathf.Approximately(oldCharisma, charisma));
        
        if (charisma == 0) {
            Die();
        }
    }

    // Updates the UI portrait of character depending on current charisma!
    private void UpdatePortrait() {
        if (charisma == 100) {
            portrait_animator.SetTrigger("4");
            if (!charismaIsHighest) { // make sure "yay" sound is played only once
                FindObjectOfType<AudioManager>().Play("yay");
            }
            charismaIsHighest = true;
        } else if (charisma >= 60) {
            portrait_animator.SetTrigger("3");
        } else if (charisma >= 30) {
            portrait_animator.SetTrigger("2");
            charismaIsHighest = false;
        } else if (charisma >= 0) {
            portrait_animator.SetTrigger("1");
            charismaIsHighest = false;
        }
    }

    // Tints the player either a positive or negative color
    private void TintPlayer(float num) {
        if (num > 0) {
            objToFlash.StartFlash(posFlashColor, flashSpeed);
        } else {
            objToFlash.StartFlash(negFlashColor, flashSpeed);
        }
    }

    // When the player runs into an object.
    private void RunIntoObject() 
    {
        if (isInvincible || !ALevelManager.Instance.IsPlayerAlive())
        {
            return;
        }

        AddCharisma(-10f);
        FindObjectOfType<AudioManager>().Play("negative");
        ResultsManager.IncPlayerCrash();
        
        Vector3? checkpointPos = checkpointManager.FindNearestCheckpoint(transform.position.x);

        if (checkpointPos.HasValue)
        {
            myLakitu.ActivateLakitu(checkpointPos.Value);
            PlayerToNextCheckpoint(checkpointPos.Value);
        }
        else
        {
            Debug.LogError("Player has run into object, and there is no checkpoint in front of player");
            transform.position =
                Physics2D.gravity.y < 0 ? new Vector3(transform.position.x, MAX_HEIGHT - .1f, 0) : new Vector3(transform.position.x, MIN_HEIGHT + .1f, 0);
        }
    }

    // Player will be frozen and invincible until they reach the next checkpoint. Player will lerp from their last position to the next checkpoint. Player
    // alpha value will flash, indicating that the player is invincible. 
    private void PlayerToNextCheckpoint(Vector3 checkpointPos)
    {
        Vector3 initialPos = transform.position;
        float xDistanceForLerp = (checkpointPos.x - initialPos.x) / 4; // Distance to reach for Y pos to match checkpoint
        
        rb.isKinematic = true;
        rb.velocity = Vector2.zero;
        isInvincible = true;
        
        playerFade.StartCycleFade(FADE_CYCLE_TIME);

        StartCoroutine(LerpToYPos());
        StartCoroutine(EnableMovementPastCheckpoint(checkpointPos.x));
        
        
        // Local coroutine to lerp character to next checkpoint Y position
        IEnumerator LerpToYPos()
        {
            float lerpProgress = (transform.position.x - initialPos.x) / xDistanceForLerp;

            while (lerpProgress <= 1)
            {
                float xPos = transform.position.x;
                transform.position = new Vector3(xPos, Mathf.Lerp(initialPos.y, checkpointPos.y, lerpProgress), initialPos.z);
                lerpProgress = (xPos - initialPos.x) / xDistanceForLerp;
                yield return new WaitForEndOfFrame();
            }
            
            transform.position = new Vector3(transform.position.x, checkpointPos.y, initialPos.z);
        }
        
        
        // Local coroutine to enable movement once we get past the checkpoint.
        IEnumerator EnableMovementPastCheckpoint(float checkpointX)
        {
            if (transform.position.x < checkpointX)
            {
                yield return new WaitForEndOfFrame();
                StartCoroutine(EnableMovementPastCheckpoint(checkpointX));
            }
            else
            {
                // Stop invincibility of player, disable lakitu. 
                isInvincible = false;
                rb.isKinematic = false;
                playerFade.StopCycleFade();
                myLakitu.DeactivateLakitu();
            }
        
        }
    }
    
    // Called on every frame update
    void Update() {
        // handle player hits max height of world
        if (transform.position.y > MAX_HEIGHT || transform.position.y < MIN_HEIGHT) {
            this.RunIntoObject();
        }

        // TODO: Remove, but this scrubs backwards
        if (Input.GetKeyDown(KeyCode.LeftShift) && !this.isFastFoward)
        {
            this.musicSync.changePitch(-1f, 10000f);
        } else if (Input.GetKeyUp(KeyCode.LeftShift) && !this.isFastFoward)
        {
            this.musicSync.changePitch(1f, 10000f);
        }
    }

    //TODO: Dev feature, remove in actual game
    // activates and deactivates fast foward mode, from PLAYERINPUT
    public void OnFastFowardStart() {
        //Debug.Log("Pressed");
        if (!this.isFastFoward) {
            this.musicSync.changePitch(6f, 10000f);
            this.isFastFoward = true;
        } else {
            this.musicSync.changePitch(1f, 10000f);
            this.isFastFoward = false;
        }
    }

}
