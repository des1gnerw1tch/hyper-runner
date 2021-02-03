using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveByTouch : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {

      if (Input.touchCount > 0) {
        Touch touch = Input.GetTouch(0);
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
        touchPosition.z = 0f;
        transform.position = touchPosition;
      }

    }

    /*void OnMouseDown()  {
      Destroy(this.gameObject);
    }*/
}
