using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public static ProgressBar Instance { get; private set; }
    
    [SerializeField] private Slider progressBar;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void UpdateProgress(float progress)
    {
        if (progress < 0 || progress > 1)
        {
            Debug.LogError("Progress was not between 0-1, cannot update slider");
            return;
        }

        progressBar.value = progress;
    }
}
