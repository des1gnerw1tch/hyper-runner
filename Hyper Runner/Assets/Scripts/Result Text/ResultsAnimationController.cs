using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsAnimationController : MonoBehaviour {
    [SerializeField] private GameObject blackScreenPanel;
    [SerializeField] private AResultText first;
    [SerializeField] private ScoreText mobilityScore;
    [SerializeField] private ScoreText rhythmScore;
    [SerializeField] private GameObject highScoreText;
    [SerializeField] private GradeImage gradeImage;
    private int gradeEarned; // grade earned for this game, 0 is P while 4 is F

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
        float totalTiles = (float)ResultsManager.GetTotalTiles();
        float okTiles = (float)ResultsManager.GetOkTiles();
        float goodTiles = (float)ResultsManager.GetGoodTiles();
        float perfectTiles = (float)ResultsManager.GetPerfectTiles();
        float missedTiles = (float)ResultsManager.GetMissedDanceTiles();

        // this crazy math makes a score, somewhere in the 1000 range
        // the longer the level (more tiles) and the least crashes, gives the most points.
        int mobilityScoreTemp = 2500 - ResultsManager.GetPlayerCrashes() * 313; // can die 8 times before score is 0
        if (mobilityScoreTemp < 0) {
            this.mobilityScore.score = 0;
        } else {
            this.mobilityScore.score = mobilityScoreTemp;
        }

        // score for rhythm
        // full credit awarded for perfect tile, 80% credit awarded for good tile, 60% credit awarded for
        // okay tile, 0% credit awarded for missed tile
        float rawScore = perfectTiles + 0.8f * goodTiles + 0.6f * okTiles;
        float fracScore = rawScore / totalTiles; // how well you did out of the max score, a score of 1 is perfect,
                                                 // while a score of 0 means you got no dance tiles
        Debug.Log("Frac Rhythm Score: " + fracScore);

        int weightedScore = (int)Mathf.Ceil(250 * fracScore) * 10; // max score is 100
        this.rhythmScore.score = weightedScore;

        // grade earned calculation, mixing Rhythm score and mobility score
        // if player crashes, subtract .05 points for each one
        float fracScoreWithCrashes = fracScore - ResultsManager.GetPlayerCrashes() * .05f;
        Debug.Log("Frac Rhythm Score with Crashes" + fracScoreWithCrashes);

        // for P grade, hypothetically player scores only perfects and goods, but more perfects then goods
        // player can also not crash...
        // can crash 8 times before score is automatic F
        if (fracScoreWithCrashes >= .90 && ResultsManager.GetPlayerCrashes() == 0) {
            this.gradeEarned = 0; // P
        } else if (fracScoreWithCrashes >= .80) { // better than "good" average
            this.gradeEarned = 1; // A
        } else if (fracScoreWithCrashes >= .7) { // better than inbetween Good and Okay average, more Goods than Okay's
            this.gradeEarned = 2; // B
        } else if (fracScoreWithCrashes >= .6) { // better than Okay average
            this.gradeEarned = 3; // C
        } else { // worse than okay average
            this.gradeEarned = 4;
        }

        this.gradeImage.gradeEarned = this.gradeEarned;
    }

}
