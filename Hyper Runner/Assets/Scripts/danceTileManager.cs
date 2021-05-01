using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// handles activating dance tiles, the once closest to the player
public class danceTileManager : MonoBehaviour
{
  [SerializeField] private Transform player;
  void Update() {
    // Will update active dance key, on KeyUp because want to make sure
    // first object when clicked is deleted first (which is on KeyDown)
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

  void enableDanceKey(GameObject obj)  {
    try {
      obj.GetComponent<danceObject>().active = true;
    } catch {
      Debug.Log("Object was not single key");
    }

    try {
      obj.GetComponent<holdDanceObject>().active = true;
    } catch {
      Debug.Log("Object was not hold key");
    }
  }

}
