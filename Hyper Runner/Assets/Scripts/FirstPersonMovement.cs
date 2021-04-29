using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    void FixedUpdate()
    {
      float hor = Input.GetAxis("Horizontal");
      float ver = Input.GetAxis("Vertical");

      Vector3 move = new Vector3(hor, 0f, ver) * speed * Time.deltaTime;

      transform.Translate(move, Space.Self);
    }
}
