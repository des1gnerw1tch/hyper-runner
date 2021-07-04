using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonMovement : MonoBehaviour {
    [SerializeField] private float speed;
    private float hor;
    private float ver;
    [SerializeField] private FirstPersonCameraController cameraController;
    void FixedUpdate() {
        //float hor = Input.GetAxis("Horizontal");
        //float ver = Input.GetAxis("Vertical");

        Vector3 move = new Vector3(this.hor, 0f, this.ver) * this.speed * Time.deltaTime;
        transform.Translate(move, Space.Self);
    }

    // When vertical movement is pressed
    public void OnWalkVertical(InputValue value) {
        this.ver = value.Get<float>();
        Debug.Log("Input vertical: " + ver);
    }

    // when horizontal movement is pressed
    public void OnWalkHorizontal(InputValue value) {
        this.hor = value.Get<float>();
        Debug.Log("Input horizontal: " + hor);
    }

    public void OnLookVertical(InputValue value) {
        this.cameraController.OnLookVertical(value);
    }

    public void OnLookHorizontal(InputValue value) {
        this.cameraController.OnLookHorizontal(value);
    }
}
