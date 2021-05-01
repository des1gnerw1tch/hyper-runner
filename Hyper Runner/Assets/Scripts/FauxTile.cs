using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxTile : MonoBehaviour
{
    [SerializeField] private Animator animator;
    void OnTriggerEnter2D (Collider2D other)  {
      if (other.CompareTag("Player")) {
        animator.SetTrigger("rotate");
      }
    }
}
