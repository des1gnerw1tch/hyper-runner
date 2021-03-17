using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private Move cameraMovement;
    public float parallaxEffect;

    // Update is called once per frame
    void Update()
    {
      float camSpeed = cameraMovement.speed;
      /*the bigger the parallaxEffect, the faster the background will move in comparison to the camera*/
      // parralaxEffect of 0 denotes an object moving at the same vel of camera, 0 velocity normally
      transform.position = new Vector3(transform.position.x + Time.deltaTime * (camSpeed - parallaxEffect), transform.position.y, transform.position.z);
    }
}
