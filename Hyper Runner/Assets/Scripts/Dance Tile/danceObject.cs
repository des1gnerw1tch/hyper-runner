using UnityEngine;
using System;

// Normal Dance Tile, press a key to interact
public class danceObject : ADanceObject {

    void Update() {
        // despawn object if missed
        if ((player.position.x - transform.position.x) >= distanceUntilDestroy) {
            this.EvaluateScore(0);

            if (this.isLastTileInSequence) {
                this.StartPlatformMode();
            }

            this.DestroyDanceTile();
        }
    }

    // When a dance key is pressed
    protected override void KeyPressedCorrectly() 
    {
        float difference = Mathf.Abs(player.position.x - transform.position.x);
        score = 10 - difference;
        if (score < 0)
            score = 0;

        this.EvaluateScore(score);
        CheckIfLastTile();
        this.DestroyDanceTile();
    }

    protected override void KeyPressedIncorrectly()
    {
        this.EvaluateScore(0);
        CheckIfLastTile();
        this.DestroyDanceTile();
    }
    
    private void CheckIfLastTile() {
        if (this.isLastTileInSequence) {
            this.StartPlatformMode();
        }
    }
}
