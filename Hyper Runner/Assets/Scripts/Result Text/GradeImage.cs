using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// displays the final grade of your game
public class GradeImage : AResultText {
    [SerializeField] private Image imageComponent;
    [SerializeField] private Sprite[] grades; // all possible grade images
    [SerializeField] private float delayBetweenShuffle = .2f; // delay between shuffle images
    public int gradeEarned; // the grade earned by player, calculated with ResultsManager

    // called on first frame
    void Start() {
        this.imageComponent.enabled = false;
        this.gradeEarned = CalculateGrade();
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
        for (int i = 0; i < 30; i++) {
            lastIndex = ShowRandomGrade(lastIndex);
            yield return new WaitForSeconds(this.delayBetweenShuffle);
        }
        FindObjectOfType<AudioManager>().Play("Click");
        this.imageComponent.sprite = this.grades[gradeEarned];
        this.ActivateNext();
    }

    // EFFECT: displays a random grade,
    // returns index of the grade displayed
    int ShowRandomGrade(int lastIndex) {
        int randNum;
        do {
            randNum = Random.Range(0, this.grades.Length);
        } while (randNum == lastIndex);

        this.imageComponent.sprite = this.grades[randNum];
        FindObjectOfType<AudioManager>().Play("Click");//
        return randNum;
    }

    // returns grade earned for current run
    // TODO: create this method with good weights, for right it is limited to either earn P or F... 
    int CalculateGrade() {
        int normalScore = ResultsManager.GetMissedDanceTiles() + ResultsManager.GetPlayerCrashes();
        if (normalScore == 0) {
            return 0;
        } else {
            return this.grades.Length;
        }
    }
}
