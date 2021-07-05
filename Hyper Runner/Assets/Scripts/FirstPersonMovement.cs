using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonMovement : MonoBehaviour {
    [SerializeField] private float speed; // speed of walk
    [SerializeField] private FirstPersonCameraController cameraController; // camera controller

    [SerializeField] PlayerInput playerInput; // player input component
    private InputAction verMovement; // vertical axis, from "Walk Vertical" of player input
    private InputAction horMovement; // horizontal axis, from "Walk Horizontal" of player input

    // Called on first frame
    // EFFECT: initializes vertical movement and horizontal movement variables
    private void Start() {
        this.verMovement = this.playerInput.actions["Walk Vertical"];
        this.horMovement = this.playerInput.actions["Walk Horizontal"];
    }

    // called every frame (FixedUpdate() is for physics)
    // EFFECT: moves this transform by horizontal axis and vertical axis
    void FixedUpdate() {
        float ver = this.verMovement.ReadValue<float>();
        float hor = this.horMovement.ReadValue<float>();
        Vector3 move = this.speed * Time.deltaTime * new Vector3(hor, 0f, ver);
        transform.Translate(move, Space.Self);
    }

    public void OnLookVertical(InputValue value) {
        this.cameraController.OnLookVertical(value);
    }

    public void OnLookHorizontal(InputValue value) {
        this.cameraController.OnLookHorizontal(value);
    }
}
