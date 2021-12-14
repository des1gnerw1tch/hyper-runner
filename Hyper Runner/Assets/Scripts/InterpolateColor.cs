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

    private bool isRainbowMash; // is rainbowMash activated?
    private void Start() {
        this.currentColor = this.mainCamera.backgroundColor;
    }

    void Update() {
        //sky interpolation
        if (interpolateSpeed > 0) { // Start interpolation
            counter += MusicSync.deltaSample * interpolateSpeed;
            Color c = Color.Lerp(currentColor, nextColor, counter);
            if (counter >= 1) { // fully interpolated

                //interpolateSpeed = 0;
                this.currentColor = nextColor;

                if (isRainbowMash) { // EXPERIMENTAL
                    this.nextColor = RandomColor();
                    this.counter = 0;
                } else {
                    interpolateSpeed = 0;
                }
            }
            mainCamera.backgroundColor = c;
        }
    }

    public void Lerp(float speed, Color color) {
        interpolateSpeed = speed / 10;
        counter = 0; // resets our counter variable
        this.nextColor = color;
    }

    // experimental rainbow mashing of colors!
    public void RainbowMash(float speed) {
        interpolateSpeed = speed / 10;
        counter = 0;
        this.isRainbowMash = true;
        this.nextColor = RandomColor();
    }

    // picks a random color from the rainbow!
    public Color RandomColor() {
        Color[] colors = { Color.blue, Color.cyan, Color.green, Color.magenta,
            Color.red, Color.yellow, Color.white, Color.black};
        int rand = Random.Range(0, colors.Length);
        return colors[rand];

    }
}
