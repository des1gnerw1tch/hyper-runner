using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class WinCollider : MonoBehaviour {
    [SerializeField] private Animator blackScreen;
    [SerializeField] private float waitTime;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            blackScreen.SetTrigger("activate");
            this.StartCoroutine("LoadResults");
        }
    }

    private IEnumerator LoadResults() {
        yield return new WaitForSeconds(this.waitTime);
        SceneManager.LoadScene("ResultsScreen");
    }
}
