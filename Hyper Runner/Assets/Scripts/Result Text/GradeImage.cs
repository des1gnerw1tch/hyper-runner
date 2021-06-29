using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// displays the final grade of your game
public class GradeImage : AResultText {
    [SerializeField] private Image imageComponent;
    [SerializeField] private Sprite[] grades; // all possible grade images
    [SerializeField] private float delayBetweenShuffle = .2f; // delay between shuffle images
    [SerializeField] private ResultsAnimationController controller;
    [SerializeField] private Animator charismaAnimator;
    public int gradeEarned; // the grade earned by player, calculated with ResultsManager
    private bool isHighScore; // is grade earned a high score

    // called on first frame
    void Start() {
        this.imageComponent.enabled = false;
        this.gradeEarned = CalculateGrade();
        this.isHighScore = true; // TODO: display high score if this is saved as a high score
    }

    // EFFECT: enables image component 
    public override void Activate() {
        this.imageComponent.enabled = true;
        StartCoroutine("Shuffle");
    }

    // EFFECT: displays random grade images, then displays correct grade, like a casino
    // makes sure that two grades don't pop up in a row, disrupting flow
    IEnumerator Shuffle() {
        int lastIndex = 0;
        for (int i = 0; i < 10; i++) {
            lastIndex = ShowRandomGrade(lastIndex);
            yield return new WaitForSeconds(this.delayBetweenShuffle);
        }
        // at the end of the shuffle, show earned grade
        this.ShowEarnedGrade();
    }

    // EFFECT: displays a random grade,
    // returns index of the grade displayed
    int ShowRandomGrade(int lastIndex) {
        int randNum;
        do {
            randNum = Random.Range(0, this.grades.Length);
        } while (randNum == lastIndex);

        this.imageComponent.sprite = this.grades[randNum];
        FindObjectOfType<AudioManager>().Play("Click");
        return randNum;
    }

    // returns grade earned for current run
    // TODO: create this method with good weights, for right it is limited to either earn P or F... 
    int CalculateGrade() {
        float totalTiles = (float)ResultsManager.GetTotalTiles();
        float nonPerfectTiles = (float)ResultsManager.GetNonPerfectTiles();
        float missedTiles = (float)ResultsManager.GetMissedDanceTiles();

        float perfectRatio = (totalTiles - nonPerfectTiles)
            / totalTiles;
        Debug.Log("Perfect Ratio: " + perfectRatio);
        float hitRatio = (totalTiles - missedTiles)
            / totalTiles;
        Debug.Log("Hit Ratio: " + hitRatio);

        if (perfectRatio > .70 && ResultsManager.GetPlayerCrashes() == 0) {
            return 0;
        } else if (hitRatio > .80 && ResultsManager.GetPlayerCrashes() <= 2) {
            return 1;
        } else if (hitRatio > .70 && ResultsManager.GetPlayerCrashes() <= 4) {
            return 2;
        } else if (hitRatio > .60 && ResultsManager.GetPlayerCrashes() <= 6) {
            return 3;
        } else {
            return 4;
        }
    }

    // shows the earned grade of the player, handles high score or not
    // EFFECT: changes sprite of this image
    void ShowEarnedGrade() {
        FindObjectOfType<AudioManager>().Play("Click");

        this.imageComponent.sprite = this.grades[gradeEarned];
        int happyRating = (4 - gradeEarned);
        if (happyRating < 3) {
            this.isHighScore = false;
        }

        if (this.isHighScore) {
            this.controller.DisplayHighScore();
            FindObjectOfType<AudioManager>().Play("Yay");
        }

        this.charismaAnimator.SetTrigger(happyRating + "");
    }
}
