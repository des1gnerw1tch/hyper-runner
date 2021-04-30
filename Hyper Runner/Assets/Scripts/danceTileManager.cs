using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// handles activating dance tiles, the once closest to the player
public class danceTileManager : MonoBehaviour
{
  void Update() {
    // Will update active dance key, on KeyUp because want to make sure
    // first object when clicked is deleted first (which is on KeyDown)
    if (Input.GetKeyUp("up") || Input.GetKey("down")) {
      UpdateValidDanceKeys();
    }
  }

  //Makes sure that only 1 dance key is okay to press at one time
  void UpdateValidDanceKeys() {
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
      closest.GetComponent<danceObject>().active = true;
    }
  }
}
