using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// will trigger an object / objects to start interpolating!
public class InterpolateTrigger : MonoBehaviour {
    [SerializeField] private AInterpolateColor[] objectsToInterpolate; // what objects should we interpolate
    [SerializeField] private Color[] colorsToInterpolate; // what colors should these objects be?
    [SerializeField] private float speedToInterpolate; // what speed should we interpolate this object
    [SerializeField] private bool shouldRainbowMash = false; // should rainbow mash objects?

    // Starts interpolating or rainbow mashing objects
    public void StartInterpolateObjects() {
        for (int i = 0; i < objectsToInterpolate.Length; i++) {
            if (this.shouldRainbowMash) {
                this.objectsToInterpolate[i].RainbowMash(speedToInterpolate);
            } else {
                this.objectsToInterpolate[i].Lerp(speedToInterpolate, this.colorsToInterpolate[i]);
            }
        }

    }
}
