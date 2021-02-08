using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sunsetManager : MonoBehaviour
{
    public float playerCamMoveSpeed = 5f;
    [SerializeField] private Move cameraMovement;
    [SerializeField] private PlayerMovement playerMovement;
    void Start()
    {
      UpdateSpeeds();
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    public void UpdateSpeeds()  {
      playerMovement.speed = playerCamMoveSpeed;
      cameraMovement.speed = playerCamMoveSpeed;
    }
}
