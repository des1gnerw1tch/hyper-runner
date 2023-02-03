using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * Restarts the scene when the player presses the R key on a keyboard or the left trigger button on a gamepad. Players can
 * instantly restart this way if they messed up and want to get a high score. 
 */
public class RestartArcadeGameListener : MonoBehaviour
{
    // Called by PlayerInput
    private void OnRestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
