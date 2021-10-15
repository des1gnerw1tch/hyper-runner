using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class arcadeMachine : MonoBehaviour {
    [SerializeField] private GameObject playerCam;
    [SerializeField] private GameObject animCam;
    [SerializeField] private Animator animCamAnimator;
    [SerializeField] private GameObject backlight;
    [SerializeField] private GameObject popUpText;
    [SerializeField] private string sceneToLoad;
    private bool animationPlaying;

    void Start() {
        playerCam.SetActive(true);
        animCam.SetActive(false);
        backlight.SetActive(false);
        popUpText.SetActive(false);
        animationPlaying = false;
    }

    void OnTriggerStay(Collider other) {
        if (other.CompareTag("Player") && Input.GetKeyDown("e") && !animationPlaying) {
            // start animation
            animationPlaying = true;
            playerCam.SetActive(false);
            animCam.SetActive(true);
            animCamAnimator.SetTrigger("PanIntoMachine");
            backlight.SetActive(true);
            popUpText.SetActive(false);
            Debug.Log("Worked");
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            popUpText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            popUpText.SetActive(false);
        }
    }

    // Loads the scene the arcade game is linked to 
    public void LoadGameScene() {
        Cursor.lockState = CursorLockMode.None; // so that we can use cursor in main game
        SceneManager.LoadScene(this.sceneToLoad);
    }
}
