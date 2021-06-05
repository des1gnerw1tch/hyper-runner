using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AParryObject : MonoBehaviour
{
  [SerializeField] private PlayerMovement movement;
  private bool isActive = true;

  // sends this parry object info to player, allows for a parry jump
  void OnTriggerEnter2D(Collider2D other) {
    if (isActive) {
      if (other.CompareTag("Player")) {
        movement.enterParryObject(this);
        isActive = false;
      }
    }
  }

  // this parry object is no longer in contact with player
  void OnTriggerExit2D(Collider2D other)  {
    if (other.CompareTag("Player")) {
      movement.exitParryObject();
    }
  }

  // when this parry object used
  public abstract void onParry();
}
