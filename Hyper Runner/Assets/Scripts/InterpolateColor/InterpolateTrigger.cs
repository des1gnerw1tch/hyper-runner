using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// will trigger an object / objects to start interpolating!
public class InterpolateTrigger : MonoBehaviour {
    [SerializeField] private AInterpolateColor[] objectsToInterpolate; // what objects should we interpolate
    [SerializeField] private float speedToInterpolate; // what speed should we interpolate this object
    [SerializeField] private bool shouldActivateOnCollideWithPlayer = false;
    
    [Header("Single color change")]
    [Tooltip("ex. i=0 in objectsToInterpolate will change to i=0 colorToInterpolate")]
    [SerializeField] private Color[] colorsToInterpolate; // what colors should these objects be?
    
    [Header("Continuous color change")]
    [Tooltip("All objects will continually mash between these colors")]
    [SerializeField] private bool shouldRainbowMash = false; // should rainbow mash objects?
    [SerializeField] private Color[] colorsToRainbowMash;
    
    // Starts interpolating or rainbow mashing objects
    public void StartInterpolateObjects() {
        for (int i = 0; i < objectsToInterpolate.Length; i++) {
            if (this.shouldRainbowMash) {
                this.objectsToInterpolate[i].RainbowMash(speedToInterpolate, colorsToRainbowMash);
            } else {
                this.objectsToInterpolate[i].Lerp(speedToInterpolate, this.colorsToInterpolate[i]);
            }
        }

    }

    //TODO: This is a somewhat messy way to do this. Maybe should have just made a class that when you collide calls the function in this class. 
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && shouldActivateOnCollideWithPlayer)
        {
            StartInterpolateObjects();
        }
    }
}
