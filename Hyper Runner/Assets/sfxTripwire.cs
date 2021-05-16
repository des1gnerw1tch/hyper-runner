using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxTripwire : MonoBehaviour
{
    [SerializeField] private string soundToPlay;

    void OnTriggerEnter2D(Collider2D other) {
      if (other.CompareTag("Player")) {
        FindObjectOfType<AudioManager>().Play(soundToPlay);
      }
    }
}
