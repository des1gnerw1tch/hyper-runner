using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

/*
 * Deals with setting up scene transitions and user interface inside of the rhythm game.
 */
public class UIManager : MonoBehaviour
{

    [Header("Required Serialization")] [SerializeField]
    private GameObject pauseScreen;

    // indicator of what button we are on for control scheme 
    [SerializeField] private GameObject indicatorGroup;

    [SerializeField] private GameObject startTransitionPanel;
    [SerializeField] private Animator fadeToResultsScreenPanel;

    // Where Perfect, Good, Ok, and Missed scores are spawned under
    [SerializeField] private Transform scorePopUpParent;

    // For pitch modifier text
    [SerializeField] private GameObject pitchModifierPanel;
    [SerializeField] private TextMeshProUGUI pitchMultiplier;
    [SerializeField] private TextMeshProUGUI pitchMultiplierDistanceLeft;

    [Header("Required Prefab in Scene, automatically fetched")] [SerializeField]
    private PlayerInput input;

    [SerializeField] private MusicSync musicSync;

    private bool isGamePaused;
    private string inputMapBeforePaused; // what input map was enabled before we paused the game?

    public static UIManager Instance { get; private set; }

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
    void Start()
    {
        this.Init();
    }

    // Set up class fields
    void Init()
    {
        this.pauseScreen.SetActive(false); // disable pause screen at beginning of game
        this.isGamePaused = false;

        // tells LoadArcadeScene to load settings based on THIS scene
        LoadArcadeScene.sceneFrom = SceneManager.GetActiveScene().name;

        this.musicSync = FindObjectOfType<MusicSync>();
        this.input = FindObjectOfType<PlayerInput>();

        UIInputHandler.Instance.OnPause.AddListener(PauseKeyPressed);
    }

    // When a pause key is pressed
    private void PauseKeyPressed()
    {
        if (this.isGamePaused)
        {
            this.ResumeGame();
        }
        else
        {
            this.PauseGame();
        }

        //this.isGamePaused = !this.isGamePaused;
    }

    // Pauses the game by enabling pause screen, makes sure game is in paused state as well
    void PauseGame()
    {
        FindObjectOfType<AudioManager>().Play("pause");
        this.inputMapBeforePaused = this.input.currentActionMap.name;
        input.SwitchCurrentActionMap("UI"); // switches action map to rhythm

        // turn off indicators if not on a controller 
        if (input.currentControlScheme != "Gamepad Control Scheme")
        {
            indicatorGroup.SetActive(false);
            Cursor.visible = true;
        }
        else
        {
            indicatorGroup.SetActive(true);
        }

        this.musicSync.PauseMusic();
        Time.timeScale = 0f;
        this.pauseScreen.SetActive(true);
        this.isGamePaused = true;
    }

    // Resumes the game if paused
    public void ResumeGame()
    {
        FindObjectOfType<AudioManager>().Play("resume");
        input.SwitchCurrentActionMap(this.inputMapBeforePaused); // switches action map to rhythm

        this.musicSync.ResumeMusic();
        Time.timeScale = 1f;
        this.pauseScreen.SetActive(false);
        this.isGamePaused = false;
        Cursor.visible = false;
    }

    // When player wants to exit game
    public void ExitGame()
    {
        Time.timeScale = 1f;
        //  LoadArcadeScene.sceneFrom = SceneManager.GetActiveScene().name; // tells LoadArcadeScene to load
        // settings based on THIS scene
        SceneManager.LoadScene("Menu"); // load the arcade machine scene, exits this game
    }

    public void PlayStartTransition() => startTransitionPanel.SetActive(true);

    public void PlayEndTransition() => fadeToResultsScreenPanel.SetTrigger("activate");

    public Transform GetScorePopUpParent() => scorePopUpParent;

    public void SetPitchMultiplierPanelActive(bool active) => pitchModifierPanel.SetActive(active);

    public void SetPitchMultiplierText(float multiplier)
    {
        float rounded = Mathf.Round(multiplier * 100) / 100;
        pitchMultiplier.text = rounded + "x";
    }

    public void SetPitchMultiplierDistanceLeftText(float distanceLeft)
    {
        float rounded = Mathf.Round(distanceLeft * 10) / 10;
        pitchMultiplierDistanceLeft.text = rounded + "m";
    }



}
