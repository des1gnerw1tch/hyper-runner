using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For interpolating a color of an object
public abstract class AInterpolateColor : MonoBehaviour {
    protected Color currentColor;
    private Color nextColor; // the color we should interpolate to
    private float interpolateSpeed; // how fast to interpolate
    private float counter; // clamped between 0,1

    private bool isRainbowMash; // is rainbowMash activated?
    private Color[] rainbowMashColors; // colors to be rainbow mashed
    private void Start() {
        InitCurrentColor();
        //this.currentColor = this.mainCamera.backgroundColor;
    }

    // called every frame
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
            UpdateColor(c);
            //mainCamera.backgroundColor = c;
        }
    }

    // Updates color of this object
    protected abstract void UpdateColor(Color c);

    // initializes variable current color as soon as game starts
    protected abstract void InitCurrentColor();

    public void Lerp(float speed, Color color) {
        interpolateSpeed = speed / 10;
        counter = 0; // resets our counter variable
        this.nextColor = color;
        this.isRainbowMash = false;
    }

    // experimental rainbow mashing of colors!
    public void RainbowMash(float speed, Color[] listOfColors)
    {
        if (listOfColors.Length < 2)
        {
            Debug.LogError("RainbowMashColors is < 2");
            return;
        }
        
        rainbowMashColors = listOfColors;
        interpolateSpeed = speed / 10;
        counter = 0;
        this.isRainbowMash = true;
        this.nextColor = RandomColor();
    }

    // picks a random color from the rainbow!
    private Color RandomColor() {
        /*Color[] colors = { Color.blue, Color.cyan, Color.green, Color.magenta,
            Color.red, Color.yellow, Color.white, Color.black};*/
        
        int rand = Random.Range(0, rainbowMashColors.Length);
        return rainbowMashColors[rand];

    }
}
