using UnityEngine;

// interpolates the color of a sprite
public class InterpolateSpriteColor : AInterpolateColor {
    [SerializeField] private SpriteRenderer sprite;
    protected override void InitCurrentColor() {
        this.currentColor = sprite.color;
    }

    protected override void UpdateColor(Color c) {
        this.sprite.color = c;
    }
}
