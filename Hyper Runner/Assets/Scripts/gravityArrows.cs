using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityArrows : MonoBehaviour {   // player fields
    [SerializeField] private PlayerMovement movement; // platformer movement script
    [SerializeField] private Color flashColor; // the color you would like the player to flash 
    [SerializeField] private float flashSpeed;// the speed you would like the player to flash 

    [SerializeField] private float rotation = 180;
    private bool active = true; // so that arrows only activate once

    void OnTriggerEnter2D(Collider2D other) {
        if (this.active) {
            if (other.CompareTag("Player")) {
                if (Physics2D.gravity.y < 0) {
                    this.movement.ActivateNegativeGravity(this.flashColor, this.flashSpeed);
                    this.active = false;

                } else {
                    this.movement.ActivateNormalGravity(this.flashColor, this.flashSpeed);
                    this.active = false;
                }
            }
        }
    }
}
