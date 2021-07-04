using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonCameraController : MonoBehaviour {
    [SerializeField] private float RotationSpeed;
    [SerializeField] private Transform player;
    float mouseX, mouseY;

    void Start() {
        Cursor.visible = false;
        //locks the cursor so that it stays in the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Late Update, happens after other updates
    void LateUpdate() {
        //mouseX += Input.GetAxis("Mouse X") * RotationSpeed;
        // - = because it is flipped
        //mouseY -= Input.GetAxis("Mouse Y") * RotationSpeed;
        /* Mathf.Clamp(object, min, max), makes sure that it doesn't get too high or low*/
        mouseY = Mathf.Clamp(mouseY, -60, 60);

        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        player.rotation = Quaternion.Euler(0, mouseX, 0);
    }

    public void OnLookVertical(InputValue value) {
        this.mouseY += value.Get<float>() * RotationSpeed;
        Debug.Log("Pressed");
    }

    public void OnLookHorizontal(InputValue value) {
        this.mouseX += value.Get<float>() * RotationSpeed;
        Debug.Log("Pressed");
    }

}
