using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIStar : MonoBehaviour {

    [SerializeField] private Animator animator;
    // called on first tick
    void Start() {
        StartCoroutine("Animate");
    }

    // does animation every 1-15 seconds
    IEnumerator Animate() {
        yield return new WaitForSeconds(Random.Range(1, 7));
        this.animator.SetTrigger("shine");
        StartCoroutine("Animate");
    }
}
