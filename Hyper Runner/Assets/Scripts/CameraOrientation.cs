using UnityEngine;

// creates visual effect, Mirrors Camera across x axis, 
public class CameraOrientation : MonoBehaviour
{

    [SerializeField] private Camera cameraToFlip;
    [SerializeField] private bool isCameraStartYFlipped; // if the camera starts flipped in level
    public bool isYFlipped; // if the camera is currently flipped over Y axis

    // called on first frame
    private void Start() {
        isYFlipped = this.isCameraStartYFlipped;
    }
    // creates visual effect where it mirrors the camera over the y axis
    public void Mirror() {
        Matrix4x4 mat = cameraToFlip.projectionMatrix;
        mat *= Matrix4x4.Scale(new Vector3(-1, 1, 1));
        cameraToFlip.projectionMatrix = mat;
        isYFlipped = !isYFlipped;
    }

}
