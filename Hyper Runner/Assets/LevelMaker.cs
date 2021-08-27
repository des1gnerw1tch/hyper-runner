using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is a DEV only tool which helps place items that match up with beat!
public class LevelMaker : MonoBehaviour {
    [SerializeField] private GameObject marker;

    // called every frame
    private void Update() {
        if (Input.GetKeyDown("x")) { // Old input system
            GameObject instance = Instantiate(this.marker);
            instance.transform.position = transform.position;
        }
    }
}
