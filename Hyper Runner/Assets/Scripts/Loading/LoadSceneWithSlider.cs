using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Loading
{
    // Loads a scene on start with a slider with loading progress. 
    public class LoadSceneWithSlider : MonoBehaviour
    {
        [SerializeField] private string sceneName;
        [SerializeField] private Slider progressBar;
        [SerializeField] private TextMeshProUGUI loadingPercent;
        private void Start()
        {
            StartCoroutine(LoadSceneAsync());
            progressBar.value = 0;
        }

        private IEnumerator LoadSceneAsync()
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);

            while (!operation.isDone)
            {
                float progressValue = Mathf.Clamp01(operation.progress / 0.9f);
                loadingPercent.text = (progressValue * 100)  + "%";
                progressBar.value = progressValue;
                yield return null;
            }
        }
    }
}
