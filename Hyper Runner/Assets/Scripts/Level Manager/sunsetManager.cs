using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class sunsetManager : ALevelManager {
    [SerializeField] public Color sky_launch2_color;
    [SerializeField] public Color horizon_launch2_color;
    [SerializeField] private float delayForHyperRunner2DSound = 3f;

    public override void Start() {
        base.Start();
        //Play welcome message
        StartCoroutine(PlayWelcome());
    }

    IEnumerator PlayWelcome() {
        yield return new WaitForSeconds(delayForHyperRunner2DSound);
        FindObjectOfType<AudioManager>().Play("welcomeMessage");
    }

}
