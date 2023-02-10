using System.Collections;
using SaveFileSystem;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Displays the final grade of your game
public class GradeImage : AResultText {
    [SerializeField] private Image imageComponent;
    [SerializeField] private Sprite[] grades; // all possible grade images
    [SerializeField] private float delayBetweenShuffle = .2f; // delay between shuffle images
    [SerializeField] private ResultsAnimationController controller;
    [SerializeField] private Animator charismaAnimator;
    [SerializeField] private GameObject clickToProceedToMenuText;
    [HideInInspector] public int gradeEarned; // the grade earned by player, calculated with ResultsManager

    // called on first frame
    void Start() {
        this.imageComponent.enabled = false;
        clickToProceedToMenuText.SetActive(false);
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

    //TODO: This is a test
    // Will shift character to main scene
    private void EndScene() {
        SceneManager.LoadScene("Menu");
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

    // shows the earned grade of the player, handles high score or not
    // EFFECT: changes sprite of this image
    void ShowEarnedGrade() {
        FindObjectOfType<AudioManager>().Play("Click");

        this.imageComponent.sprite = this.grades[this.gradeEarned];

        if (GameDataManager.Instance.ShouldSetLevelHighScore(LoadArcadeScene.sceneFrom, (LevelGrade) this.gradeEarned)) {
            this.controller.DisplayHighScore();
            FindObjectOfType<AudioManager>().Play("Yay");
        }

        if (this.gradeEarned == 0) {
            this.charismaAnimator.SetTrigger("4");
        } else if (this.gradeEarned == 1 || this.gradeEarned == 2) {
            this.charismaAnimator.SetTrigger("3");
        } else if (this.gradeEarned == 3) {
            this.charismaAnimator.SetTrigger("2");
        } else if (this.gradeEarned == 4) {
            this.charismaAnimator.SetTrigger("1");
        } else {
            throw new System.Exception("Grade earned out of bounds");
        }

        StartCoroutine("ShowClickToProceedToMenuText");
    }

    private IEnumerator ShowClickToProceedToMenuText()
    {
        yield return new WaitForSeconds(3f);
        clickToProceedToMenuText.SetActive(true);
    }
}
