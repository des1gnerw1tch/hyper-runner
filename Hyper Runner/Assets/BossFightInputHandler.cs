using UnityEngine;

public class BossFightInputHandler : MonoBehaviour
{
    private void OnMoveUp()
    {
        Debug.Log("OnMoveUp pressed");
    }
    
    private void OnMoveDown()
    {
        Debug.Log("OnMoveDown pressed");
    }

    private void OnPhaseOut()
    {
        Debug.Log("OnPhaseOut pressed");
    }
}
