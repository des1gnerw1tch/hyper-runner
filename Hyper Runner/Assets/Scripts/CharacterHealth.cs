using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour
{
  [SerializeField] private Collider2D frontCollider;
  [SerializeField] private float charisma = 70f;
  private const float MIN_CHARISMA = 0f;
  private const float MAX_CHARISMA = 100f;
  [SerializeField] private Animator portrait_animator;

  void Start()  {
    charisma = 70f;
  }


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

  // Charisma

  public void AddCharisma(float value)  {
    float raw = charisma + value;
    charisma = Mathf.Clamp(raw, MIN_CHARISMA, MAX_CHARISMA);
    UpdatePortrait();
    if (charisma == 0)  {
      Die();
    }
  }

  private void UpdatePortrait()  {
    if (charisma == 100)  {
      portrait_animator.SetTrigger("4");
    } else if (charisma >= 60)  {
      portrait_animator.SetTrigger("3");
    } else if (charisma >= 30)  {
      portrait_animator.SetTrigger("2");
    } else if (charisma >= 0)  {
      portrait_animator.SetTrigger("1");
    }
  }

}
