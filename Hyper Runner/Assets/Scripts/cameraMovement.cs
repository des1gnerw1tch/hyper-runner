using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float startY;
    // Start is called before the first frame update
    void Start()
    {
      player = GameObject.FindWithTag("Player").transform;
      startY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
      transform.position = new Vector3(player.position.x + 3, startY, -10);
      //transform.position.x = player.position.x;

    }
}
