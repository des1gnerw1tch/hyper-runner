using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parryObject : MonoBehaviour
{
    [SerializeField] private PlayerMovement movement;
    private bool isActive = true;

    void OnTriggerEnter2D(Collider2D other) {
      if (isActive) {
        if (other.CompareTag("Player")) {
          movement.jumpsLeft += 1;
          isActive = false;
        }
      }
      Debug.Log("Entered Parry object");
    }

    void OnTriggerExit2D(Collider2D other)  {
      if (other.CompareTag("Player")) {
        movement.jumpsLeft -= 1;
      }
      Debug.Log("Exited Parry object");
    }
}
