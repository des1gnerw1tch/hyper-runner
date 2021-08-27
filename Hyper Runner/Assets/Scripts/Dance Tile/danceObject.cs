using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// Normal Dance Tile, press a key to interact
public class danceObject : ADanceObject {

    // on first frame
    public override void Start() {
        base.Start(); // from ADanceObject
        player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        characterHealth = FindObjectOfType<CharacterHealth>();
    }

    void Update() {
        // despawn object if missed
        if ((player.position.x - transform.position.x) >= distanceUntilDestroy) {
            try {
                FindObjectOfType<danceTileManager>().ActivateNextFowardKey();
            }
            catch (Exception e) {
                Debug.Log("tried to access dance tile manager when it was deactivated");
            }
            this.EvaluateScore(0);

            if (this.isLastTileInSequence) {
                this.StartPlatformMode();
            }

            this.DestroyDanceTile();
        }
    }

    // When a dance key is pressed
    public override void Pressed(string key) {

        if (this.keyToPress == key) { // if key pressed is correct
            float difference = Mathf.Abs(player.position.x - transform.position.x);
            score = 10 - difference;
            if (score < 0)
                score = 0;

            this.EvaluateScore(score);
            CheckIfLastTile();
            this.DestroyDanceTile();
        } else { // if key pressed is not correct
            this.EvaluateScore(0);
            CheckIfLastTile();
            this.DestroyDanceTile();
        }

        // LOCAL: if is the last tile in the game, switch player to platform mode
        void CheckIfLastTile() {
            if (this.isLastTileInSequence) {
                this.StartPlatformMode();
            }
        }

    }
}
