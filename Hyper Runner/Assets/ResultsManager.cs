using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class keeps track of the current result of a level. Is used for "ResultsScreen" scene
public static class ResultsManager {

    private static int countPlayerCrash; // how many times the player has run into an obstacle
    private static int countMissedDanceTiles; // how many times the player has missed a dance tile
    private static int countNonPerfectTiles; // how many times the player has not gotten a "perfect" tile

    // Start is called before the first frame update
    public static void init() {
        countPlayerCrash = 0;
        countMissedDanceTiles = 0;
        countNonPerfectTiles = 0;
    }

    // When a player has run into an obstacle
    // EFFECT: increments playre crash by 1
    public static void IncPlayerCrash() {
        countPlayerCrash++;
    }

    // When a player misses a dance tile
    // EFFECT: increments player missed dance tile, also incremements non perfect tiles
    public static void IncMissedDanceTiles() {
        countMissedDanceTiles++;
        countNonPerfectTiles++;
    }

    // When a player does not score "Perfect" on a 
    // EFFECT: increments player non perfect tiles
    public static void IncNonPerfectTiles() {
        countNonPerfectTiles++;
    }
}
