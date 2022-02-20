using UnityEngine;
using UnityEngine.SceneManagement;

public class arcadeMachine : MonoBehaviour, IInteractableArcadeObject {
    [SerializeField] private GameObject playerCam;
    [SerializeField] private GameObject animCam;
    [SerializeField] private Animator animCamAnimator;
    [SerializeField] private GameObject backlight;
    [SerializeField] private GameObject popUpText;
    [SerializeField] private string sceneToLoad;
    [SerializeField] private Transform machineSpawnPosition; // first machine position to spawn player at

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
    
    // When player exits this arcade machine
    public void ExitArcadeMachine(Transform player)
    {
        player.SetPositionAndRotation(machineSpawnPosition.position, Quaternion.identity);
        FindObjectOfType<FirstPersonCameraController>().RotatePlayer(machineSpawnPosition);
        this.animCam.SetActive(true);
        this.animCamAnimator.SetTrigger("PanOutOfMachine");
    }

    #region Getters
    
    public string GetSceneToLoad()
    {
        return sceneToLoad;
    }

    public GameObject GetAnimCam()
    {
        return animCam;
    }

    #endregion
    
}
