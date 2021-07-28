using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// creates visual effect, Mirrors Camera across x axis, 
public class CameraOrientation : MonoBehaviour {

    // creates visual effect where it mirrors the camera over the y axis
    public void Mirror() {
        Matrix4x4 mat = Camera.main.projectionMatrix;
        mat *= Matrix4x4.Scale(new Vector3(-1, 1, 1));
        Camera.main.projectionMatrix = mat;
    }

}
