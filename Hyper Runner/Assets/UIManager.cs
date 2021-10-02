using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Deals with setting up scene transitions and user interface
 */
public class UIManager : MonoBehaviour {

    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private MusicSync musicSync;
    private bool isGamePaused;

    // Start is called before the first frame update
    void Start() {
        this.Init();
    }

    // Set up class fields
    void Init() {
        this.pauseScreen.SetActive(false); // disable pause screen at beginning of game
        this.isGamePaused = false;
    }

    // When a pause key is pressed
    public void PauseKeyPressed() {
        if (this.isGamePaused) {
            this.ResumeGame();
        } else {
            this.PauseGame();
        }

        this.isGamePaused = !this.isGamePaused;
    }

    // Pauses the game by enabling pause screen, makes sure game is in paused state as well
    void PauseGame() {
        this.musicSync.PauseMusic();
        Time.timeScale = 0f;
        this.pauseScreen.SetActive(true);
    }

    // Resumes the game if paused
    void ResumeGame() {
        this.musicSync.ResumeMusic();
        Time.timeScale = 1f;
        this.pauseScreen.SetActive(false);
    }
}
