using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonCameraController : MonoBehaviour {
    [SerializeField] private float RotationSpeed;
    [SerializeField] private Transform player;
    [SerializeField] PlayerInput playerInput; // player input component
    private InputAction verMovement; // vertical axis, from "Look Vertical" of player input
    private InputAction horMovement; // horizontal axis, from "Look Horizontal" of player input
    float rotX, rotY;

    // Called on first frame,
    // EFFECT: initializes verMovement and horMovement input actions, cursor is locked and hidden
    void Start() {
        this.verMovement = this.playerInput.actions["Look Vertical"];
        this.horMovement = this.playerInput.actions["Look Horizontal"];
        Cursor.visible = false;

        //locks the cursor so that it stays in the center of the screen
        Cursor.lockState = CursorLockMode.Locked;

        // TODO: Make these have starting parameters we can feed in, this is how player starts rotation
        this.rotX = 90f;
        this.rotY = 0;
    }

    // Late Update, happens after other updates
    // EFFECT: changes rotation of player, camera, and changes rotX and rotY variables
    void LateUpdate() {

        this.rotX += this.RotationSpeed * horMovement.ReadValue<float>();
        this.rotY += this.RotationSpeed * verMovement.ReadValue<float>();

        this.rotY = Mathf.Clamp(rotY, -60, 60);

        transform.rotation = Quaternion.Euler(rotY, rotX, 0); // rotates the camera
        this.player.rotation = Quaternion.Euler(0, rotX, 0); // rotates the player
    }
}
