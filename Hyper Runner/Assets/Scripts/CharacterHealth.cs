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
    
    [SerializeField] private MotivationBar motivationBar;
    
    private const float MIN_HEIGHT = 3.8f;
    private const float MAX_HEIGHT = 14f;
    
    private Animator portrait_animator;
    private bool charismaIsHighest; // make sure "yay" sound is played only once

    // DEV FEATURES TODO: Remove this in actual game
    private MusicSync musicSync;
    private bool isFastFoward;

    void Start() {
        charisma = 100f;
        motivationBar.UpdateSlider(charisma / MAX_CHARISMA, false);
        this.isFastFoward = false;
        
        portrait_animator = GameObject.FindWithTag("CharismaPortrait").GetComponent<Animator>();
        musicSync = FindObjectOfType<MusicSync>();
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

    private void Die() {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

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

    // when the player runs into an object, they will be reset at the top of
    // the screen, with gravity reset.
    //TODO: clean this function up, tints player two times
    void RunIntoObject() {
        this.AddCharisma(-10f);
        rb.velocity = Vector2.zero;
        this.transform.position =
            Physics2D.gravity.y < 0 ? new Vector3(transform.position.x, MAX_HEIGHT - .1f, 0) : new Vector3(transform.position.x, MIN_HEIGHT + .1f, 0);
        FindObjectOfType<AudioManager>().Play("negative");
        ResultsManager.IncPlayerCrash();
    }

    // Called on every frame update
    void Update() {
        // handle player hits max height of world
        if (transform.position.y > MAX_HEIGHT || transform.position.y < MIN_HEIGHT) {
            this.RunIntoObject();
        }
    }

    //TODO: Dev feature, remove in actual game
    // activates and deactivates fast foward mode, from PLAYERINPUT
    public void OnFastFowardStart() {
        //Debug.Log("Pressed");
        if (!this.isFastFoward) {
            this.musicSync.changePitch(6f, 100f);
            this.isFastFoward = true;
        } else {
            this.musicSync.changePitch(1f, 100f);
            this.isFastFoward = false;
        }
    }

}
