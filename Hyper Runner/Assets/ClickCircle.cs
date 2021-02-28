using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCircle : MonoBehaviour
{
    [SerializeField] RectTransform rectTransform;
    void Start()
    {
      Vector3 pos = new Vector3(Random.Range(-355f, 355f), Random.Range(-170f, 170f), 0);
      rectTransform.localPosition = pos;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnClick() {
      Destroy(this.gameObject);
    }
}
