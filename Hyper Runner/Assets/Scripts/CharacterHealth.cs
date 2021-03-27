using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour
{
  [SerializeField] private Collider2D frontCollider;

  // Sharp object case, kill player on any collision, including land on.
  void OnCollisionEnter2D (Collision2D other)  {
    if (other.gameObject.CompareTag("Sharp"))  { // A "Sharp" object means that player will die on it.
      Die();
    }
  }

  // Any object case, if front collider is breached by game object, game over.
  void OnTriggerEnter2D(Collider2D other) {
    if (frontCollider.IsTouching(other))  {
      // only kills player on ground/sharp objects
      if (other.CompareTag("Ground") || (other.CompareTag("Sharp")))
        Die();

    }
  }

  public void Die() {
    SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
  }

}
