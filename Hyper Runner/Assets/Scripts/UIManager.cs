using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Deals with setting up scene transitions and user interface
 */
public class UIManager : MonoBehaviour {

    [SerializeField] private GameObject pauseScreen;
    private bool isGamePaused;

    [Header("Required Prefab in Scene, automatically fetched")]
    [SerializeField] private MusicSync musicSync;

    // Start is called before the first frame update
    void Start() {
        this.Init();
    }

    // Set up class fields
    void Init() {
        this.pauseScreen.SetActive(false); // disable pause screen at beginning of game
        this.isGamePaused = false;

        // tells LoadArcadeScene to load settings based on THIS scene
        LoadArcadeScene.sceneFrom = SceneManager.GetActiveScene().name;

        this.musicSync = FindObjectOfType<MusicSync>();
    }

    // When a pause key is pressed
    public void PauseKeyPressed() {
        if (this.isGamePaused) {
            this.ResumeGame();
        } else {
            this.PauseGame();
        }

        //this.isGamePaused = !this.isGamePaused;
    }

    // Pauses the game by enabling pause screen, makes sure game is in paused state as well
    void PauseGame() {
        this.musicSync.PauseMusic();
        Time.timeScale = 0f;
        this.pauseScreen.SetActive(true);
        this.isGamePaused = true;
    }

    // Resumes the game if paused
    public void ResumeGame() {
        this.musicSync.ResumeMusic();
        Time.timeScale = 1f;
        this.pauseScreen.SetActive(false);
        this.isGamePaused = false;
    }

    // When player wants to exit game
    public void ExitGame() {
        Time.timeScale = 1f;
        //  LoadArcadeScene.sceneFrom = SceneManager.GetActiveScene().name; // tells LoadArcadeScene to load
        // settings based on THIS scene
        SceneManager.LoadScene("Menu"); // load the arcade machine scene, exits this game
    }
}
