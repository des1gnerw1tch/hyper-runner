using SaveFileSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace InteractableArcade
{
    public class arcadeMachine : AInteractableArcadeObject
    {
        [SerializeField] private GameObject playerCam;
        [SerializeField] private GameObject animCam;
        [SerializeField] private Animator animCamAnimator;
        [SerializeField] private GameObject backlight;
        [SerializeField] private string sceneToLoad;
        [SerializeField] private Transform machineSpawnPosition; // first machine position to spawn player at
        
        // This machine is locked until this level is completed with at least a B score.
        [SerializeField] private string levelThatMustBeCompletedBeforeThisOne;
        [SerializeField] private bool lockEnabled;

        // Loads the scene the arcade game is linked to 
        public void LoadGameScene()
        {
            Cursor.lockState = CursorLockMode.None; // so that we can use cursor in main game
            SceneManager.LoadScene(this.sceneToLoad);
        }

        // When player interacts with this arcade object
        public override void Interact(InteractArcade player)
        {
            base.Interact(player);
            if (lockEnabled)
            {
                LevelGrade? grade = GameDataManager.Instance.GetLevelHighScore(levelThatMustBeCompletedBeforeThisOne);
                if (!grade.HasValue)
                {
                    Debug.LogError("Grade should not be null. Letting player play level.");
                } 
                else if (grade == LevelGrade.NeverCompleted && lockEnabled)
                {
                    FindObjectOfType<AudioManager>().Play("characterLocked");
                    // TODO: Some feedback that this level is locked....... Maybe a dialogue popup?
                    Debug.Log("TODO: Add some feedback that this level is locked....... Maybe a dialogue popup?");
                    return;
                }
            }
            
            player.ClearCurrentInteractable();
            // start animation
            playerCam.SetActive(false);
            animCam.SetActive(true);
            animCamAnimator.SetTrigger("PanIntoMachine");
            backlight.SetActive(true);
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
}
