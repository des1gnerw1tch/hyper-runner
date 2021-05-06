using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gravityArrows : MonoBehaviour
{
    [SerializeField] private GameObject player;
  //  [SerializeField] private Rigidbody2D rb; // players rigidbody

    void OnTriggerEnter2D(Collider2D other) {
      if (other.CompareTag("Player")) {
        Debug.Log("changed gravity");
        //rb.gravityScale = 2f;
        //other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 2f;
        //other.gameObject.rigidbody2D.gravityScale = -5f;
      }
    }
}
