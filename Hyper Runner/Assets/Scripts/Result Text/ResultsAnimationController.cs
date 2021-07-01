using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsAnimationController : MonoBehaviour {
    [SerializeField] private GameObject blackScreenPanel;
    [SerializeField] private AResultText first;
    [SerializeField] private ScoreText mobilityScore;
    [SerializeField] private ScoreText rhythmScore;
    [SerializeField] private GameObject highScoreText;

    private void Start() {
        blackScreenPanel.SetActive(true);
        this.SetScores();
        this.first.Activate();
        this.highScoreText.SetActive(false);
        ResultsManager.PrintResults();
    }

    // displays high score, along with some sounds
    public void DisplayHighScore() {
        this.highScoreText.SetActive(true);
    }

    // sets the scores for mobility and rhythm 
    void SetScores() {
        // TODO: Also calculate grade image here, would be cleaner (right now calculates in own script
        float totalTiles = (float)ResultsManager.GetTotalTiles();
        float nonPerfectTiles = (float)ResultsManager.GetNonPerfectTiles();
        float missedTiles = (float)ResultsManager.GetMissedDanceTiles();

        float perfectRatio = (totalTiles - nonPerfectTiles)
            / totalTiles;
        float hitRatio = (totalTiles - missedTiles)
            / totalTiles;

        // this crazy math makes a score, somewhere in the 1000 range
        // the longer the level (more tiles) and the least crashes, gives the most points.
        int mobilityScoreTemp = 2500 - ResultsManager.GetPlayerCrashes() * 500;
        if (mobilityScoreTemp < 0) {
            this.mobilityScore.score = 0;
        } else {
            this.mobilityScore.score = mobilityScoreTemp;
        }


        // score for rhythm
        int rhythmScoreTemp =
            (int)Mathf.Ceil(2500 - ((totalTiles - nonPerfectTiles) * 2) - (missedTiles * 3));
        if (rhythmScoreTemp < 0) {
            this.rhythmScore.score = 0;
        } else {
            this.rhythmScore.score = rhythmScoreTemp;

        }



    }

}
