using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlashWarningScene : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float delayBeforeLoadNextScene;
    void Start()
    {
        StartCoroutine(GoToLoadingScene());
    }

    private IEnumerator GoToLoadingScene()
    {
        yield return new WaitForSeconds(delayBeforeLoadNextScene);
        SceneManager.LoadScene("Loading");
    }
}
