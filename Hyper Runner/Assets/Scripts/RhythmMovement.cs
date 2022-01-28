using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RhythmMovement : MonoBehaviour {
    [HideInInspector] public float speed; // Set in ALevelManager
    private bool teleporting;
    private float teleportSpeed;
    [SerializeField] private const float MIDDLE_OF_SCREEN_Y = 8.8f;
    [SerializeField] private Animator animatorComponent;
    [SerializeField] private RuntimeAnimatorController rhythmAnimator;
    [SerializeField] private GameObject rhythm_up_tile;
    [SerializeField] private GameObject rhythm_down_tile;
    // Start is called before the first frame update
    void Start() {
        Debug.Log("Switched!");
    }

    // Update is called once per frame
    void Update() {
        transform.position = new Vector3(transform.position.x + speed * MusicSync.deltaSample,
            transform.position.y, transform.position.z);

        if (teleporting) {
            float step = teleportSpeed * MusicSync.deltaSample;
            Vector2 target = new Vector2(transform.position.x, MIDDLE_OF_SCREEN_Y);
            transform.position = Vector2.MoveTowards(transform.position, target, step);
            if (transform.position.y == MIDDLE_OF_SCREEN_Y) {
                teleporting = false;
                Debug.Log("Stopped Teleporting");
                animatorComponent.runtimeAnimatorController = rhythmAnimator;
            }
        }

        // TODO: MAKE this another key, OR CHANGE W and S to not be dance keys in input manager

        // will print rhythm blocks at current X position of player, helps with creating rhythym lines
        /* if (Input.GetKeyDown("w"))  {
           Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);
           Instantiate(rhythm_up_tile, position, Quaternion.identity);
         }
         if (Input.GetKeyDown("s"))  {
           Vector3 position = new Vector3(transform.position.x, transform.position.y, 0);
           Instantiate(rhythm_down_tile, position, Quaternion.identity);
           Debug.Log(transform.position.x);
         }*/
    }

    // startRhythm : Float -> will move player
    // when called will over time kick the player into the middle of the
    // screen. it will turn off gravity too.
    public void startRhythm(float teleSpeed) {
        Debug.Log("Started teleporting");
        teleporting = true;
        teleportSpeed = teleSpeed;
    }
}
