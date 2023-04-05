using ArcadeCamera;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonMovement : MonoBehaviour {
    [SerializeField] private float speed; // speed of walk
    [SerializeField] private FirstPersonCameraController cameraController; // camera controller

    [SerializeField] PlayerInput playerInput; // player input component
    private InputAction verMovement; // vertical axis, from "Walk Vertical" of player input
    private InputAction horMovement; // horizontal axis, from "Walk Horizontal" of player input

    private bool isMoving = false; // is the player in motino? (for footstep audio)

    private bool isLocked = false; // Is movement locked (lock to keep the player in one place

    // Called on first frame
    // EFFECT: initializes vertical movement and horizontal movement variables
    private void Start() {
        this.verMovement = this.playerInput.actions["Walk Vertical"];
        this.horMovement = this.playerInput.actions["Walk Horizontal"];
    }

    // called every frame (FixedUpdate() is for physics)
    // EFFECT: moves this transform by horizontal axis and vertical axis
    void FixedUpdate() {
        if (isLocked)
        {
            return;
        }
        
        float ver = this.verMovement.ReadValue<float>();
        float hor = this.horMovement.ReadValue<float>();
        Vector3 move = this.speed * Time.deltaTime * new Vector3(hor, 0f, ver);
        transform.Translate(move, Space.Self);

        // to play footstep noise
        if (ver != 0 || hor != 0) {
            if (!isMoving) {
                FindObjectOfType<AudioManager>().Play("footstep");
                this.isMoving = true;
            }
        } else {
            if (isMoving) {
                FindObjectOfType<AudioManager>().Stop("footstep");
                this.isMoving = false;
            }
        }
    }
    
    public void Lock()
    {
        isLocked = true;
        isMoving = false;
        FindObjectOfType<AudioManager>().Stop("footstep");
    }

    public void Unlock()
    {
        isLocked = false;
    }
}
