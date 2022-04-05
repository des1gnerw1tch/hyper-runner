using UnityEngine;
using UnityEngine.SceneManagement;

// Proceeds to a scene when clicked the select button. 
public class ClickSelectToProceed : MonoBehaviour
{
    // Called from PlayerInput
    private void OnSelect()
    {
        SceneManager.LoadScene("Menu");
    }
}
