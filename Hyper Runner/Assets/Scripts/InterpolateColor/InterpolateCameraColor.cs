using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script will interpolate between original color and color of choice
public class InterpolateCameraColor : AInterpolateColor {
    [SerializeField] private Camera mainCamera; // camera we will change the background color of

    protected override void InitCurrentColor() {
        this.currentColor = this.mainCamera.backgroundColor;
    }

    protected override void UpdateColor(Color c) {
        this.mainCamera.backgroundColor = c;
    }
}
