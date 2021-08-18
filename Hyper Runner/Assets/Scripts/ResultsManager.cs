using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this class keeps track of the current result of a level. Is used for "ResultsScreen" scene
public static class ResultsManager {

    private static int countPlayerCrash; // how many times the player has run into an obstacle
    private static int countMissedDanceTiles; // how many times the player has missed a dance tile
    private static int countOkTiles; // amount of Okay's player received during game
    private static int countGoodTiles; // amount of Good's player received during game
    private static int countPerfectTiles; // amount of Perfect's player received during game
    private static int countTotalDanceTiles; // total tiles in the game

    // Start is called before the first frame update
    public static void init() {
        countPlayerCrash = 0;
        countMissedDanceTiles = 0;
        countOkTiles = 0;
        countGoodTiles = 0;
        countPerfectTiles = 0;
        countTotalDanceTiles = 0;
    }

    // When a player has run into an obstacle
    // EFFECT: increments player crash by 1
    public static void IncPlayerCrash() {
        countPlayerCrash++;
    }

    // When a player misses a dance tile
    public static void IncMissedDanceTiles() {
        countMissedDanceTiles++;
    }

    // When a player scores "Okay" rating on dance tile
    public static void IncOkTiles() {
        countOkTiles++;
    }

    // When a player scores "Good" rating on dance tile
    public static void IncGoodTiles() {
        countGoodTiles++;
    }

    // When player score "Perfect" on a dance tile
    public static void IncPerfectTiles() {
        countPerfectTiles++;
    }

    // When a player hits any dance tile
    // EFFECT: increments total tiles
    public static void IncTotalDanceTiles() {
        countTotalDanceTiles++;
    }

    // Debugs stats from a game
    public static void PrintResults() {
        Debug.Log("Platform Mode Crashes: " + GetPlayerCrashes());
        Debug.Log("Total Tiles: " + GetTotalTiles());
        Debug.Log("Missed Tiles:  " + GetMissedDanceTiles());
        Debug.Log("Ok Tiles: " + GetOkTiles());
        Debug.Log("Good Tiles: " + GetGoodTiles());
        Debug.Log("Perfect Tiles: " + GetPerfectTiles());
    }

    // Getters
    public static int GetPlayerCrashes() {
        return countPlayerCrash;
    }

    public static int GetMissedDanceTiles() {
        return countMissedDanceTiles;
    }

    public static int GetOkTiles() {
        return countOkTiles;
    }

    public static int GetGoodTiles() {
        return countGoodTiles;
    }

    public static int GetPerfectTiles() {
        return countPerfectTiles;
    }

    public static int GetTotalTiles() {
        return countTotalDanceTiles;
    }


}
