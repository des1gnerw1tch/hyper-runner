using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultsManager : MonoBehaviour {

    private int countPlayerCrash; // how many times the player has run into an obstacle
    private int countMissedDanceTiles; // how many times the player has missed a dance tile
    private int countNonPerfectTiles; // how many times the player has not gotten a "perfect" tile

    // Start is called before the first frame update
    void Start() {
        this.countPlayerCrash = 0;
        this.countMissedDanceTiles = 0;
        this.countNonPerfectTiles = 0;
    }

    // When a player has run into an obstacle
    // EFFECT: increments playre crash by 1
    public void IncPlayerCrash() {
        this.countPlayerCrash++;
    }

    // When a player misses a dance tile
    // EFFECT: increments player missed dance tile, also incremements non perfect tiles
    public void IncMissedDanceTiles() {
        this.countMissedDanceTiles++;
        this.countNonPerfectTiles++;
    }

    // When a player does not score "Perfect" on a 
    // EFFECT: increments player non perfect tiles
    public void IncNonPerfectTiles() {
        this.countNonPerfectTiles++;
    }
}
