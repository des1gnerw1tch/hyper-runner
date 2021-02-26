using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatImage : MonoBehaviour
{
    public int timeToRepeat;
    private float width;
    [SerializeField] private float spaceBetweenRepeats;
    [SerializeField] private SpriteRenderer spriteRenderer;
  //  [SerializeField] private bool isFirst;
    void Start()  {
      width = spriteRenderer.bounds.size.x;
      if (timeToRepeat > 0) {
        Vector3 pos = new Vector3 (transform.position.x + width + spaceBetweenRepeats, transform.position.y, 0);
        GameObject instance = Instantiate(this.gameObject, pos, Quaternion.identity);
        instance.GetComponent<RepeatImage>().timeToRepeat = timeToRepeat - 1;
      }
    }


}
