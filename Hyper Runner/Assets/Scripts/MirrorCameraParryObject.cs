using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorCameraParryObject : AParryObject {
    // Start is called before the first frame update
    [SerializeField] private CameraOrientation cameraOrientation;
    [SerializeField] private FlashPanel flashPanel;

    // when parry object is parried off of
    public override void onParry() {
        this.cameraOrientation.Mirror();
        this.flashPanel.Flash();
    }
}