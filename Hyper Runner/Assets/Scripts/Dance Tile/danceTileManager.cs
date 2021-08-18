using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// handles activating dance tiles, the once closest to the player
public class danceTileManager : MonoBehaviour {
    [SerializeField] private Transform player;
    [SerializeField] private IDanceObject activeDanceObj; // is mutated on by dance key movement on player

    //Makes sure that only 1 dance key is okay to press at one time
    // finds dance key with smallest X position and activates it...
    public void UpdateValidDanceKeys() {
        //finding closest active DanceTile object
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DanceTile");
        if (objs.Length != 0) {
            GameObject closest = objs[0];
            foreach (GameObject obj in objs) {
                if (obj.gameObject.GetComponent<Transform>().position.x < closest.GetComponent<Transform>().position.x) {
                    closest = obj;
                }
            }
            // Makes closest DanceTile object active
            enableDanceKey(closest);
        }
    }

    //this function will activate the closest dance key in the list that is
    // IN FRONT of the player
    public void ActivateNextFowardKey() {
        //finding closest active DanceTile object
        GameObject[] objs = GameObject.FindGameObjectsWithTag("DanceTile");
        if (objs.Length != 0) {
            GameObject closest = objs[0];
            foreach (GameObject obj in objs) {
                float keyPos = obj.gameObject.GetComponent<Transform>().position.x;
                float playerPos = player.position.x;
                if (keyPos > playerPos && closest.transform.position.x < playerPos) {
                    closest = obj; // case where current closest is behind player
                } else if (keyPos > playerPos && keyPos < closest.transform.position.x) {
                    closest = obj;
                }
            }
            // Makes closest DanceTile object active
            enableDanceKey(closest);

        }
    }

    // enables a dance key to receive input
    void enableDanceKey(GameObject obj) {
        this.activeDanceObj = obj.GetComponent<IDanceObject>();
    }

    // INPUTS
    public void OnUpDanceKeyPress() {
        activeDanceObj.OnUpDanceKeyPress();
    }

    public void OnUpDanceKeyRelease() {
        UpdateValidDanceKeys();
        activeDanceObj.OnUpDanceKeyRelease();
    }

    public void OnDownDanceKeyPress() {
        activeDanceObj.OnDownDanceKeyPress();
    }

    public void OnDownDanceKeyRelease() {
        UpdateValidDanceKeys();
        activeDanceObj.OnDownDanceKeyRelease();
    }

    public void OnLeftDanceKeyPress() {
        activeDanceObj.OnLeftDanceKeyPress();
    }

    public void OnLeftDanceKeyRelease() {
        UpdateValidDanceKeys();
        activeDanceObj.OnLeftDanceKeyRelease();
    }

    public void OnRightDanceKeyPress() {
        activeDanceObj.OnRightDanceKeyPress();
    }

    public void OnRightDanceKeyRelease() {
        UpdateValidDanceKeys();
        activeDanceObj.OnRightDanceKeyRelease();
    }

    public void OnAnyDanceKeyPress() {
        activeDanceObj.OnAnyDanceKeyPress();
    }

}
