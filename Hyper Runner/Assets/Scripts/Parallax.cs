using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    
    public float parallaxEffect;
    public static float multiplier = 1;
    [Header("Auto filled Serialization")]
    [SerializeField] private Move cameraMovement;

    // Update is called once per frame
    void Start()  {
      // multiplier will increase parallax effect by a scalar. Set to 1 on start every time
      cameraMovement = GameObject.FindWithTag("CameraHolder").GetComponent<Move>();
      multiplier = 1;
    }
    void Update()
    {
      float camSpeed = cameraMovement.speed;
      /*the bigger the parallaxEffect, the faster the background will move in comparison to the camera*/
      // parralaxEffect of 0 denotes an object moving at the same vel of camera, 0 velocity normally
      transform.position = new Vector3(transform.position.x + MusicSync.deltaSample * (camSpeed - parallaxEffect * multiplier), transform.position.y, transform.position.z);
    }
}
