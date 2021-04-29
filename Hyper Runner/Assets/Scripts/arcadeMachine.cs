using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arcadeMachine : MonoBehaviour
{
    [SerializeField] private GameObject playerCam;
    [SerializeField] private GameObject animCam;
    [SerializeField] private GameObject backlight;
    [SerializeField] private GameObject popUpText;
    private bool animationPlaying;

    void Start()
    {
      playerCam.SetActive(true);
      animCam.SetActive(false);
      backlight.SetActive(false);
      popUpText.SetActive(false);
      animationPlaying = false;
    }

    void OnTriggerStay(Collider other)  {
      if (other.CompareTag("Player") && Input.GetKeyDown("e") && !animationPlaying)  {
        // start animation
        animationPlaying = true;
        playerCam.SetActive(false);
        animCam.SetActive(true);
        backlight.SetActive(true);
        popUpText.SetActive(false);
        Debug.Log("Worked");
      }
    }

    void OnTriggerEnter(Collider other) {
      if (other.CompareTag("Player")) {
        popUpText.SetActive(true);
      }
    }

    void OnTriggerExit(Collider other) {
      if (other.CompareTag("Player")) {
        popUpText.SetActive(false);
      }
    }
}
