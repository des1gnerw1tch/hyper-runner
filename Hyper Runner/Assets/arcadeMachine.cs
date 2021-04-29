using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arcadeMachine : MonoBehaviour
{
    [SerializeField] private GameObject playerCam;
    [SerializeField] private GameObject animCam;
    private bool animationPlaying;

    void Start()
    {
      playerCam.SetActive(true);
      animCam.SetActive(false);
      animationPlaying = false;
    }

    void OnTriggerStay(Collider other)  {
      if (other.CompareTag("Player") && Input.GetKeyDown("e") && !animationPlaying)  {
        // start animation
        animationPlaying = true;
        playerCam.SetActive(false);
        animCam.SetActive(true);
        Debug.Log("Worked");
      }
    }
}
