using UnityEngine;

// a dance tile object
public abstract class ADanceObject : MonoBehaviour, IDanceObject {
    [HideInInspector] public Transform player; // player transform 
    [HideInInspector] public float score; // score earned for this dance tile
    private static int perfectInARow; // how many perfects in a row one as got

    [Header("Required Components/Prefabs (Auto)")]
    public CharacterHealth characterHealth; // character health of player
    public PerfectStreakTextManager perfectStreakTextManager; // Text holding Streak of Perfects prefab
    public Transform scorePopUpParent;

    [Header("Required Components/Prefabs")]
    public GameObject destroyEffect; // gameobject spawned when dance tile is destroyed
    public GameObject okText; // OK rating text prefab
    public GameObject goodText; // GOOD rating text prefab
    public GameObject perfectText; // PERFECT rating text prefab
    public GameObject missedText; // MISSED rating text prefab


    [Header("Dance Tile Properties")]
    public string keyToPress; // the key to press for this dance object
    public float distanceUntilDestroy; // the dist from player for this object to destroy itself after miss

    public float camRumbleIntensity; // camera shake amplitude
    public float camRumbleSpeed; // camera shake speed
    public float camRumbleDuration; // camera shake duration

    [Header("Required If Tile Is Last In Sequence")]
    public bool isLastTileInSequence; // is this the last tile before platform mode?
    [SerializeField] private ALevelManager levelManager; // Level Manager of current game
    [SerializeField] private float playerRunningSpeed; // How fast should player run when platform mode activated?
    [SerializeField] private float surroundingSpeedMultiplier; // How fast should surroundings move past screen? 
    [SerializeField] private danceTileManager danceManager; // Dance manager script on Player
    [SerializeField] private InterpolateTrigger interpolationTrigger;
    
    // Score is 10 - difference (see dance tile objects like holdDanceObject). A score that is less than this will register as a fail. 
    protected const float FAILING_SCORE = 8.5f;
    

    // Functions called directly from Dance Tile Manager, which uses Player Input (reference unity input system 1.0.2)
    // these functions are called when player does an action that requires action from this dance tile
    public virtual void OnUpDanceKeyPress() { this.KeyPressed("up"); }

    public virtual void OnDownDanceKeyPress() { this.KeyPressed("down"); }

    // left and right dance keys have to swap input when Cam is flipped over Y
    public virtual void OnLeftDanceKeyPress() { this.KeyPressed(CameraOrientation.isYFlipped ? "right" : "left"); }

    public virtual void OnRightDanceKeyPress() { this.KeyPressed(CameraOrientation.isYFlipped ? "left" : "right"); }

    public virtual void OnUpDanceKeyRelease() { this.Released("up"); }

    public virtual void OnDownDanceKeyRelease() { this.Released("down"); }

    public virtual void OnLeftDanceKeyRelease() { this.Released(CameraOrientation.isYFlipped ? "right" : "left"); }

    public virtual void OnRightDanceKeyRelease() { this.Released(CameraOrientation.isYFlipped ? "left" : "right"); }

    public virtual void OnAnyDanceKeyPress() { }

    // Action Handlers
    public void KeyPressed(string key)
    {
        if (key == keyToPress)
        {
            KeyPressedCorrectly();
        }
        else
        {
            KeyPressedIncorrectly();
        }
    }
    
    protected abstract void KeyPressedCorrectly();
    
    protected abstract void KeyPressedIncorrectly();
    
    public virtual void Released(string key) { } // on default is empty

    // TODO: clean this up this function sucks
    // spawns rating texts and adds to charisma when player presses a dance key
    // EFFECT: adds to characterHealth charisma, changes ResultsManager fields
    protected void EvaluateScore(float _score) {

        ResultsManager.IncTotalDanceTiles();
        if (_score > 9.2) {
            SpawnScoreText(perfectText); // spawn perfect text
            perfectInARow++;
            if (perfectInARow > 1) { // if over 1 perfect in a row
                this.SpawnPerfectMultiplierText();
            }

            characterHealth.AddCharisma(10f);
            FindObjectOfType<AudioManager>().Play("metronome");
            ResultsManager.IncPerfectTiles();

        } else if (_score > 8.9) {
            perfectInARow = 0;
            characterHealth.AddCharisma(3f);
            SpawnScoreText(goodText); // spawn good text
            FindObjectOfType<AudioManager>().Play("metronome");
            ResultsManager.IncGoodTiles();
        } else if (_score > FAILING_SCORE) {
            perfectInARow = 0;
            if (characterHealth.charisma > 50f) {
                characterHealth.AddCharisma(-5f); // "okay" rating will only penalize if at high-charisma
                FindObjectOfType<AudioManager>().Play("metronome");
            } else {
                characterHealth.AddCharisma(3f);
                FindObjectOfType<AudioManager>().Play("metronome");
            }
            FindObjectOfType<AudioManager>().Play("metronome");
            SpawnScoreText(okText); // spawn ok text
            ResultsManager.IncOkTiles();
        } else {
            perfectInARow = 0;
            characterHealth.AddCharisma(-10f);
            SpawnScoreText(missedText); // spawn missed text pop up
            FindObjectOfType<AudioManager>().Play("negative");
            ResultsManager.IncMissedDanceTiles();
        }
    }

    // spawns a score text on the players canvas
    private void SpawnScoreText(GameObject text) {
        var image = Instantiate(text, scorePopUpParent);

        // set the placement of these pop ups a little random
        this.Wobble(image.GetComponent<RectTransform>(), 15);
    }

    // spawns the text for how many perfects you got in a row
    private void SpawnPerfectMultiplierText() {
        GameObject instance = this.perfectStreakTextManager.SpawnPerfectStreakText(perfectInARow); // Spawns a perfect streak text
        // set the placement of these pop ups a little random
        this.Wobble(instance.GetComponent<RectTransform>(), 100);
    }

    // Makes UI element have slight X and Y shift, magnitude depending on wobble
    void Wobble(RectTransform rt, float wobble) {
        float difX = UnityEngine.Random.Range(-wobble, wobble);
        float difY = UnityEngine.Random.Range(-wobble, wobble);
        rt.Translate(new Vector3(difX, difY, 0), Space.World);
    }

    // Destroys dance tile, spawns effects, enables next dance tile to receive input if one exists
    protected void DestroyDanceTile() {
        Instantiate(this.destroyEffect, this.transform.position, Quaternion.identity);
        FindObjectOfType<CameraShake>().Begin(this.camRumbleIntensity, this.camRumbleSpeed, this.camRumbleDuration);
        danceManager.EnableNextDanceKey();
        Destroy(this.gameObject);
    }

    // deactivates Rhythm mode, puts player into Platformer mode
    protected void StartPlatformMode() {
        this.levelManager.SetPlayerMode("Platformer"); // sets correct player mode
        this.levelManager.playerCamMoveSpeed = playerRunningSpeed; //  sets player and camera speed 
        Parallax.multiplier = surroundingSpeedMultiplier; // sets how fast objects should move in background
        this.levelManager.UpdateSpeeds();
        this.danceManager.enabled = false;

        if (interpolationTrigger != null) {
            this.interpolationTrigger.StartInterpolateObjects();

        } else {
            Debug.LogError("No Object to interpolate selected");
        }
    }

    // Called on first frame
    protected virtual void Start() {
        perfectInARow = 0;
        this.player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        this.characterHealth = FindObjectOfType<CharacterHealth>();
        this.perfectStreakTextManager = FindObjectOfType<PerfectStreakTextManager>();
        this.danceManager = FindObjectOfType<danceTileManager>();
        scorePopUpParent = UIManager.Instance.GetScorePopUpParent();
    }
}
