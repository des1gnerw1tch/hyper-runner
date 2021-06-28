using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : AResultText {
    [SerializeField] private TextMeshProUGUI tmp; // text mesh pro of this object
    [SerializeField] private float countAnimDelay; // delay between each number displayed when counting
    public int score; // final score to be displayed

    void Start() {
        this.tmp.enabled = false;
    }

    // displays score of 
    public override void Activate() {
        this.tmp.enabled = true;
        StartCoroutine("CountAnim");
    }

    // will display score by displaying numbers counting up to final score...
    IEnumerator CountAnim() {
        for (int i = 0; i <= this.score; i += 10) {
            this.tmp.SetText(i + ""); // converts to string
            yield return new WaitForSeconds(this.countAnimDelay);
            if (i % 100 == 0) { // play click on every other score
                FindObjectOfType<AudioManager>().Play("Click", 1 + ((float)i / 1000));
            }

        }
        FindObjectOfType<AudioManager>().ResetPitch("Click"); // reset pitch of click
        this.ActivateNext(); // activate next object
    }
}
