using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTrigger : MonoBehaviour
{
    [SerializeField] private GameObject objToActivate;
    void OnTriggerEnter2D(Collider2D other) {
      if (other.CompareTag("Player")) {
        objToActivate.SetActive(true);
      }
    }
}
