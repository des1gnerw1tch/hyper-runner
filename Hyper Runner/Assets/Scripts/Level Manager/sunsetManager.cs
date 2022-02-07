using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class sunsetManager : ALevelManager {
    [SerializeField] public Color sky_launch2_color;
    [SerializeField] public Color horizon_launch2_color;

    public override void Start() {
        base.Start();
        //Play welcome message
        StartCoroutine(PlayWelcome());
    }

    IEnumerator PlayWelcome() {
        float delay = 3f;
        yield return new WaitForSeconds(delay);
        FindObjectOfType<AudioManager>().Play("welcomeMessage");
    }

}
