using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// interpolates the color of a sprite
public class InterpolateSpriteColor : AInterpolateColor {
    [SerializeField] private SpriteRenderer sprite;
    public override void InitCurrentColor() {
        this.currentColor = sprite.color;
    }

    public override void UpdateColor(Color c) {
        this.sprite.color = c;
    }
}
