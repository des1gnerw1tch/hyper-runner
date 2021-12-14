using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will interpolate between original color and color of choice
public class InterpolateColor : MonoBehaviour {
    [SerializeField] private Camera mainCamera; // camera we will change the background color of
    private Color currentColor;
    private Color nextColor; // the color we should interpolate to
    private float interpolateSpeed; // how fast to interpolate
    private float counter; // clamped between 0,1 

    private void Start() {
        this.currentColor = this.mainCamera.backgroundColor;
    }

    void Update() {
        //sky interpolation
        if (interpolateSpeed > 0) { // Start interpolation
            counter += MusicSync.deltaSample * interpolateSpeed;
            Color c = Color.Lerp(currentColor, nextColor, counter);
            if (counter >= 1) { // fully interpolated
                interpolateSpeed = 0;
                this.currentColor = nextColor;
            }
            mainCamera.backgroundColor = c;
        }
    }

    public void Lerp(float speed, Color color) {
        interpolateSpeed = speed / 10;
        counter = 0; // resets our counter variable
        this.nextColor = color;
    }
}
