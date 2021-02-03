using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public GameObject cam;
    public float parallaxEffect;
    private float camStartX;
    private float thisStartX;

    // Start is called before the first frame update
    void Start()
    {
      thisStartX = transform.position.x;
      camStartX = cam.transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
      float difference = cam.transform.position.x - camStartX;
      /*the bigger the parallaxEffect, the faster the background will move. i cannot wrap
      my mind around how this works for some reason but it does and i wrote it!*/
      transform.position = new Vector3(thisStartX + difference/parallaxEffect, transform.position.y, transform.position.z);
    }
}
