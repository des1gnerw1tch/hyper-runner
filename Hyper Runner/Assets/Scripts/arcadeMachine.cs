using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class arcadeMachine : MonoBehaviour, IInteractableArcadeObject {
    [SerializeField] private GameObject playerCam;
    [SerializeField] private GameObject animCam;
    [SerializeField] private Animator animCamAnimator;
    [SerializeField] private GameObject backlight;
    [SerializeField] private GameObject popUpText;
    [SerializeField] private string sceneToLoad;

    void Start() {
        /*playerCam.SetActive(true);
        animCam.SetActive(false);
        backlight.SetActive(false);
        popUpText.SetActive(false);
        animationPlaying = false;*/
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            popUpText.SetActive(true);
            other.gameObject.GetComponent<InteractArcade>().SetCurrentInteractable(this);
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            popUpText.SetActive(false);
            other.gameObject.GetComponent<InteractArcade>().ClearCurrentInteractable();
        }
    }

    // Loads the scene the arcade game is linked to 
    public void LoadGameScene() {
        Cursor.lockState = CursorLockMode.None; // so that we can use cursor in main game
        SceneManager.LoadScene(this.sceneToLoad);
    }

    // When player interacts with this arcade object
    public void Interact(InteractArcade player) {
        player.ClearCurrentInteractable();
        // start animation
        playerCam.SetActive(false);
        animCam.SetActive(true);
        animCamAnimator.SetTrigger("PanIntoMachine");
        backlight.SetActive(true);
        popUpText.SetActive(false);
    }
}
