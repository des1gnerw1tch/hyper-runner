using System;
using System.Collections;
using SpriteVisualEffects;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// Holds level wide variables and functions
public abstract class ALevelManager : MonoBehaviour, ILevelManager {
    public float playerCamMoveSpeed = 5f;
    public Move cameraMovement;
    
    public GameObject flyingParticles;
    public float launchToRhythmSpeed = 5f;

    private const float TRANSITION_TO_RESULTS_WAIT_TIME = 4f;
    
    [Header("Auto-get Player components")]
    public PlayerMovement playerMovement;
    public RhythmMovement rhythmMovement;
    public Rigidbody2D player_rb;
    public PlayerInput input;

    private bool isPlayerAlive = true;
    private const float LEVEL_FAIL_GRAYSCALE_FADE_SPEED = 5f;
    private const float LEVEL_FAIL_RESTART_SCENE_DELAY = 1f;
    private const float LEVEL_FAIL_MOVEMENT_RAMP_TIME = 0.8f;
    
    public static ALevelManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    
    // Start is called before the first frame update
    public virtual void Start()
    {
        playerMovement = GameObject.FindWithTag("Player").GetComponent<PlayerMovement>();
        rhythmMovement = GameObject.FindWithTag("Player").GetComponent<RhythmMovement>();
        player_rb = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
        input = GameObject.FindWithTag("Player").GetComponent<PlayerInput>();
        
        
        UIManager.Instance.PlayStartTransition();
        UpdateSpeeds();
        ResultsManager.init(); // initializes results of current game, which has just started
    }

    // UpdateSpeeds : Updates the values of speed for both the camera and the player
    public virtual void UpdateSpeeds() {
        playerMovement.speed = playerCamMoveSpeed;
        rhythmMovement.speed = playerCamMoveSpeed;
        cameraMovement.speed = playerCamMoveSpeed;
    }

    // using either "Rhythm" or "Platformer" as mode, performs operations
    // to switch mode of game
    public virtual void SetPlayerMode(string mode) {
        switch (mode) {
            case "Platformer":
                playerMovement.enabled = true;
                playerMovement.SetAnimatorControllerAsPlatformer();
                rhythmMovement.enabled = false;
                input.SwitchCurrentActionMap("Platformer"); // switches action map to platformer
                player_rb.gravityScale = 5f;
                rhythmMovement.DeactivateFlyingParticles();
                break;
            case "Rhythm":
                playerMovement.enabled = false;
                rhythmMovement.enabled = true;
                input.SwitchCurrentActionMap("Dancer"); // switches action map to rhythm

                player_rb.gravityScale = 0;
                player_rb.velocity = new Vector2(player_rb.velocity.x, 0); // nullfies current Y velocity

                // this is how fast the player will jump into rhythym mode, will
                // fix this bad system later
                rhythmMovement.startRhythm(this.launchToRhythmSpeed);
                break;
        }
    }

    // Ends the game, goes to results screen
    public IEnumerator LevelCompleted()
    {
        if (isPlayerAlive)
        {
            UIManager.Instance.PlayEndTransition();
            yield return new WaitForSeconds(TRANSITION_TO_RESULTS_WAIT_TIME);
            SceneManager.LoadScene("ResultsScreen");
        }
    }

    public void LevelFailed()
    {
        if (!isPlayerAlive)
        {
            return;
        }
        isPlayerAlive = false;
        DeathVisualEffects.Instance.ActivateDeathParticles();
        DeathVisualEffects.Instance.HideCharacterSprite();
        DeathVisualEffects.Instance.DisableMotivationBar();
        InterpolateCameraGrayscale.Instance.FadeToGrayscale(LEVEL_FAIL_GRAYSCALE_FADE_SPEED);
        StartCoroutine(RampDownPlayerCamMoveSpeed(LEVEL_FAIL_MOVEMENT_RAMP_TIME));
        StartCoroutine(RestartScene());
    }
    
    private IEnumerator RampDownPlayerCamMoveSpeed(float timeToRamp)
    {
        float timeElapsed = 0f;
        MusicSync musicSync = MusicSync.Instance;
        float initialMusicPitch = musicSync.GetPitch();
        while (musicSync.GetPitch() > 0)
        {
            musicSync.changePitch(Mathf.Lerp(initialMusicPitch, 0, timeElapsed / timeToRamp));
            yield return new WaitForEndOfFrame();
            timeElapsed += Time.deltaTime;
        }
    }
    
    private IEnumerator RestartScene()
    {
        yield return new WaitForSeconds(LEVEL_FAIL_RESTART_SCENE_DELAY);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    public bool IsPlayerAlive() => isPlayerAlive;


}
