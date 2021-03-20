using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
      transform.position = new Vector3 (transform.position.x + speed*MusicSync.deltaSample, transform.position.y, transform.position.z);
    }
}
