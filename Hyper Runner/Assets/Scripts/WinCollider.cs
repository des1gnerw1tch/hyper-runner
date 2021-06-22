using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.Animations;

public class WinCollider : MonoBehaviour {
    [SerializeField] private Animator blackScreen;
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            blackScreen.SetTrigger("activate");
        }
    }
}
