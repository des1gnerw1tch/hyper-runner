using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterHealth : MonoBehaviour {
    [SerializeField] private Collider2D frontCollider;
    public float charisma = 70f;
    private const float MIN_CHARISMA = 0f;
    private const float MAX_CHARISMA = 100f;
    [SerializeField] private Animator portrait_animator;
    [SerializeField] private Flash objToFlash;
    [SerializeField] private Color posFlashColor;
    [SerializeField] private Color negFlashColor;
    [SerializeField] private float flashSpeed;
    [SerializeField] private float minHeight = 3.8f;
    [SerializeField] private float maxHeight = 13.4f;
    private bool charismaIsHighest; // make sure "yay" sound is played only once

    void Start() {
        charisma = 70f;
    }


    // Sharp object case, kill player on any collision, including land on.
    void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("Sharp")) { // A "Sharp" object means that player will die on it.
            this.RunIntoObject();
        }
    }

    // Any object case, if front collider is breached by game object, game over.
    void OnTriggerEnter2D(Collider2D other) {
        if (frontCollider.IsTouching(other)) {
            // only kills player on ground/sharp objects
            if (other.CompareTag("Ground") || (other.CompareTag("Sharp")))
                this.RunIntoObject();

        }
    }

    public void Die() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
    }

    // Charisma
    public void AddCharisma(float value) {
        float raw = charisma + value;
        charisma = Mathf.Clamp(raw, MIN_CHARISMA, MAX_CHARISMA);
        UpdatePortrait();
        TintPlayer(value);
        if (charisma == 0) {
            Die();
        }
    }

    private void UpdatePortrait() {
        if (charisma == 100) {
            portrait_animator.SetTrigger("4");
            if (!charismaIsHighest) { // make sure "yay" sound is played only once
                FindObjectOfType<AudioManager>().Play("yay");
            }
            charismaIsHighest = true;
        } else if (charisma >= 60) {
            portrait_animator.SetTrigger("3");
        } else if (charisma >= 30) {
            portrait_animator.SetTrigger("2");
            charismaIsHighest = false;
        } else if (charisma >= 0) {
            portrait_animator.SetTrigger("1");
            charismaIsHighest = false;
        }
    }

    private void TintPlayer(float num) {
        if (num > 0) {
            objToFlash.StartFlash(posFlashColor, flashSpeed);
        } else {
            objToFlash.StartFlash(negFlashColor, flashSpeed);
        }
    }

    void RunIntoObject() {
        this.AddCharisma(-10f);
        this.transform.position =
                new Vector3(transform.position.x, maxHeight - .1f, 0);
        FindObjectOfType<AudioManager>().Play("negative");
    }

    void Update() {
        // handle player hits max height of world
        if (transform.position.y > maxHeight || transform.position.y < minHeight) {
            this.AddCharisma(-10f);
        }
    }

}
