using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeOnCollide : MonoBehaviour
{
  [SerializeField] private float intensity;
  [SerializeField] private float speed;
  [SerializeField] private float duration;

  void OnTriggerEnter2D(Collider2D other) {
    if (other.CompareTag("Player")) {
      FindObjectOfType<CameraShake>().Begin(intensity, speed, duration);
    }
  }
}
