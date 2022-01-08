using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class MirrorCameraParryObject : ExplodingParryObject {
    // Start is called before the first frame update
    [Header("Mirror Camera Object Required Components (Auto)")]
    [SerializeField] private CameraOrientation cameraOrientation;
    [SerializeField] private FlashPanel flashPanel;
    [Header("Mirror Camera Object Required Serialization")]
    [SerializeField] private Color colorToFlash;

    // on first frame call
    public override void Start() {
        base.Start();
        this.cameraOrientation = FindObjectOfType<CameraOrientation>();
        this.flashPanel = FindObjectOfType<FlashPanel>();
    }
    // when parry object is parried off of
    public override void OnParry() {
        this.cameraOrientation.Mirror();
        this.flashPanel.Flash(this.colorToFlash);
        base.OnParry();
    }
}