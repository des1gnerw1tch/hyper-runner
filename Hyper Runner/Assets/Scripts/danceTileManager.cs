using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// handles activating dance tiles, the once closest to the player
public class danceTileManager : MonoBehaviour
{
  [SerializeField] private Transform player;
  [SerializeField] private IDanceObject activeDanceObj; // is mutated on by dance key movement on player

  // TODO: for keyboard input, will change to newer input system later
  void Update() {
    // Will update active dance key, on KeyUp because want to make sure
    // first object when clicked is deleted first (which is on KeyDown)
    // TODO: update these keyboard controlls to new input system
    if (Input.GetKeyUp("up") || Input.GetKeyUp("down")) {
      UpdateValidDanceKeys();
    }
  }
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
  void enableDanceKey(GameObject obj)  {
    this.activeDanceObj = obj.GetComponent<IDanceObject>();
    try {
      obj.GetComponent<danceObject>().active = true;
    } catch {
      //Debug.Log("Object was not single key");
    }

    try {
      obj.GetComponent<holdDanceObject>().active = true;
    } catch {
      //Debug.Log("Object was not hold key");
    }
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
  public void OnAnyDanceKeyPress()  {
    //UpdateValidDanceKeys();
    activeDanceObj.OnAnyDanceKeyPress();
  }

}
