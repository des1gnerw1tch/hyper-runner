using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour
{
  void OnCollisionEnter2D (Collision2D other)  {
    if (other.gameObject.CompareTag("Sharp"))  { // A "Sharp" object means that player will die on it.
      SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }
  }
}
