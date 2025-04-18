using UnityEngine;
using UnityEngine.InputSystem;

namespace ArcadeCamera
{
// Deals with Player and Camera synchronized rotation
    public class FirstPersonCameraController : MonoBehaviour
    {
        [SerializeField] private float rotationSpeedVer;
        [SerializeField] private float rotationSpeedHor;
        [SerializeField] private Transform player;
        [SerializeField] PlayerInput playerInput; // player input component
        private InputAction verMovement; // vertical axis, from "Look Vertical" of player input
        private InputAction horMovement; // horizontal axis, from "Look Horizontal" of player input
        float rotX, rotY; // rotations, changed by vertical and horizontal axis's

        private bool rotationLocked;

        // Called on first frame,
        // EFFECT: initializes verMovement and horMovement input actions, cursor is locked and hidden
        void Start()
        {
            this.verMovement = this.playerInput.actions["Look Vertical"];
            this.horMovement = this.playerInput.actions["Look Horizontal"];
            Cursor.visible = false;

            //locks the cursor so that it stays in the center of the screen
            Cursor.lockState = CursorLockMode.Locked;
        }

        // Late Update, happens after other updates
        // EFFECT: changes rotation of player, camera, and changes rotX and rotY variables
        void Update()
        {
            if (rotationLocked)
            {
                return;
            }

            this.RotateFromPlayerInput();
            this.UpdateRotation(); // This will rotate the player every frame...
        }

        // rotates player from player input
        void RotateFromPlayerInput()
        {
            this.rotY += this.rotationSpeedHor * horMovement.ReadValue<float>() * Time.deltaTime;
            this.rotX += this.rotationSpeedVer * verMovement.ReadValue<float>() * Time.deltaTime;

            this.rotX = Mathf.Clamp(rotX, -60, 60);
        }

        // rotates player from script input, raw input
        public void RotatePlayer(float rotX, float rotY)
        {
            this.rotY = rotY;
            this.rotX = Mathf.Clamp(rotX, -60, 60);
            this.UpdateRotation();
        }

        // Rotates player to rotation of a existing transform
        public void RotatePlayer(Transform obj)
        {
            this.RotatePlayer(obj.transform.eulerAngles.x, obj.transform.eulerAngles.y);

        }

        // rotates the player and camera based on current rotX and rotY fields
        void UpdateRotation()
        {
            transform.localRotation = Quaternion.Euler(rotX, 0, 0); // rotates the camera
            this.player.rotation = Quaternion.Euler(0, rotY, 0); // rotates the player
        }

        // Will freeze rotation of player and camera, so camera can be used in different contexts without being controlled by input.
        public void Lock()
        {
            rotationLocked = true;
        }

        public void Unlock()
        {
            rotationLocked = false;
        }
    }
}
