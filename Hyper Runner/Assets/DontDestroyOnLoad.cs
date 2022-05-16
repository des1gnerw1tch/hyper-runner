using UnityEngine;

/// <summary>
/// Should only be attached to a single game object in the menu scene. Holds managers that should be persistent throughout all scenes.
/// </summary>
public class DontDestroyOnLoad : MonoBehaviour
{
    void Awake()
    {
        if (FindObjectsOfType<DontDestroyOnLoad>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }
}
