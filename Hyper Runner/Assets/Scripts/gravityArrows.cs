using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityArrows : MonoBehaviour
{   // player fields
    [SerializeField] private Transform player;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private PlayerMovement movement;
    [SerializeField] private Flash flashObject;
    [SerializeField] private Color flashColor;
    [SerializeField] private float flashSpeed;

    [SerializeField] private float rotation = 180;
    private bool active = true; // so that arrows only activate once

    void OnTriggerEnter2D(Collider2D other) {
      if (active) {
        if (other.CompareTag("Player")) {
          Debug.Log(Physics2D.gravity.y);
          if (Physics2D.gravity.y < 0)  {
            flippedGravity();
          } else {
            normalGravity();
          }
        }
      }
    }

    void flippedGravity()  {
      // this flips gravity, same magnitude negative direction
      Physics2D.gravity = new Vector2 (0, -Physics2D.gravity.y);
      player.rotation = Quaternion.Euler(Vector3.forward * rotation);
      sprite.flipX = true;
      flashObject.StartFlash(flashColor, flashSpeed);
      movement.jumpsLeft -= 1;
      active = false;
    }

    void normalGravity()  {
      Physics2D.gravity = new Vector2 (0, -Physics2D.gravity.y);
      player.rotation = Quaternion.Euler(Vector3.forward * 0);
      sprite.flipX = false;
      flashObject.StartFlash(flashColor, flashSpeed);
      movement.jumpsLeft -= 1;
      active = false;
    }
}
