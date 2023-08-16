using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

// This is a DEV only tool which helps place items that match up with beat!
public class LevelMaker : MonoBehaviour {
    [FormerlySerializedAs("marker")][SerializeField] private GameObject markerWhenPressX;
    [SerializeField] private GameObject markerForTrail;

    private bool trailActive = false;
    // called every frame
    private void Update() {
        if (Input.GetKeyDown("x")) { // Old input system
            GameObject instance = Instantiate(this.markerWhenPressX);
            instance.transform.position = transform.position;
        }

        if (Input.GetKeyDown("q"))
        {
            this.trailActive = !this.trailActive;
        }

        if (trailActive)
        {
            
        }
    }
}
