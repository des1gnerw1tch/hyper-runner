using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsAnimationController : MonoBehaviour {
    [SerializeField] private AResultText first;
    [SerializeField] private GameObject highScoreText;

    private void Start() {
        this.first.Activate();
        this.highScoreText.SetActive(false);
        ResultsManager.PrintResults();
    }

    // displays high score, along with some sounds
    public void DisplayHighScore() {
        this.highScoreText.SetActive(true);
    }


}
