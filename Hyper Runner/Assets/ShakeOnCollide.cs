using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeOnCollide : MonoBehaviour
{
  //test script, will delete later
  void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Player")) {
      FindObjectOfType<CameraShake>().Begin(.5f, 10f, 1f);
    }
  }
}
